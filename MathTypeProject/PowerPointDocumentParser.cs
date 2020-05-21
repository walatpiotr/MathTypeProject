using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.IO;

namespace MathTypeProject
{
    internal class PowerPointDocumentParser : OfficeDocumentParser
    {
        private string inputFilePath;
        Microsoft.Office.Interop.PowerPoint.Application app;
        Microsoft.Office.Interop.PowerPoint.Presentation pptOpen;
        public List<Object> mathTypeEquations;

        public PowerPointDocumentParser(string inputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.app = new PowerPoint.Application();
            this.pptOpen = app.Presentations.Open(this.inputFilePath);

        }

        public void findMathTypeEquations()
        {

        }
        public void parse()
        {
            this.mathTypeEquations = null;
        }
    }
}