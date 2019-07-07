using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
#if NET40
using Codeplex.Data;
#endif
#if !NET20
using System.Linq;
#endif
using System.Diagnostics;
using System.Text.RegularExpressions;
using NetDimension.Json;
using NetDimension.Json.Linq;

namespace NetDimension.Weibo
{
	/// <summary>
	/// OAuth2.0授权类
	/// </summary>
	public class OAuth
	{
		private const string AUTHORIZE_URL = "https://api.weibo.com/oauth2/authorize";
		private const string ACCESS_TOKEN_URL = "https://api.weibo.com/oauth2/access_token";

		/// <summary>
		/// 获取App Key
		/// </summary>
		public string AppKey
		{
			get;
			internal set;
		}
		/// <summary>
		/// 获取App Secret
		/// </summary>
		public string AppSecret
		{
			get;
			internal set;
		}

		/// <summary>
		/// 获取Access Token
		/// </summary>
		public string AccessToken
		{
			get;
			internal set;
		}

		/// <summary>
		/// 获取或设置回调地址
		/// </summary>
		public string CallbackUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Refresh Token 似乎目前没用
		/// </summary>
		public string RefreshToken
		{
			get;
			internal set;
		}

        /// <summary>
        /// 代理设置
        /// </summary>
        public WebProxy Proxy
        {
            get;
            set;
        }

		/// <summary>
		/// 实例化OAuth类（用于授权）
		/// </summary>
		/// <param name="appKey">AppKey</param>
		/// <param name="appSecret">AppSecret</param>
		/// <param name="callbackUrl">指定在新浪开发平台后台中所绑定的回调地址</param>
		
		public OAuth(string appKey, string appSecret, string callbackUrl = null)
		{
			this.AppKey = appKey;
			this.AppSecret = appSecret;
			this.AccessToken = string.Empty;
			this.CallbackUrl = callbackUrl;
			
		}

		/// <summary>
		/// 实例化OAuth类（用于实例化操作类）
		/// </summary>
		/// <param name="appKey">AppKey</param>
		/// <param name="appSecret">AppSecret</param>
		/// <param name="accessToken">已经获取的AccessToken，若Token没有过期即可通过操作类Client调用接口</param>
		/// <param name="refreshToken">目前还不知道这个参数会不会开放，保留</param>
		public OAuth(string appKey, string appSecret, string accessToken, string refreshToken = null)
		{
			this.AppKey = appKey;
			this.AppSecret = appSecret;
			this.AccessToken = accessToken;
			this.RefreshToken = refreshToken ?? string.Empty;
		}

