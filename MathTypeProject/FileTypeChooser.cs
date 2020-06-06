using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathTypeProject
{
    class FileTypeChooser
    {
        
        public FileTypeChooser(string arg,  EquationToLaTeXConverter form)
        {
            //Console.WriteLine("Insert document path: \n");
            string inputFilePath = arg;
            Console.WriteLine(inputFilePath);
            char[] separator = { '\\' };
            char[] separator2 = { '.' };
            string[] directories = inputFilePath.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] filename_extension = directories[directories.Length - 1].Split(separator2);
            //Console.WriteLine("Write 1 if Word document: \nWrite 2 if Excel document: \nWrite 3 if PowerPoint document: \n");
            //string fileTypeString = Console.ReadLine();
            //int fileType = int.Parse(fileTypeString);
            
            


            switch (filename_extension[1])
            {
                case "ppt":
                case "pptx":
                    PowerPointDocumentParser document2 = new PowerPointDocumentParser(inputFilePath,  form);
                    document2.findMathTypeEquations();
                    break;

                case "doc":
                case "docx":
                    WordDocumentParser document1 = new WordDocumentParser(inputFilePath, form);
                    document1.findMathTypeEquations();
                    break;

                default:
                    MessageBox.Show("File type not supported");

                    break;
            }
            
        }
    }
}
