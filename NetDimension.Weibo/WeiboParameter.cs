using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.Weibo
{
	/// <summary>
	/// 微博API参数
	/// </summary>
	public class WeiboParameter
	{
		/// <summary>
		/// 参数名称
		/// </summary>
		public string Name
		{
			get;
			set;
		}
		/// <summary>
		/// 参数值
		/// </summary>
		public object Value
		{
			get;
			set;
		}

		/// <summary>
		/// 是否为二进制参数（如图片、文件等）
		/// </summary>
		public bool IsBinaryData
		{
			get
			{
				if (Value != null && Value.GetType() == typeof(byte[]))
					return true;
				else
					return false;
			}
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public WeiboParameter()
		{ 
		
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">key</param>
		/// <param name="value">value</param>
		public WeiboParameter(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">key</param>
		/// <param name="value">value</param>
		public WeiboParameter(string name, bool value)
		{
			this.Name = name;
			this.Value = value ? "1" : "0";
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">key</param>
		/// <param name="value">value</param>
		public WeiboParameter(string name, int value)
		{
			this.Name = name;
			this.Value = string.Format("{0}", value);
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">key</param>
		/// <param name="value">value</param>
		public WeiboParameter(string name, long value)
		{
			this.Name = name;
			this.Value = string.Format("{0}", value);
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">key</param>
		/// <param name="value">value</param>
		public WeiboParameter(string name, byte[] value)
		{
			this.Name = name;
			this.Value = value;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">key</param>
		/// <param name="value">value</param>
		public WeiboParameter(string name, object value)
		{
			this.Name = name;
			this.Value = value;
		}
	}
}
