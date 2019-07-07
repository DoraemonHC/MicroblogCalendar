using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    public class Shell
    {
        [DllImport("kernel32.dll")]
        private static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        private static extern Boolean FreeConsole();
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 指示控制台是否处于开启状态
        /// </summary>
        public static bool HasConsole
        {
            get { return GetConsoleWindow() != IntPtr.Zero; }
        }
        /// <summary>
        /// 打开控制台
        /// </summary>
        public static void OpenConsole()
        {
            if (!HasConsole)
            {
                AllocConsole();
                InvalidateOutAndError();
            }
            //禁用关闭按钮
            IntPtr windowHandle = GetConsoleWindow();
            IntPtr closeMenu = GetSystemMenu(windowHandle, IntPtr.Zero);
            const uint SC_CLOSE = 0xF060;
            RemoveMenu(closeMenu, SC_CLOSE, 0x0);
        }
        static void InvalidateOutAndError()
        {
            Type type = typeof(System.Console);

            System.Reflection.FieldInfo _out = type.GetField("_out",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.FieldInfo _error = type.GetField("_error",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Debug.Assert(_out != null);
            Debug.Assert(_error != null);

            Debug.Assert(_InitializeStdOutError != null);

            _out.SetValue(null, null);
            _error.SetValue(null, null);

            _InitializeStdOutError.Invoke(null, new object[] { true });
        }
        /// <summary>
        /// 关闭控制台
        /// </summary>
        public static void CloseConsole()
        {
            if (HasConsole)
            {
                SetOutAndErrorNull();
                FreeConsole();
            }
        }
        /// <summary>
        /// 切换控制台状态
        /// </summary>
        public static void Toggle()
        {
            if (HasConsole)
            {
                CloseConsole();
            }
            else
            {
                OpenConsole();
            }
        }
        static void SetOutAndErrorNull()
        {
            Console.SetOut(TextWriter.Null);
            Console.SetError(TextWriter.Null);
        }
        /// <summary>  
        /// 输出格式化信息  
        /// </summary>  
        /// <param name="format"></param>  
        /// <param name="args"></param>  
        public static void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        /// <summary>  
        /// 输出时间和信息  
        /// </summary>  
        /// <param name="output"></param>  
        public static void WriteLine(string output)
        {
            Console.ForegroundColor = GetConsoleColor(output);
            Console.WriteLine(@"[{0}]{1}", DateTime.Now, output);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>  
        /// 使用指定的颜色输出时间和信息  
        /// </summary>  
        /// <param name="output"></param>  
        public static void WriteLine(string output,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(@"[{0}]{1}", DateTime.Now, output);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>  
        /// 使用指定的颜色输出时间和格式化信息  
        /// </summary>  
        /// <param name="output"></param>  
        public static void WriteLine(string format, ConsoleColor color,params object[] pms)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[{0}]{1}", DateTime.Now, string.Format(format, pms));
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>  
        /// 根据输出文本选择控制台文字颜色  
        /// </summary>  
        /// <param name="output"></param>  
        /// <returns></returns>  
        private static ConsoleColor GetConsoleColor(string output)
        {
            if (output.StartsWith("警告")) return ConsoleColor.Yellow;
            if (output.StartsWith("错误")) return ConsoleColor.Red;
            if (output.StartsWith("注意")) return ConsoleColor.Green;
            return ConsoleColor.Gray;
        }
    }
}
