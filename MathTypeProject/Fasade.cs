using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathTypeProject
{
    class Fasade
    {
        

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            EquationToLaTeXConverter mainForm = new EquationToLaTeXConverter();
            Application.Run(mainForm);
          

        }
    }
}