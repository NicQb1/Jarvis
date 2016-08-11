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
using NNBuilder_Runable;
using Common.structs;
using Neurons;
using Graph_Database_Access;

namespace Jarvis
{
    public partial class MainForm : Form
    {
        public IInput inPutLayer;
        public Matrix matrix;
        public SpeechProcessor.SpeechProcessor sp;
        public SerialStreamingInput ssI;
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
            if (matrix != null)
            {
                matrix.SpeechInput(e.Result.Text.ToString());
            }

        }

        private void btnBuildNetwork_Click(object sender, EventArgs e)
        {
            Int16 x = 500, y = 500, z = 500, t = 5;
          //  matrix = new Network.Matrix(y, x, z, t);
          //  Utilities ut = new Utilities();
            BuildMatrix bm = new BuildMatrix();
            bm.Build_New_Matrix(y, x, z, t, 8,2);
            
         //   inPutLayer = new SerialStreamingInput(ref matrix);

            List<coordinates[]> inputBytes = bm.inputBytes;
            List<coordinates[]> outputBytes = bm.outputBytes;
            matrix = bm.matrix;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdDictionaryFile.ShowDialog();
            if(result== DialogResult.OK)
            {
                GraphDB gb = new GraphDB();
                gb.LoadDictionaryFile(ofdDictionaryFile.FileName);
            }

        }
    }
}