		internal string Request(string url, RequestMethod method = RequestMethod.Get, params WeiboParameter[] parameters)
		{
			string rawUrl = string.Empty;
			UriBuilder uri = new UriBuilder(url);
			string result = string.Empty;



			bool multi = false;
#if !NET20
			multi = parameters.Count(p => p.IsBinaryData) > 0;
#else
			foreach (var item in parameters)
			{
				if (item.IsBinaryData)
				{
					multi = true;
					break;
				}
			}
#endif

			switch (method)
			{
				case RequestMethod.Get:
					{
						uri.Query = Utility.BuildQueryString(parameters);
					}
					break;
				case RequestMethod.Post:
					{
						if (!multi)
						{
							uri.Query = Utility.BuildQueryString(parameters);
						}
					}
					break;
			}

			if (string.IsNullOrEmpty(AccessToken))
			{
				if (uri.Query.Length == 0)
				{
					uri.Query = "source=" + AppKey;
				}
				else
				{
					uri.Query += "&source=" + AppKey;
				}
			}


			HttpWebRequest http = WebRequest.Create(uri.Uri) as HttpWebRequest;
			http.ServicePoint.Expect100Continue = false;
			http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            if (Proxy != null)
            {
                
                if (Proxy.Credentials != null)
                {
                    http.UseDefaultCredentials = true;
                }

                http.Proxy = Proxy;
            }
			if (!string.IsNullOrEmpty(AccessToken))
			{
				http.Headers["Authorization"] = string.Format("OAuth2 {0}", AccessToken);
			}

			switch (method)
			{
				case RequestMethod.Get:
					{
						http.Method = "GET";
					}
					break;
				case RequestMethod.Post:
					{
						http.Method = "POST";

						if (multi)
						{
							string boundary = Utility.GetBoundary();
							http.ContentType = string.Format("multipart/form-data; boundary={0}",boundary);
							http.AllowWriteStreamBuffering = true;
							using (Stream request = http.GetRequestStream())
							{
								try
								{
									var raw = Utility.BuildPostData(boundary,parameters);
									request.Write(raw, 0, raw.Length);
								}
								finally
								{
									request.Close();
								}
							}
						}
						else
						{
							http.ContentType = "application/x-www-form-urlencoded";
							
							using (StreamWriter request = new StreamWriter(http.GetRequestStream()))
							{
								try
								{
									request.Write(Utility.BuildQueryString(parameters));
								}
								finally
								{
									request.Close();
								}
							}
						}
					}
					break;
			}

			try
			{
				using (WebResponse response = http.GetResponse())
				{

					using (StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						try
						{
							result = reader.ReadToEnd();
						}
						catch(WeiboException) 
						{
							throw;
						}
						finally
						{
							reader.Close();
						}
					}


					response.Close();
				}
			}
			catch (System.Net.WebException webEx)
			{
				if (webEx.Response != null)
				{
					using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
					{
						string errorInfo = reader.ReadToEnd();
#if DEBUG
						Debug.WriteLine(errorInfo);
#endif
						Error error = JsonConvert.DeserializeObject<Error>(errorInfo);

						reader.Close();

						throw new WeiboException(string.Format("{0}", error.Code), error.Message, error.Request);

					}
				}
				else
				{
					throw new WeiboException(webEx.Message);
				}

			}
			catch
			{
				throw;
			}
			return result;
		}

		/// <summary>
		/// OAuth2的authorize接口
		/// </summary>
		/// <param name="response">返回类型，支持code、token，默认值为code。</param>
		/// <param name="state">用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数。 </param>
		/// <param name="display">授权页面的终端类型，取值见下面的说明。 
		/// default 默认的授权页面，适用于web浏览器。 
		/// mobile 移动终端的授权页面，适用于支持html5的手机。 
		/// popup 弹窗类型的授权页，适用于web浏览器小窗口。 
		/// wap1.2 wap1.2的授权页面。 
		/// wap2.0 wap2.0的授权页面。 
		/// js 微博JS-SDK专用授权页面，弹窗类型，返回结果为JSONP回掉函数。
		/// apponweibo 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。 
		/// </param>
		/// <returns></returns>
		public string GetAuthorizeURL(ResponseType response= ResponseType.Code,string state=null, DisplayType display = DisplayType.Default)
		{
			Dictionary<string, string> config = new Dictionary<string, string>()
			{
				{"client_id",AppKey},
				{"redirect_uri",CallbackUrl},
				{"response_type",response.ToString().ToLower()},
				{"state",state??string.Empty},
				{"display",display.ToString().ToLower()},
			};
			UriBuilder builder = new UriBuilder(AUTHORIZE_URL);
			builder.Query = Utility.BuildQueryString(config);

			return builder.ToString();
		}

		/// <summary>
		/// 判断AccessToken有效性
		/// </summary>
		/// <returns></returns>
		public TokenResult VerifierAccessToken()
		{
			try
			{
				var json = Request("https://api.weibo.com/2/account/get_uid.json", RequestMethod.Get);

			}
			catch (WeiboException ex)
			{
				switch (ex.ErrorCode)
				{ 
					case "21314":
						return TokenResult.TokenUsed;
					case "21315":
						return TokenResult.TokenExpired;
					case "21316":
						return TokenResult.TokenRevoked;
					case "21317":
						return TokenResult.TokenRejected;
					default:
						return TokenResult.Other;
				}
			}

			return TokenResult.Success;
		}
		#region AccessToken获取的方法集合
		/// <summary>
		/// 使用code方式获取AccessToken
		/// </summary>
		/// <param name="code">Code</param>
		/// <returns></returns>
		public AccessToken GetAccessTokenByAuthorizationCode(string code)
		{
			return GetAccessToken(GrantType.AuthorizationCode, new Dictionary<string, string> { 
				{"code",code},
				{"redirect_uri", CallbackUrl}
			});
		}
		
