using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace MathTypeProject
{
    internal class ExcelDocumentParser
    {
        private string inputFilePath;
        Microsoft.Office.Interop.Excel.Application app;
        Microsoft.Office.Interop.Excel.Workbook xclOpen;
        public List<Object> mathTypeEquations;

        public ExcelDocumentParser(string inputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.app = new Excel.Application();
            this.xclOpen = app.Workbooks.Open(this.inputFilePath);

        }

        public void findMathTypeEquations()
        {

        }
    }
}