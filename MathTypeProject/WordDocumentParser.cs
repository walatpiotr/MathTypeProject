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
        private string inputFileDir;
        private string inputFileName;
        Microsoft.Office.Interop.Word.Application app;
        Microsoft.Office.Interop.Word.Document docOpen;
        public List<Object> mathTypeEquations = new List<Object>();
        Word.Range myRange;


        public WordDocumentParser(string inputFilePath)
        {
            char[] separator = { '\\' };
            string[] directories = inputFilePath.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string dir = "";
            for(int i = 0; i < directories.Length-1; i++)
            {
                dir += directories[i] + '\\';
            }
            this.inputFileDir = dir;
            this.inputFileName = directories[directories.Length - 1];
            this.app = new Word.Application();
            this.docOpen = app.Documents.Open(inputFilePath);
            this.myRange = docOpen.Range();

            object isVisible = true;
            File.SetAttributes(inputFilePath, FileAttributes.Normal);

            docOpen = this.app.Documents.Open(inputFilePath, Visible: isVisible);
            docOpen.Activate();
        }

        public void findMathTypeEquations()
        {
            Thread staThread = new Thread(
            delegate ()
            {
                try
                {
                    String clipboard_memory = Clipboard.GetText();
                    Word.Range endRange = docOpen.Range(myRange.End - 1, myRange.End - 1);

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
                                foreach(string p in parsed)
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
        private string[] parseTokensToMSEq(char[] tokens)
        {
            int iterator = 0;
            string[] new_tokens = new string[tokens.Length];

            while(iterator < tokens.Length)
            {
                switch (tokens[iterator])
                {
                    case '√':
                        new_tokens[iterator] = @"\sqrt{";
                        break;
                    default:
                        new_tokens[iterator] = tokens[iterator].ToString();
                        break;
                }
                iterator++;
            }
            return new_tokens;
        }

        public void parse() {}
        
    }
}