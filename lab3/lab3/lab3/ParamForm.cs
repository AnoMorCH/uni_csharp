using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class ParamForm : Form
    {
        Form1 parentForm;

        public ParamForm(Form1 parentForm)
        {
            InitializeComponent();

            Width = 400;
            Height = 600;

            OkayButton.Click += ParamFormIsSent;

            this.parentForm = parentForm;
        }

        private bool AreTextboxesEmpty(List<TextBox> texBoxes)
        { 
            foreach (TextBox textBox in texBoxes) 
            { 
                if (textBox.Text.Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void ShowSystemFormatExceptionMessage()
        {
            string title = "Предупреждение";
            string message = "Пожалуйста, введите целочисленные данные в предложенные поля.";
            MessageBox.Show(message, title);
        }

        private void ParamFormIsSent(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox> { CurveWidthTextbox, PointRadiusTextbox };
            if (!AreTextboxesEmpty(textBoxes))
            {
                try
                {
                    this.parentForm.curveWidth = int.Parse(CurveWidthTextbox.Text);
                    this.parentForm.pointRadius = int.Parse(PointRadiusTextbox.Text);
                    this.Close();
                }
                catch (System.FormatException)
                {
                    ShowSystemFormatExceptionMessage();
                }
            }
            else
            {
                ShowSystemFormatExceptionMessage();
            }
        }
    }
}