		/// <summary>
		/// 使用password方式获取AccessToken
		/// </summary>
		/// <param name="passport">账号</param>
		/// <param name="password">密码</param>
		/// <returns></returns>
		public AccessToken GetAccessTokenByPassword(string passport, string password)
		{
			return GetAccessToken(GrantType.Password, new Dictionary<string, string> { 
				{"username",passport},
				{"password", password}
			});
		}

		/// <summary>
		/// 使用token方式获取AccessToken
		/// </summary>
		/// <param name="refreshToken">refresh token，目前还不知道从哪里获取这个token，未开放</param>
		/// <returns></returns>
		public AccessToken GetAccessTokenByRefreshToken(string refreshToken)
		{
			return GetAccessToken(GrantType.RefreshToken, new Dictionary<string, string> { 
				{"refresh_token",refreshToken}
			});
		}
		/// <summary>
		/// 站内应用使用SignedRequest获取AccessToken
		/// </summary>
		/// <param name="signedRequest">SignedRequest</param>
		/// <returns></returns>
		public AccessToken GetAccessTokenBySignedRequest(string signedRequest)
		{
			string[] parameters = signedRequest.Split('.');
			if (parameters.Length < 2)
				throw new Exception("SignedRequest格式错误。");
			var encodedSig = parameters[0];
			var payload = parameters[1];
			var sha256 = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(AppSecret));
			var expectedSig = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(payload)));
			sha256.Clear();

			encodedSig = parameters[0].Length % 4 == 0 ? parameters[0] : parameters[0].PadRight(parameters[0].Length + (4 - parameters[0].Length % 4), '=').Replace("-", "+").Replace("_", "/");
			payload = parameters[1].Length % 4 == 0 ? parameters[1] : parameters[1].PadRight(parameters[1].Length + (4 - parameters[1].Length % 4), '=').Replace("-", "+").Replace("_", "/");

			
			
			if(encodedSig != expectedSig)
				throw new WeiboException("SignedRequest签名验证失败。");
			var result = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(payload)));

			if (result["oauth_token"] == null)
				return null;//throw new WeiboException("没有获取到授权信息，请先进行授权。");

			AccessToken token = new AccessToken();
			AccessToken = token.Token = result["oauth_token"].ToString();

			

			token.UID = result["user_id"].ToString();
			token.ExpiresIn = Convert.ToInt32(result["expires"].ToString());
			return token;
		}

		internal AccessToken GetAccessToken(GrantType type, Dictionary<string, string> parameters)
		{

			List<WeiboParameter> config = new List<WeiboParameter>()
			{
				new WeiboParameter(){ Name= "client_id", Value= AppKey},
				new WeiboParameter(){ Name="client_secret", Value=AppSecret}
			};

			switch (type)
			{
				case GrantType.AuthorizationCode:
					{
						config.Add(new WeiboParameter() { Name = "grant_type", Value = "authorization_code" });
						config.Add(new WeiboParameter() { Name = "code", Value = parameters["code"] });
						config.Add(new WeiboParameter() { Name = "redirect_uri", Value = parameters["redirect_uri"] });
					}
					break;
				case GrantType.Password:
					{
						config.Add(new WeiboParameter() { Name = "grant_type", Value = "password" });
						config.Add(new WeiboParameter() { Name = "username", Value = parameters["username"] });
						config.Add(new WeiboParameter() { Name = "password", Value = parameters["password"] });
					}
					break;
				case GrantType.RefreshToken:
					{
						config.Add(new WeiboParameter() { Name = "grant_type", Value = "refresh_token" });
						config.Add(new WeiboParameter() { Name = "refresh_token", Value = parameters["refresh_token"] });
					}
					break;
			}

			var response = Request(ACCESS_TOKEN_URL, RequestMethod.Post, config.ToArray());

			if (!string.IsNullOrEmpty(response))
			{
				AccessToken token = JsonConvert.DeserializeObject<AccessToken>(response);
				AccessToken = token.Token;
				return token;
			}
			else
			{
				return null;
			}
		}

		#endregion

		public bool ClientLogin(string passport, string password)
		{
			return ClientLogin(passport, password, null);
		}

		/// <summary>
		/// 使用模拟方式进行登录并获得AccessToken
		/// </summary>
		/// <param name="passport">微博账号</param>
		/// <param name="password">微博密码</param>
		/// <returns></returns>
		public bool ClientLogin(string passport, string password, AccessToken token)
		{
			bool result = false;
#if !NET20
			ServicePointManager.ServerCertificateValidationCallback = (sender, certificate,chain,sslPolicyErrors) =>
			{
				return true;
			};

#else

			ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,System.Security.Cryptography.X509Certificates.X509Chain chain,System.Net.Security.SslPolicyErrors sslPolicyErrors)
			{
				return true;
			};
