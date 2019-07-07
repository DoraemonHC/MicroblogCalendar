using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;
using System.Threading;

namespace NetDimension.Weibo
{
	/// <summary>
	/// 异步调用中的函数调用代理
	/// </summary>
	/// <typeparam name="T">API返回的类型</typeparam>
	/// <returns>T</returns>
	public delegate T AsyncInvokeDelegate<T>();
	/// <summary>
	/// 异步调用中的回调代理
	/// </summary>
	/// <typeparam name="T">函数调用中的返回类型</typeparam>
	/// <param name="result">AsyncCallback对象</param>
	public delegate void AsyncCallbackDelegate<T>(AsyncCallback<T> result);
	/// <summary>
	/// 微博操作类
	/// </summary>
	public class Client
	{

		const string BASE_URL = "https://api.weibo.com/2/";

		/// <summary>
		/// OAuth实例
		/// </summary>
		public OAuth OAuth
		{
			get;
			private set;
		}

#if NET40
		/// <summary>
		/// 微博动态类型接口
		/// </summary>
		public Interface.InterfaceSelector API
		{
			get;
			private set;
		}		
#else
		public Interface.EntityInterfaces API
		{
			get;
			private set;
		}
#endif

		/// <summary>
		/// 实例化微博操作类
		/// </summary>
		/// <param name="oauth">OAuth实例</param>
		public Client(OAuth oauth)
		{
			this.OAuth = oauth;
#if NET40
			API = new Interface.InterfaceSelector(this);
#else
			API = new Interface.EntityInterfaces(this);
#endif
		}

		/// <summary>
		/// 用POST方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string PostCommand(string command, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			List<WeiboParameter> list = new List<WeiboParameter>();
			foreach (var item in parameters)
			{
				list.Add(new WeiboParameter(item.Key, item.Value));
			}
			return PostCommand(command, list.ToArray());
		}
		/// <summary>
		/// 用POST方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string PostCommand(string command, params WeiboParameter[] parameters)
		{
			return Http(command, RequestMethod.Post, parameters);
		}
		/// <summary>
		/// 用GET方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string GetCommand(string command, params WeiboParameter[] parameters)
		{
			return Http(command, RequestMethod.Get, parameters);
		}
		/// <summary>
		/// 用GET方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string GetCommand(string command, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			List<WeiboParameter> list = new List<WeiboParameter>();
			foreach (var item in parameters)
			{
				list.Add(new WeiboParameter(item.Key, item.Value));
			}
			return Http(command, RequestMethod.Get, list.ToArray());
		}

		private string Http(string command, RequestMethod method, params WeiboParameter[] parameters)
		{
			string url = string.Empty;

			if (command.StartsWith("http://") || command.StartsWith("https://"))
			{
				url = command;
			}
			else
			{
				url = string.Format("{0}{1}.json", BASE_URL, command);
			}
			return OAuth.Request(url, method, parameters);
		}

		/// <summary>
		/// API接口异步调用
		/// </summary>
		/// <typeparam name="T">返回类型</typeparam>
		/// <param name="invoker">调用代理</param>
		/// <param name="callback">回调代理</param>
		public void AsyncInvoke<T>(AsyncInvokeDelegate<T> invoker, AsyncCallbackDelegate<T> callback)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
			{
				AsyncCallback<T> result;
				try
				{
					T invoke = invoker();
					result = new AsyncCallback<T>(invoke);
					callback(result);

				}
				catch (Exception ex)
				{
					result = new AsyncCallback<T>(ex, false);
					callback(result);
				}

			}));

		}
	}
}
