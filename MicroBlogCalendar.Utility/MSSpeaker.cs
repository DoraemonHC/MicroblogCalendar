using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 微软发音人
    /// </summary>
    public class MSSpeaker
    {
        static SpeechSynthesizer synth;//语音合成实例
        static MSSpeaker()
        {
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
        }
        public static void Speak(string text)
        {
            if (synth.State == SynthesizerState.Speaking)
            {
                synth.SpeakAsyncCancelAll();
            }
            else
            {
                synth.SpeakAsync(text);
            }
        }
        public static void Stop()
        {
            synth.SpeakAsyncCancelAll();
        }
    }
}
