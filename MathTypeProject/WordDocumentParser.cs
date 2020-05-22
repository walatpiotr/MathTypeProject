using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Windows.Forms;
using System.Threading;

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
            //int start = 0;
            //int stop = 40;
            this.myRange = docOpen.Range();

            object isVisible = true;
            File.SetAttributes(inputFilePath, FileAttributes.Normal);

            docOpen = this.app.Documents.Open(inputFilePath, Visible: isVisible);
            docOpen.Activate();
        }

        public void findMathTypeEquations()
        {


            try
            {
                Word.Range endRange = docOpen.Range(myRange.End-1, myRange.End-1);
                
                int ShapesCount = myRange.ShapeRange.Count;
                Console.WriteLine(ShapesCount);
                int InlineShapesCount = myRange.InlineShapes.Count;
                Console.WriteLine(InlineShapesCount);
                int OMathsCount = myRange.OMaths.Count;
                Console.WriteLine(OMathsCount);

                if (OMathsCount > 0)
                {
                    using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\Piotrek\Documents\WriteLines2.txt"))
                    {
                        for (int i = 1; i <= OMathsCount; i++)
                        {
                            //myRange.OMaths[i].ConvertToNormalText();
                            Word.OMath currentShape = myRange.OMaths[i];


                            Word.WdOMathType typeOfCurrentShape = currentShape.Type;




                            currentShape.Range.Select();



                            currentShape.Range.TextRetrievalMode.IncludeHiddenText = true;
                            currentShape.Range.TextRetrievalMode.IncludeFieldCodes = true;
                            string type = currentShape.Range.TextRetrievalMode.ViewType.ToString();

                            string equation = currentShape.Range.Text;

                            currentShape.Range.Application.Selection.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;
                            currentShape.Range.Application.Selection.Copy();
                            endRange.Select();
                            endRange.Application.Selection.Paste();


                            currentShape.Range.Select();
                            currentShape.Range.Application.Selection.Copy();

                            IDataObject idat = null;
                            Exception threadEx = null;
                            Thread staThread = new Thread(
                                delegate ()
                                {
                                    try
                                    {
                                        String tekst = Clipboard.GetText();
                                        Console.WriteLine(tekst);
                                        file.WriteLine(tekst);
                                    }

                                    catch (Exception ex)
                                    {
                                        threadEx = ex;
                                    }
                                });
                            staThread.SetApartmentState(ApartmentState.STA);
                            staThread.Start();
                            staThread.Join();

                            


                            


                            

                        }


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