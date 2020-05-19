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
            Console.WriteLine("Write 1 if Word document: \nWrite 2 if Excel document: \nWrite 3 if PowerPoint document: \n");
            string fileTypeString = Console.ReadLine();
            int fileType = int.Parse(fileTypeString);

            switch (fileType)
            {
                case 2:
                    ExcelDocumentParser document2 = new ExcelDocumentParser(inputFilePath);
                    document2.findMathTypeEquations();

                    break;

                case 3:
                    PowerPointDocumentParser document3 = new PowerPointDocumentParser(inputFilePath);
                    document3.findMathTypeEquations();

                    break;

                default:
                    WordDocumentParser document1 = new WordDocumentParser(inputFilePath);
                    document1.findMathTypeEquations();

                    break;
            }




        }
    }
}