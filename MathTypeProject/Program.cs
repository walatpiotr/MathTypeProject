using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTypeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert document path: \n");
            string inputFilePath = Console.ReadLine();
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
                    break;

                default:
                    WordDocumentParser document1 = new WordDocumentParser(inputFilePath);
                    document1.findMathTypeEquations();

                    break;
            }
            while (true)
            {

            }



        }
    }
}