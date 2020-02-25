namespace GitSnakeTest
{
    partial class SnakeGame
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
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.errorLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // moveTimer
            // 
            this.moveTimer.Interval = 200;
            this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
            // 
            // errorLab
            // 
            this.errorLab.AutoSize = true;
            this.errorLab.Location = new System.Drawing.Point(13, 13);
            this.errorLab.Name = "errorLab";
            this.errorLab.Size = new System.Drawing.Size(46, 17);
            this.errorLab.TabIndex = 0;
            this.errorLab.Text = "label1";
            // 
            // SnakeGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(778, 749);
            this.Controls.Add(this.errorLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "SnakeGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.SnakeGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeGame_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Label errorLab;
    }
}

