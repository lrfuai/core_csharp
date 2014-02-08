namespace LRF_Presentation
{
    partial class Logical
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
            this.boxManualNavigation = new System.Windows.Forms.GroupBox();
            this.btnMoveBackward = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnMoveForward = new System.Windows.Forms.Button();
            this.boxManualNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxManualNavigation
            // 
            this.boxManualNavigation.Controls.Add(this.btnMoveBackward);
            this.boxManualNavigation.Controls.Add(this.btnTurnRight);
            this.boxManualNavigation.Controls.Add(this.btnTurnLeft);
            this.boxManualNavigation.Controls.Add(this.btnMoveForward);
            this.boxManualNavigation.Location = new System.Drawing.Point(12, 12);
            this.boxManualNavigation.Name = "boxManualNavigation";
            this.boxManualNavigation.Size = new System.Drawing.Size(265, 124);
            this.boxManualNavigation.TabIndex = 6;
            this.boxManualNavigation.TabStop = false;
            this.boxManualNavigation.Text = "Manual Navigation";
            // 
            // btnMoveBackward
            // 
            this.btnMoveBackward.Location = new System.Drawing.Point(101, 65);
            this.btnMoveBackward.Name = "btnMoveBackward";
            this.btnMoveBackward.Size = new System.Drawing.Size(66, 37);
            this.btnMoveBackward.TabIndex = 8;
            this.btnMoveBackward.Text = "Backward";
            this.btnMoveBackward.UseVisualStyleBackColor = true;
            this.btnMoveBackward.Click += new System.EventHandler(this.btnMoveBackward_Click);
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.Location = new System.Drawing.Point(167, 46);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(66, 37);
            this.btnTurnRight.TabIndex = 7;
            this.btnTurnRight.Text = "Turn Right";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.Location = new System.Drawing.Point(35, 46);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(66, 37);
            this.btnTurnLeft.TabIndex = 6;
            this.btnTurnLeft.Text = "Turn Left";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            this.btnTurnLeft.Click += new System.EventHandler(this.btnTurnLeft_Click);
            // 
            // btnMoveForward
            // 
            this.btnMoveForward.Location = new System.Drawing.Point(101, 28);
            this.btnMoveForward.Name = "btnMoveForward";
            this.btnMoveForward.Size = new System.Drawing.Size(66, 37);
            this.btnMoveForward.TabIndex = 5;
            this.btnMoveForward.Text = "Forward";
            this.btnMoveForward.UseVisualStyleBackColor = true;
            this.btnMoveForward.Click += new System.EventHandler(this.btnMoveForward_Click);
            // 
            // Logical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 153);
            this.Controls.Add(this.boxManualNavigation);
            this.Name = "Logical";
            this.Text = "Logical";
            this.Load += new System.EventHandler(this.Logical_Load);
            this.boxManualNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxManualNavigation;
        private System.Windows.Forms.Button btnMoveBackward;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnMoveForward;
    }
}