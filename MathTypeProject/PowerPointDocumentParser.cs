using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Office.Core;

namespace MathTypeProject
{
    internal class PowerPointDocumentParser : OfficeDocumentParser
    {
        private string inputFileDir;
        private string inputFileName;
        Microsoft.Office.Interop.PowerPoint.Application app;
        Microsoft.Office.Interop.PowerPoint.Presentation pptOpen;
        public List<Object> mathTypeEquations = new List<Object>();
        PowerPoint.Slides slides;
        EquationToLaTeXConverter form;

        public PowerPointDocumentParser(string inputFilePath, EquationToLaTeXConverter form)
        {
            this.form = form;

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


            
            this.app = new PowerPoint.Application();

            

            object isVisible = true;
            File.SetAttributes(inputFilePath, FileAttributes.Normal);
            if (form.checkBox1.Checked == false)
            {
                pptOpen = this.app.Presentations.Open(inputFilePath, MsoTriState.msoFalse, MsoTriState.msoFalse,
                WithWindow: MsoTriState.msoFalse); 
            }
            if (form.checkBox1.Checked == true)
            {
                pptOpen = this.app.Presentations.Open(inputFilePath, MsoTriState.msoTrue, MsoTriState.msoTrue,
                WithWindow: MsoTriState.msoTrue);
            }

                //pptOpen.Activate();
                this.slides = pptOpen.Slides;
        }


        public void findMathTypeEquations()
        {

            Thread staThread = new Thread(
                    delegate ()
                    {
                        
                            String clipboard_memory = Clipboard.GetText();
                            //PowerPoint.Range endRange = docOpen.Range(myRange.End - 1, myRange.End - 1);


                            string temp_file_path = this.inputFileDir + @"\EquationTemporaryFile.txt";
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(temp_file_path))

                                foreach (PowerPoint.Slide slide in this.slides)
                                {


                                try
                                {
                                    int count = slide.NotesPage.Shapes.Count;//--[2].TextFrame2.TextRange.MathZones.get_MathZones();
                                    Console.WriteLine(count.ToString());
                                    var strObj = slide.NotesPage.Shapes[2].TextFrame2.TextRange.MathZones.get_MathZones();
                                    for (int i = 0; i<slide.NotesPage.Shapes.Count; i++)
                                    {
                                        Console.WriteLine(slide.NotesPage.Shapes[i].Type);
                                    }
                                        Console.WriteLine("Skopiował jebaniec");
                                        if (strObj != null)
                                        {
                                            
                                            PowerPoint.Shape shape = slide.NotesPage.Shapes[2];
                                            Console.WriteLine("Nie jest null!");

                                            //shape.TextFrame2.TextRange.HighlightColorIndex = PowerPoint.WdColorIndex.wdYellow;
                                            //strObj.Select();
                                            Console.WriteLine("Selected");
                                            //strObj.Copy();
                                     
                                            Console.WriteLine("Skopiował");
                                            String tekst = Clipboard.GetText();
                                            Console.WriteLine("na string");
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


                                }
                       
                    }
                    );
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }


        private string[] parseTokensToMSEq(char[] tokens)
        {
                int iterator = 0;
                string[] new_tokens = new string[tokens.Length];

                while (iterator < tokens.Length)
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
        

        public void parse()
        {
            this.mathTypeEquations = null;
        }
    }
}