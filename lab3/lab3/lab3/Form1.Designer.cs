namespace lab3
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
            this.PointsButton = new System.Windows.Forms.Button();
            this.ParametersButton = new System.Windows.Forms.Button();
            this.CurveButton = new System.Windows.Forms.Button();
            this.BrokenLineButton = new System.Windows.Forms.Button();
            this.BezierButton = new System.Windows.Forms.Button();
            this.FillCurveButton = new System.Windows.Forms.Button();
            this.MovingButton = new System.Windows.Forms.Button();
            this.CleanButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PointsButton
            // 
            this.PointsButton.Location = new System.Drawing.Point(41, 45);
            this.PointsButton.Name = "PointsButton";
            this.PointsButton.Size = new System.Drawing.Size(124, 34);
            this.PointsButton.TabIndex = 0;
            this.PointsButton.Text = "Точки";
            this.PointsButton.UseVisualStyleBackColor = true;
            // 
            // ParametersButton
            // 
            this.ParametersButton.Location = new System.Drawing.Point(41, 85);
            this.ParametersButton.Name = "ParametersButton";
            this.ParametersButton.Size = new System.Drawing.Size(124, 34);
            this.ParametersButton.TabIndex = 1;
            this.ParametersButton.Text = "Параметры";
            this.ParametersButton.UseVisualStyleBackColor = true;
            // 
            // CurveButton
            // 
            this.CurveButton.Location = new System.Drawing.Point(41, 125);
            this.CurveButton.Name = "CurveButton";
            this.CurveButton.Size = new System.Drawing.Size(124, 34);
            this.CurveButton.TabIndex = 2;
            this.CurveButton.Text = "Кривая";
            this.CurveButton.UseVisualStyleBackColor = true;
            // 
            // BrokenLineButton
            // 
            this.BrokenLineButton.Location = new System.Drawing.Point(41, 165);
            this.BrokenLineButton.Name = "BrokenLineButton";
            this.BrokenLineButton.Size = new System.Drawing.Size(124, 34);
            this.BrokenLineButton.TabIndex = 3;
            this.BrokenLineButton.Text = "Ломанная";
            this.BrokenLineButton.UseVisualStyleBackColor = true;
            // 
            // BezierButton
            // 
            this.BezierButton.Location = new System.Drawing.Point(41, 205);
            this.BezierButton.Name = "BezierButton";
            this.BezierButton.Size = new System.Drawing.Size(124, 34);
            this.BezierButton.TabIndex = 4;
            this.BezierButton.Text = "Безье";
            this.BezierButton.UseVisualStyleBackColor = true;
            // 
            // FillCurveButton
            // 
            this.FillCurveButton.Location = new System.Drawing.Point(41, 245);
            this.FillCurveButton.Name = "FillCurveButton";
            this.FillCurveButton.Size = new System.Drawing.Size(124, 34);
            this.FillCurveButton.TabIndex = 5;
            this.FillCurveButton.Text = "Заполненная";
            this.FillCurveButton.UseVisualStyleBackColor = true;
            // 
            // MovingButton
            // 
            this.MovingButton.Location = new System.Drawing.Point(41, 285);
            this.MovingButton.Name = "MovingButton";
            this.MovingButton.Size = new System.Drawing.Size(124, 34);
            this.MovingButton.TabIndex = 6;
            this.MovingButton.Text = "Движение";
            this.MovingButton.UseVisualStyleBackColor = true;
            // 
            // CleanButton
            // 
            this.CleanButton.Location = new System.Drawing.Point(41, 325);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(124, 34);
            this.CleanButton.TabIndex = 7;
            this.CleanButton.Text = "Очистить";
            this.CleanButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(41, 365);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(124, 34);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.MovingButton);
            this.Controls.Add(this.FillCurveButton);
            this.Controls.Add(this.BezierButton);
            this.Controls.Add(this.BrokenLineButton);
            this.Controls.Add(this.CurveButton);
            this.Controls.Add(this.ParametersButton);
            this.Controls.Add(this.PointsButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PointsButton;
        private System.Windows.Forms.Button ParametersButton;
        private System.Windows.Forms.Button CurveButton;
        private System.Windows.Forms.Button BrokenLineButton;
        private System.Windows.Forms.Button BezierButton;
        private System.Windows.Forms.Button FillCurveButton;
        private System.Windows.Forms.Button MovingButton;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button SaveButton;
    }
}

