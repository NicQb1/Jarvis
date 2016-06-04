using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;

namespace SpeechProcessor
{
    public class SpeechProcessor
    {
        public EventHandler<SpeechRecognizedEventArgs> SpeechRecognized;
        private SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
        public void InitializeProcessor()
        {
            //SpeechRecognizer sr = new SpeechRecognizer();
           
            Choices mainCommands = getMainCommands();
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(mainCommands);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);
            sr.LoadGrammar(g);
            sr.LoadGrammar(new Grammar(new GrammarBuilder("exit")));
            sr.LoadGrammar(new DictationGrammar());
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
            sr.SetInputToDefaultAudioDevice();
            sr.RecognizeAsync(RecognizeMode.Multiple);
        }

        private Choices getMainCommands()
        {
            Choices mainCommands = new Choices();
            mainCommands.Add(new string[] { "Jarvis", "Start", "Installl", "Build", "Network" });
            return mainCommands;
        }

        
        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
           
            SpeechRecognized.Invoke(sender,e);
           
        }
    }
}
