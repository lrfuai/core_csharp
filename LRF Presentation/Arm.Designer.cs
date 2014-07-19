namespace LRF_Presentation
{
    partial class Arm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arm));
            this.ElbowBtn = new System.Windows.Forms.Button();
            this.ShoulderBtn = new System.Windows.Forms.Button();
            this.WirstBtn = new System.Windows.Forms.Button();
            this.BaseBtn = new System.Windows.Forms.Button();
            this.WristTxt = new System.Windows.Forms.TextBox();
            this.ElbowTxt = new System.Windows.Forms.TextBox();
            this.ShoulderTxt = new System.Windows.Forms.TextBox();
            this.BaseTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ElbowBtn
            // 
            this.ElbowBtn.Location = new System.Drawing.Point(348, 124);
            this.ElbowBtn.Name = "ElbowBtn";
            this.ElbowBtn.Size = new System.Drawing.Size(63, 23);
            this.ElbowBtn.TabIndex = 0;
            this.ElbowBtn.Text = "Play";
            this.ElbowBtn.UseVisualStyleBackColor = true;
            this.ElbowBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShoulderBtn
            // 
            this.ShoulderBtn.Location = new System.Drawing.Point(234, 254);
            this.ShoulderBtn.Name = "ShoulderBtn";
            this.ShoulderBtn.Size = new System.Drawing.Size(63, 23);
            this.ShoulderBtn.TabIndex = 1;
            this.ShoulderBtn.Text = "Play";
            this.ShoulderBtn.UseVisualStyleBackColor = true;
            this.ShoulderBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // WirstBtn
            // 
            this.WirstBtn.Location = new System.Drawing.Point(111, 124);
            this.WirstBtn.Name = "WirstBtn";
            this.WirstBtn.Size = new System.Drawing.Size(63, 23);
            this.WirstBtn.TabIndex = 2;
            this.WirstBtn.Text = "Play";
            this.WirstBtn.UseVisualStyleBackColor = true;
            this.WirstBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // BaseBtn
            // 
            this.BaseBtn.Location = new System.Drawing.Point(278, 338);
            this.BaseBtn.Name = "BaseBtn";
            this.BaseBtn.Size = new System.Drawing.Size(63, 23);
            this.BaseBtn.TabIndex = 3;
            this.BaseBtn.Text = "Play";
            this.BaseBtn.UseVisualStyleBackColor = true;
            this.BaseBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // WristTxt
            // 
            this.WristTxt.Location = new System.Drawing.Point(111, 98);
            this.WristTxt.Name = "WristTxt";
            this.WristTxt.Size = new System.Drawing.Size(63, 20);
            this.WristTxt.TabIndex = 4;
            // 
            // ElbowTxt
            // 
            this.ElbowTxt.Location = new System.Drawing.Point(348, 98);
            this.ElbowTxt.Name = "ElbowTxt";
            this.ElbowTxt.Size = new System.Drawing.Size(63, 20);
            this.ElbowTxt.TabIndex = 5;
            // 
            // ShoulderTxt
            // 
            this.ShoulderTxt.Location = new System.Drawing.Point(234, 228);
            this.ShoulderTxt.Name = "ShoulderTxt";
            this.ShoulderTxt.Size = new System.Drawing.Size(63, 20);
            this.ShoulderTxt.TabIndex = 6;
            // 
            // BaseTxt
            // 
            this.BaseTxt.Location = new System.Drawing.Point(278, 312);
            this.BaseTxt.Name = "BaseTxt";
            this.BaseTxt.Size = new System.Drawing.Size(63, 20);
            this.BaseTxt.TabIndex = 7;
            // 
            // Arm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(585, 361);
            this.Controls.Add(this.BaseTxt);
            this.Controls.Add(this.ShoulderTxt);
            this.Controls.Add(this.ElbowTxt);
            this.Controls.Add(this.WristTxt);
            this.Controls.Add(this.BaseBtn);
            this.Controls.Add(this.WirstBtn);
            this.Controls.Add(this.ShoulderBtn);
            this.Controls.Add(this.ElbowBtn);
            this.Name = "Arm";
            this.Text = "Prueba de Brazo";
            this.Load += new System.EventHandler(this.Arm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ElbowBtn;
        private System.Windows.Forms.Button ShoulderBtn;
        private System.Windows.Forms.Button WirstBtn;
        private System.Windows.Forms.Button BaseBtn;
        private System.Windows.Forms.TextBox WristTxt;
        private System.Windows.Forms.TextBox ElbowTxt;
        private System.Windows.Forms.TextBox ShoulderTxt;
        private System.Windows.Forms.TextBox BaseTxt;
    }
}