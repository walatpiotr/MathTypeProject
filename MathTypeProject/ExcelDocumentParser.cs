using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace MathTypeProject
{
    internal class ExcelDocumentParser : OfficeDocumentParser
    {
        private string inputFileDir;
        private string inputFileName;
        Microsoft.Office.Interop.Excel.Application app;
        Microsoft.Office.Interop.Excel.Workbook xlsOpen;
        

        public List<Object> mathTypeEquations = new List<Object>();
        Excel.Range myRange;


        

        public ExcelDocumentParser(string inputFilePath)
        {
            char[] separator = { '\\' };
            string[] directories = inputFilePath.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string dir = "";
            for (int i = 0; i < directories.Length - 1; i++)
            {
                dir += directories[i] + '\\';
            }
            this.inputFileDir = dir;
            this.inputFileName = directories[directories.Length - 1];
            Console.WriteLine(inputFileName);
            this.myRange = xlsOpen.Worksheets[1].Range["A1", "ZZ1000"];


            this.app = new Excel.Application();
            this.xlsOpen = app.Workbooks.Open(inputFilePath);
            object isVisible = true;
            File.SetAttributes(inputFilePath, FileAttributes.Normal);

            xlsOpen = this.app.Workbooks.Open(inputFilePath); // ---, Visible: isVisible
            xlsOpen.Activate();

        }

        public void findMathTypeEquations()
        {
            Thread staThread = new Thread(
            delegate ()
            {
                try
                {
                    String clipboard_memory = Clipboard.GetText();
                    Excel.Range endRange = xlsOpen.Worksheets[1].Range["A1","ZZ1000"];

                    int OMathsCount = myRange.OMaths.Count;
                    Console.WriteLine(OMathsCount);

                    if (OMathsCount > 0)
                    {
                        string temp_file_path = this.inputFileDir + @"\EquationTemporaryFile.txt";
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(temp_file_path))
                        {
                            for (int i = 1; i <= OMathsCount; i++)
                            {
                                //myRange.OMaths[i].ConvertToNormalText();
                                Word.OMath currentEquation = myRange.OMaths[i];

                                currentEquation.Range.Select();

                                currentEquation.Range.TextRetrievalMode.IncludeHiddenText = true;
                                currentEquation.Range.TextRetrievalMode.IncludeFieldCodes = true;

                                // @Diagnostic
                                currentEquation.Range.Application.Selection.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;

                                currentEquation.Range.Application.Selection.Copy();


                                String tekst = Clipboard.GetText();
                                /////////////////////////////////////////////////////////////////////////////////////

                                char[] tokens = tekst.ToCharArray();
                                string[] parsed = parseTokensToMSEq(tokens);
                                foreach (string p in parsed)
                                {
                                    Console.WriteLine(p);
                                }
                                Console.WriteLine("koniec");


                                /////////////////////////////////////////////////////////////////////////////////////
                                file.WriteLine(tekst);
                                if (clipboard_memory.CompareTo("") != 0)
                                {
                                    Clipboard.SetText(clipboard_memory);
                                }
                                else
                                {
                                    Clipboard.Clear();
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No equations found.");
                    }

                    MessageBox.Show("Process Completed");
                }
                catch (Exception)
                {
                    throw;
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();

        }
        public void parse()
        {
            this.mathTypeEquations = null;
        }
    }
}