#endif
			CookieContainer MyCookieContainer = new CookieContainer();
			HttpWebRequest http = WebRequest.Create(AUTHORIZE_URL) as HttpWebRequest;
			http.Referer = GetAuthorizeURL();
			http.Method = "POST";
			http.ContentType = "application/x-www-form-urlencoded";
			http.AllowAutoRedirect = true;
			http.KeepAlive = true;
			http.CookieContainer = MyCookieContainer;
			string postBody = string.Format("action=submit&withOfficalFlag=0&ticket=&isLoginSina=&response_type=token&regCallback=&redirect_uri={0}&client_id={1}&state=&from=&userId={2}&passwd={3}&display=js", Uri.EscapeDataString(string.IsNullOrEmpty(CallbackUrl)? "": CallbackUrl), Uri.EscapeDataString(AppKey), Uri.EscapeDataString(passport), Uri.EscapeDataString(password));
			byte[] postData = Encoding.Default.GetBytes(postBody);
			http.ContentLength = postData.Length;

			using (Stream request = http.GetRequestStream())
			{
				try
				{
					request.Write(postData, 0, postData.Length);
				}
				catch
				{
					throw;
				}
				finally
				{ 
					request.Close();
				}
			}
			string code = string.Empty;
			try
			{
				using (HttpWebResponse response = http.GetResponse() as HttpWebResponse)
				{
					if (response != null)
					{
						using (StreamReader reader = new StreamReader(response.GetResponseStream()))
						{
							try
							{
								var html = reader.ReadToEnd();
								var pattern1=@"\{""access_token"":""(?<token>.{0,32})"",""remind_in"":""(?<remind>\d+)"",""expires_in"":(?<expires>\d+),""uid"":""(?<uid>\d+)""\}";
								var pattern2=@"\{""access_token"":""(?<token>.{0,32})"",""remind_in"":""(?<remind>\d+)"",""expires_in"":(?<expires>\d+),""refresh_token"":""(?<refreshtoken>.{0,32})"",""uid"":""(?<uid>\d+)""\}";
								if (!string.IsNullOrEmpty(html) && (Regex.IsMatch(html, pattern1) || Regex.IsMatch(html, pattern2)))
								{
									var group = Regex.IsMatch(html,"refresh_token") ?Regex.Match(html, pattern2) : Regex.Match(html, pattern1);

									AccessToken = group.Groups["token"].Value;
									if (token != null)
									{
										token.ExpiresIn = Convert.ToInt32(group.Groups["expires"].Value);
										token.Token = group.Groups["token"].Value;
										token.UID = group.Groups["uid"].Value;
									}
									result = true;
								}
							}
							catch { }
							finally
							{
								reader.Close();
							}
						}
					}
					response.Close();
				}
			}
			catch (System.Net.WebException)
			{
				throw;
			}

			return result;

		}

	}
}
