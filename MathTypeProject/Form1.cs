using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathTypeProject
{
    public partial class EquationToLaTeXConverter : Form
    {
        public static string passingText;
        public int amount = 0;
        public EquationToLaTeXConverter()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "docx",
                //Filter = "docx files (*.docx)|*.docx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            string passingText = textBox1.Text;
            if (checkBox1.Checked == true)
            {
                FileTypeChooser program = new FileTypeChooser(passingText, this);

            }
            else
            {
                FileTypeChooser program = new FileTypeChooser(passingText, this);
            }


            
            



            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
