using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 进程操作
    /// </summary>
    public class ProcessUtils
    {
        /// <summary>
        /// 打开一个批处理脚本
        /// </summary>
        /// <param name="batFile"></param>
        public static void StartCmd(string batFile)
        {
            Process p = new Process();
            batFile = Path.GetFullPath(batFile);
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(batFile);
            p.StartInfo.FileName = batFile;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }

        /// <summary>
        /// 开启一个进程
        /// </summary>
        /// <param name="exeFile">进程文件</param>
        /// <param name="args">命令行参数</param>
        public static void StartProcess(string exeFile,string args="")
        {
            Process p = new Process();
            p.StartInfo.Arguments = args;
            exeFile= Path.GetFullPath(exeFile);
            p.StartInfo.FileName = exeFile;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(exeFile);
            p.Start();
            p.WaitForExit();
        }

        /// <summary>
        /// 开启一个进程并进行输出重定向
        /// </summary>
        /// <param name="exeFile">进程文件</param>
        /// <param name="args">命令行参数</param>
        public static void StartProcessRedirect(string exeFile,string redirectPath, string args = "")
        {
            Process p = new Process();
            p.StartInfo.Arguments = args;
            exeFile = Path.GetFullPath(exeFile);
            p.StartInfo.FileName = exeFile;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(exeFile);
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.StartInfo.UseShellExecute = false;
            var sw = File.CreateText(redirectPath);
            p.OutputDataReceived += new DataReceivedEventHandler((sender, e) => 
            { sw.WriteLine(e.Data); }
            );
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
            sw.Close();
        }

        public static Process OpenUrl(string url)
        {
            Process p = null;
            if (!string.IsNullOrEmpty(url))
            {
                p = Process.Start(url);
                if (p == null)
                {
                    p = Process.Start("explorer.exe", url);
                    if (p == null)
                    {
                        p = Process.Start("iexplorer.exe", url);
                    }
                }
            }
            return p;
        }
    }
}
