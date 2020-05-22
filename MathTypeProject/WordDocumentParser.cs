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
        public List<Object> mathTypeEquations = new List<Object>();
        Word.Range myRange;


        public WordDocumentParser(string inputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.app = new Word.Application();
            this.docOpen = app.Documents.Open(this.inputFilePath);
            int start = 0;
            int stop = 40;
            this.myRange = docOpen.Range(start,stop);

            object isVisible = true;
            File.SetAttributes(inputFilePath, FileAttributes.Normal);

            docOpen = this.app.Documents.Open(inputFilePath, Visible: isVisible);
            docOpen.Activate();
        }

        public void findMathTypeEquations()
        {


            try
            {
                int inlineShapesCount = myRange.InlineShapes.Count;
                Console.WriteLine(inlineShapesCount);

                if (inlineShapesCount > 0)
                {
                    for (int i = 1; i <= inlineShapesCount; i++)
                    {
                        Word.InlineShape currentShape = myRange.InlineShapes[i];
                        Word.Range currentShapeRange = currentShape.Range;
                        Word.WdInlineShapeType typeOfCurrentShape = currentShape.Type;

                        if (typeOfCurrentShape != Word.WdInlineShapeType.wdInlineShapeEmbeddedOLEObject)
                        {
                            continue;
                            Console.WriteLine("Jestem w innym obiekcie niz chcemy");
                        }

                        if (!currentShape.Field.Code.Text.Trim().ToLower().Contains("equation"))
                        {
                            continue;
                            Console.WriteLine("equation");

                        }

                        currentShapeRange.Select();
                        currentShapeRange.Application.Selection.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;
                    }
                }

                //MessageBox.Show("Process Completed");

            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public void parse()
        {
            this.mathTypeEquations = null;
        }

        
    }
}