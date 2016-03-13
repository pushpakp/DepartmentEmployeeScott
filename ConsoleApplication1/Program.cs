using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer spch = new SpeechSynthesizer();
            spch.Speak("Hi Pushpak, How are you! Its been long time, where was you?");
        }
    }
}
