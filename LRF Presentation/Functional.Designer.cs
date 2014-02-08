namespace LRF_Presentation
{
    partial class Functional
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapViewer = new System.Windows.Forms.PictureBox();
            this.boxManualNavigation = new System.Windows.Forms.GroupBox();
            this.btnMoveBackward = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnMoveForward = new System.Windows.Forms.Button();
            this.Robot = new System.Windows.Forms.GroupBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radarViewer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapViewer)).BeginInit();
            this.boxManualNavigation.SuspendLayout();
            this.Robot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radarViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // mapViewer
            // 
            this.mapViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapViewer.Location = new System.Drawing.Point(13, 13);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.Size = new System.Drawing.Size(400, 400);
            this.mapViewer.TabIndex = 0;
            this.mapViewer.TabStop = false;
            // 
            // boxManualNavigation
            // 
            this.boxManualNavigation.Controls.Add(this.btnMoveBackward);
            this.boxManualNavigation.Controls.Add(this.btnTurnRight);
            this.boxManualNavigation.Controls.Add(this.btnTurnLeft);
            this.boxManualNavigation.Controls.Add(this.btnMoveForward);
            this.boxManualNavigation.Location = new System.Drawing.Point(419, 13);
            this.boxManualNavigation.Name = "boxManualNavigation";
            this.boxManualNavigation.Size = new System.Drawing.Size(265, 124);
            this.boxManualNavigation.TabIndex = 5;
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
            // Robot
            // 
            this.Robot.Controls.Add(this.lblPosition);
            this.Robot.Controls.Add(this.label1);
            this.Robot.Location = new System.Drawing.Point(419, 143);
            this.Robot.Name = "Robot";
            this.Robot.Size = new System.Drawing.Size(264, 49);
            this.Robot.TabIndex = 6;
            this.Robot.TabStop = false;
            this.Robot.Text = "Robot";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(61, 19);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(0, 13);
            this.lblPosition.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // radarViewer
            // 
            this.radarViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radarViewer.Location = new System.Drawing.Point(454, 213);
            this.radarViewer.Name = "radarViewer";
            this.radarViewer.Size = new System.Drawing.Size(200, 200);
            this.radarViewer.TabIndex = 7;
            this.radarViewer.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 426);
            this.Controls.Add(this.radarViewer);
            this.Controls.Add(this.Robot);
            this.Controls.Add(this.boxManualNavigation);
            this.Controls.Add(this.mapViewer);
            this.Name = "Main";
            this.Text = "LRF Presentation";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapViewer)).EndInit();
            this.boxManualNavigation.ResumeLayout(false);
            this.Robot.ResumeLayout(false);
            this.Robot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radarViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapViewer;
        private System.Windows.Forms.GroupBox boxManualNavigation;
        private System.Windows.Forms.Button btnMoveBackward;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnMoveForward;
        private System.Windows.Forms.GroupBox Robot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.PictureBox radarViewer;
    }
}

