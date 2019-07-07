using MicroBlogCalendar.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 讯飞语音合成工具
    /// </summary>
    public class XFSpeaker
    {
        static Wave_Pcm_Header wav_hdr = Wave_Pcm_Header.DefaultWaveHeader();//因为返回的数据没有波形头播放器没法识别，所以要加上它才能播放

        private static string param = string.Empty;
        static int errorCode = 0;
        private static string appid= "5c42e581";

        static XFSpeaker()
        {
            int errorCode = MSPLogin(null, null, string.Format("appid = {0}, work_dir = .", appid));
            if (errorCode != 0)
            {
                Console.WriteLine("登录失败，code={0}", errorCode);
            }
            Console.WriteLine("登录成功...");
            param = @"engine_type = cloud, voice_name = xiaoyan, text_encoding = GB2312, sample_rate = 16000, speed = 50, volume = 50, pitch = 50, rdn = 0";
        }

        public static Stream Speak(string textString)
        {
            MemoryStream ms = new MemoryStream();

            IntPtr intPointer = QTTSSessionBegin(param, ref errorCode);
            string sessionID = Marshal.PtrToStringAnsi(intPointer);
            errorCode = QTTSTextPut(sessionID, textString, (int)MemoryUtils.GetAsciiStringLength(textString), null);

            if (errorCode != 0)
            {
                errorCode = QTTSSessionEnd(sessionID, "abnormal");
                MSPLogout();
                return ms;
            }
            int audioLen = -1, synthStatus = -1;

            int headerSize = Marshal.SizeOf(wav_hdr);
            ms.Write(new byte[headerSize], 0, headerSize);//预留44字节用于后续写波形头

            while (true)
            {
                IntPtr data = QTTSAudioGet(sessionID, ref audioLen, ref synthStatus, ref errorCode);
                if (data != IntPtr.Zero)
                {
                    byte[] bytes = new byte[audioLen];
                    Marshal.Copy(data, bytes, 0, bytes.Length);
                    ms.Write(bytes, 0, bytes.Length);
                    //计算data_size大小
                    //我就不计算了，最后根据流的长度推算
                }
                if (synthStatus == 2 || 0 != errorCode)
                {
                    break;
                }
                //睡一会
                //Thread.Sleep(50);
            }

            wav_hdr.size_8 = (int)ms.Length - 8;/* 修正wav文件头数据的大小 */
            wav_hdr.data_size = (int)ms.Length - headerSize;
            byte[] buffer = MemoryUtils.StructToBytes(wav_hdr);
            ms.Seek(0, SeekOrigin.Begin);//流指针回到头部
            ms.Write(buffer, 0, buffer.Length);
            ms.Seek(0, SeekOrigin.Begin);//流指针回到头部

            errorCode = QTTSSessionEnd(sessionID, "normal end");
            return ms;
        }

        [DllImport("msc.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
        public static extern int MSPLogin(string usr, string pwd, string param);
        [DllImport("msc.dll")]
        public static extern int MSPLogout();
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr MSPGetVersion(string verName, ref int errorCode);
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr MSPUploadData(string dataName, IntPtr data, int dataLen, string param, ref int errorCode);
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern int MSPSetParam(string paramName, string paramValue);

        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr QTTSSessionBegin(string param, ref int errorCode);
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern int QTTSTextPut(string sessionID, string textString, int txtLen, string param);
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr QTTSAudioGet(string sessionID, ref int audioLen, ref int synthStatus, ref int errorCode);
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern int QTTSSessionEnd(string sessionID, string hints);
        [DllImport("msc.dll", CharSet = CharSet.Ansi)]
        public static extern int QTTSGetParam(string sessionID, string paramName, string paramValue, ref int valueLen);
    }
}
