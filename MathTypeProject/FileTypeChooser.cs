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
        
        public FileTypeChooser(string arg)
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
                    PowerPointDocumentParser document2 = new PowerPointDocumentParser(inputFilePath);
                    document2.findMathTypeEquations();
<<<<<<< HEAD:MathTypeProject/Program.cs
=======
                    Console.WriteLine("tadam!");
                    break;

                case "doc":
                case "docx":
                    WordDocumentParser document1 = new WordDocumentParser(inputFilePath);
                    document1.findMathTypeEquations();

>>>>>>> 2bd5e6455504c229cedf528064d7b495f0ffaa62:MathTypeProject/FileTypeChooser.cs
                    break;

                default:
                    MessageBox.Show("File type not supported");

                    break;
            }
            
        }
    }
}
