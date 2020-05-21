using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace MathTypeProject
{
    internal class WordDocumentParser : OfficeDocumentParser
    {
        private string inputFilePath;
        Microsoft.Office.Interop.Word.Application app;
        Microsoft.Office.Interop.Word.Document docOpen;
        public List<Object> mathTypeEquations;

        public WordDocumentParser(string inputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.app = new Word.Application();
            this.docOpen = app.Documents.Open(this.inputFilePath);

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