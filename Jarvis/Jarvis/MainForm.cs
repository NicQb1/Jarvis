using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechProcessor;
using System.Speech.Recognition;

namespace Jarvis
{
    public partial class MainForm : Form
    {
        public SpeechProcessor.SpeechProcessor sp;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartSpeechProcessor_Click(object sender, EventArgs e)
        {
            sp = new SpeechProcessor.SpeechProcessor();
            sp.InitializeProcessor();
            sp.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);

        }
        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            txtRecognizedSpeech.Text += txtRecognizedSpeech.Text + e.Result.Text.ToString() + "\r\n";

        }
    }
}
