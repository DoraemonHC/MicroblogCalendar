using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Model
{
    /// <summary>
    /// wav音频头部格式
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Wave_Pcm_Header
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] riff;                // = "RIFF"
        public int size_8;                 // = FileSize - 8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] wave;                // = "WAVE"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] fmt;                 // = "fmt "
        public int fmt_size;               // = 下一个结构体的大小 : 16

        public short format_tag;             // = PCM : 1
        public short channels;               // = 通道数 : 1
        public int samples_per_sec;        // = 采样率 : 8000 | 6000 | 11025 | 16000
        public int avg_bytes_per_sec;      // = 每秒字节数 : samples_per_sec * bits_per_sample / 8
        public short block_align;            // = 每采样点字节数 : wBitsPerSample / 8
        public short bits_per_sample;        // = 量化比特数: 8 | 16

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] data;                // = "data";
        public int data_size;              // = 纯数据长度 : FileSize - 44

        /// <summary>
        ///  获取默认wav音频头部数据
        /// </summary>
        /// <returns></returns>
        public static Wave_Pcm_Header DefaultWaveHeader()
        {
            Wave_Pcm_Header wav_hdr = new Wave_Pcm_Header
            {
                riff = new char[] { 'R', 'I', 'F', 'F' },
                size_8 = 0,
                wave = new char[] { 'W', 'A', 'V', 'E' },
                fmt = new char[] { 'f', 'm', 't', ' ' },
                fmt_size = 16,
                format_tag = 1,
                channels = 1,
                samples_per_sec = 16000,
                avg_bytes_per_sec = 32000,
                block_align = 2,
                bits_per_sample = 16,
                data = new char[] { 'd', 'a', 't', 'a' },
                data_size = 0
            };
            return wav_hdr;
        }
    }
}
