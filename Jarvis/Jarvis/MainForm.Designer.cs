namespace Jarvis
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartSpeechProcessor = new System.Windows.Forms.Button();
            this.btnCreateNewInstance = new System.Windows.Forms.Button();
            this.btnBuildNetwork = new System.Windows.Forms.Button();
            this.txtRecognizedSpeech = new System.Windows.Forms.TextBox();
            this.ofdDictionaryFile = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtToSubmit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartSpeechProcessor
            // 
            this.btnStartSpeechProcessor.Location = new System.Drawing.Point(43, 43);
            this.btnStartSpeechProcessor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartSpeechProcessor.Name = "btnStartSpeechProcessor";
            this.btnStartSpeechProcessor.Size = new System.Drawing.Size(211, 30);
            this.btnStartSpeechProcessor.TabIndex = 0;
            this.btnStartSpeechProcessor.Text = "Start Speech Processor";
            this.btnStartSpeechProcessor.UseVisualStyleBackColor = true;
            this.btnStartSpeechProcessor.Click += new System.EventHandler(this.btnStartSpeechProcessor_Click);
            // 
            // btnCreateNewInstance
            // 
            this.btnCreateNewInstance.Location = new System.Drawing.Point(43, 80);
            this.btnCreateNewInstance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateNewInstance.Name = "btnCreateNewInstance";
            this.btnCreateNewInstance.Size = new System.Drawing.Size(211, 28);
            this.btnCreateNewInstance.TabIndex = 1;
            this.btnCreateNewInstance.Text = "Create New Instance";
            this.btnCreateNewInstance.UseVisualStyleBackColor = true;
            // 
            // btnBuildNetwork
            // 
            this.btnBuildNetwork.Location = new System.Drawing.Point(43, 116);
            this.btnBuildNetwork.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuildNetwork.Name = "btnBuildNetwork";
            this.btnBuildNetwork.Size = new System.Drawing.Size(211, 28);
            this.btnBuildNetwork.TabIndex = 2;
            this.btnBuildNetwork.Text = "Build Network";
            this.btnBuildNetwork.UseVisualStyleBackColor = true;
            this.btnBuildNetwork.Click += new System.EventHandler(this.btnBuildNetwork_Click);
            // 
            // txtRecognizedSpeech
            // 
            this.txtRecognizedSpeech.Location = new System.Drawing.Point(323, 43);
            this.txtRecognizedSpeech.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRecognizedSpeech.Multiline = true;
            this.txtRecognizedSpeech.Name = "txtRecognizedSpeech";
            this.txtRecognizedSpeech.Size = new System.Drawing.Size(416, 477);
            this.txtRecognizedSpeech.TabIndex = 3;
            // 
            // ofdDictionaryFile
            // 
            this.ofdDictionaryFile.Multiselect = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Dictionary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 214);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(114, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit text";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtToSubmit
            // 
            this.txtToSubmit.Location = new System.Drawing.Point(12, 243);
            this.txtToSubmit.Multiline = true;
            this.txtToSubmit.Name = "txtToSubmit";
            this.txtToSubmit.Size = new System.Drawing.Size(304, 57);
            this.txtToSubmit.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 535);
            this.Controls.Add(this.txtToSubmit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRecognizedSpeech);
            this.Controls.Add(this.btnBuildNetwork);
            this.Controls.Add(this.btnCreateNewInstance);
            this.Controls.Add(this.btnStartSpeechProcessor);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSpeechProcessor;
        private System.Windows.Forms.Button btnCreateNewInstance;
        private System.Windows.Forms.Button btnBuildNetwork;
        private System.Windows.Forms.TextBox txtRecognizedSpeech;
        private System.Windows.Forms.OpenFileDialog ofdDictionaryFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtToSubmit;
    }
}

