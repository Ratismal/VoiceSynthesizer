using System;
using System.Speech.Synthesis;

namespace SampleSynthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            String path = Environment.CurrentDirectory + "/change.wav";

            var voices = synth.GetInstalledVoices();
            foreach (var v in voices)
            {
                Console.WriteLine(v.VoiceInfo.Name);
            }

            try
            {
                Console.WriteLine("Type the name of the voice you want to use:");
                String name = Console.ReadLine();
                foreach (var v in voices)
                {
                    if (v.VoiceInfo.Name.ToUpper().Equals(name.ToUpper()))
                    {
                        synth.SelectVoice(v.VoiceInfo.Name);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured");
            }

            Console.WriteLine("Type something to export");
            while (true)
            {
                String text;

                //synth.SetOutputToDefaultAudioDevice();
                text = Console.ReadLine();
                //synth.SetOutputToDefaultAudioDevice();
                if (System.IO.File.Exists(path)){
                    System.IO.File.Delete(path);
                }
                synth.SetOutputToWaveFile(path);

                
                /*
                // Build a prompt.
                PromptBuilder builder = new PromptBuilder();
                builder.AppendText("This sample asynchronously speaks a prompt to a WAVE file.");
                */
                //synth.Speak(text);
                //Console.WriteLine("Converting '" + text + "' to audio");
                synth.Speak(text);
                synth.SetOutputToDefaultAudioDevice();
                /*
                // Create a SoundPlayer instance to play the output audio file.
                 System.Media.SoundPlayer m_SoundPlayer =
                new System.Media.SoundPlayer(path);

                //  Play the output file.
               m_SoundPlayer.Play();
               */
                
            }
           
        }


    }
}