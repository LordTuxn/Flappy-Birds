namespace FlappyBird__OOP_ {
    partial class Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tmr_generatePipe = new System.Windows.Forms.Timer(this.components);
            this.tmr_moveGameElements = new System.Windows.Forms.Timer(this.components);
            this.tmr_switchMode = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmr_generatePipe
            // 
            this.tmr_generatePipe.Interval = 2000;
            this.tmr_generatePipe.Tick += new System.EventHandler(this.Tmr_generatePipe_Tick);
            // 
            // tmr_moveGameElements
            // 
            this.tmr_moveGameElements.Interval = 20;
            this.tmr_moveGameElements.Tick += new System.EventHandler(this.Tmr_moveGameElements_Tick);
            // 
            // tmr_switchMode
            // 
            this.tmr_switchMode.Interval = 5000;
            this.tmr_switchMode.Tick += new System.EventHandler(this.Tmr_switchMode_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Name = "Form1";
            this.Text = "Flappy Birds | Press Space or Arrow-Up to start";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr_generatePipe;
        private System.Windows.Forms.Timer tmr_moveGameElements;
        private System.Windows.Forms.Timer tmr_switchMode;
    }
}

