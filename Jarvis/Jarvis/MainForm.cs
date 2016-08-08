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
using Common;
using InputClasses;

namespace Jarvis
{
    public partial class MainForm : Form
    {
        public IInput inPutLayer;
        public Network.Matrix matrix;
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

        private void btnBuildNetwork_Click(object sender, EventArgs e)
        {
            int x = 500, y = 500, z = 500, t = 5;
            matrix = new Network.Matrix(y, x, z, t);
            Point[] inputPoints = 

            inPutLayer = new SerialStreamingInput(ref matrix);

        }

    }
}
