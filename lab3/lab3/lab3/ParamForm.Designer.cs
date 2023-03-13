namespace lab3
{
    partial class ParamForm
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
            this.CurveWidthTextbox = new System.Windows.Forms.TextBox();
            this.PointRadiusTextbox = new System.Windows.Forms.TextBox();
            this.OkayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurveWidthTextbox
            // 
            this.CurveWidthTextbox.Location = new System.Drawing.Point(35, 39);
            this.CurveWidthTextbox.Name = "CurveWidthTextbox";
            this.CurveWidthTextbox.Size = new System.Drawing.Size(172, 22);
            this.CurveWidthTextbox.TabIndex = 0;
            this.CurveWidthTextbox.Text = "Толщина кривой";
            // 
            // PointRadiusTextbox
            // 
            this.PointRadiusTextbox.Location = new System.Drawing.Point(35, 68);
            this.PointRadiusTextbox.Name = "PointRadiusTextbox";
            this.PointRadiusTextbox.Size = new System.Drawing.Size(172, 22);
            this.PointRadiusTextbox.TabIndex = 1;
            this.PointRadiusTextbox.Text = "Радиус точки";
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(35, 97);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(172, 29);
            this.OkayButton.TabIndex = 2;
            this.OkayButton.Text = "Принять";
            this.OkayButton.UseVisualStyleBackColor = true;
            // 
            // ParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.PointRadiusTextbox);
            this.Controls.Add(this.CurveWidthTextbox);
            this.Name = "ParamForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CurveWidthTextbox;
        private System.Windows.Forms.TextBox PointRadiusTextbox;
        private System.Windows.Forms.Button OkayButton;
    }
}