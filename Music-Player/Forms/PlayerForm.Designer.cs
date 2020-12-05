using NAudio;
using NAudio.Wave;
using TagLib;
using System.IO;
using System.Windows.Media.Imaging;
namespace Music_Player.Forms
{
    partial class PlayerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerView));
            this.backgroundimg = new System.Windows.Forms.PictureBox();
            this.stitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundimg)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundimg
            // 
            this.backgroundimg.Location = new System.Drawing.Point(-1, 0);
            this.backgroundimg.Name = "backgroundimg";
            this.backgroundimg.Size = new System.Drawing.Size(665, 296);
            this.backgroundimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backgroundimg.TabIndex = 0;
            this.backgroundimg.TabStop = false;
            // 
            // stitle
            // 
            this.stitle.AutoSize = true;
            this.stitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stitle.Location = new System.Drawing.Point(12, 9);
            this.stitle.Name = "stitle";
            this.stitle.Size = new System.Drawing.Size(0, 51);
            this.stitle.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(55, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Play/Pause\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.pausePlayer);
            // 
            // PlayerView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(665, 343);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stitle);
            this.Controls.Add(this.backgroundimg);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerView";
            this.Text = "Music Player - Player";
            ((System.ComponentModel.ISupportInitialize)(this.backgroundimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundimg;
        private System.Windows.Forms.Label stitle;
        private System.Windows.Forms.Button button1;
    }
}