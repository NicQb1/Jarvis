using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;

namespace JarvisUI
{
    public partial class Form1 : Form
    {
        public SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSpeechRecognition_Click(object sender, EventArgs e)
        {
            
            //DictationGrammar defaultDictationGrammar = new DictationGrammar();
            //defaultDictationGrammar.Name = "default dictation";
            //defaultDictationGrammar.Enabled = true;
            Choices commands = new Choices();
            commands.Add(new string[] { "Jarvis", "Hey", "Computer", "Lights" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);
            sre.LoadGrammarAsync(g);
          //  sre.LoadGrammarAsync(defaultDictationGrammar);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.SetInputToDefaultAudioDevice();
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }
        public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("Speech recognized: " + e.Result.Text);
        }
    }
}
