namespace JarvisUI
{
    partial class Form1
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
            this.btnSpeechRecognition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSpeechRecognition
            // 
            this.btnSpeechRecognition.Location = new System.Drawing.Point(74, 35);
            this.btnSpeechRecognition.Name = "btnSpeechRecognition";
            this.btnSpeechRecognition.Size = new System.Drawing.Size(130, 23);
            this.btnSpeechRecognition.TabIndex = 0;
            this.btnSpeechRecognition.Text = "Start speech recognition";
            this.btnSpeechRecognition.UseVisualStyleBackColor = true;
            this.btnSpeechRecognition.Click += new System.EventHandler(this.btnSpeechRecognition_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.btnSpeechRecognition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSpeechRecognition;
    }
}

