using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo
{
	/// <summary>
	/// 异步调用的回调参数
	/// </summary>
	/// <typeparam name="T">返回值类型</typeparam>
	public class AsyncCallback<T>
	{
		/// <summary>
		/// 调用是否成功
		/// </summary>
		public bool IsSuccess
		{
			get;
			private set;
		}
		/// <summary>
		/// 返回值
		/// </summary>
		public T Data
		{
			get;
			private set;
		}

		internal AsyncCallback(T result)
		{
			this.Data = result;
			this.IsSuccess = true;
			this.Error = null;
		}

		internal AsyncCallback(Exception ex, bool success)
		{
			this.IsSuccess = success;
			this.Error = ex;
		}

		/// <summary>
		/// 异常对象，如果IsSuccess为true则本对象为null
		/// </summary>
		public Exception Error
		{
			get;
			private set;
		}
	}
}
