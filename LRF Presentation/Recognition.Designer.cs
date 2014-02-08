namespace LRF_Presentation
{
    partial class Recognition
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
            this.components = new System.ComponentModel.Container();
            this.imgBoxCapture = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBoxCapture
            // 
            this.imgBoxCapture.Location = new System.Drawing.Point(12, 12);
            this.imgBoxCapture.Name = "imgBoxCapture";
            this.imgBoxCapture.Size = new System.Drawing.Size(318, 237);
            this.imgBoxCapture.TabIndex = 2;
            this.imgBoxCapture.TabStop = false;
            // 
            // Recognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 261);
            this.Controls.Add(this.imgBoxCapture);
            this.Name = "Recognition";
            this.Text = "Recognition";
            this.Load += new System.EventHandler(this.Recognition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBoxCapture;

    }
}