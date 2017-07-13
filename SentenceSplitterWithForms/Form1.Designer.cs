namespace SentenceSplitterWithForms
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
            this.components = new System.ComponentModel.Container();
            this.Input = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Output = new System.Windows.Forms.TextBox();
            this.Analyse = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.Train = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(12, 12);
            this.Input.Multiline = true;
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(479, 251);
            this.Input.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(12, 269);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(479, 261);
            this.Output.TabIndex = 2;
            // 
            // Analyse
            // 
            this.Analyse.Location = new System.Drawing.Point(497, 269);
            this.Analyse.Name = "Analyse";
            this.Analyse.Size = new System.Drawing.Size(143, 105);
            this.Analyse.TabIndex = 3;
            this.Analyse.Text = "Analyse";
            this.Analyse.UseVisualStyleBackColor = true;
            this.Analyse.Click += new System.EventHandler(this.button1_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(497, 12);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(499, 251);
            this.Result.TabIndex = 4;
            this.Result.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Result_KeyUp);
            this.Result.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Result_PreviewKeyDown);
            // 
            // Train
            // 
            this.Train.Location = new System.Drawing.Point(849, 269);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(147, 105);
            this.Train.TabIndex = 5;
            this.Train.Text = "Train";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 542);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Analyse);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormOnload);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button Analyse;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Button Train;
    }
}

