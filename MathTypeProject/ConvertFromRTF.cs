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
    internal class ConvertFromRTF
    {
        public ConvertFromRTF(string inputFilePath)
        {
            // If your RTF file isn't in the same folder as the .exe file for the project,  
            // specify the path to the file in the following assignment statement.  
            string path = inputFilePath;

            //Create the RichTextBox. (Requires a reference to System.Windows.Forms.)
            System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

            // Get the contents of the RTF file. When the contents of the file are   
            // stored in the string (rtfText), the contents are encoded as UTF-16.  
            string rtfText = System.IO.File.ReadAllText(path);

            // Display the RTF text. This should look like the contents of your file.
            System.Windows.Forms.MessageBox.Show(rtfText);
            
            // Use the RichTextBox to convert the RTF code to plain text.
            rtBox.Rtf = rtfText;
            string plainText = rtBox.Text;

            // Display the plain text in a MessageBox because the console can't   
            // display the Greek letters. You should see the following result:  
            //   The Greek word for "psyche" is spelled ψυχή. The Greek letters are
            //   encoded in Unicode. 
            //   These characters are from the extended ASCII character set (Windows 
            //   code page 1252): âäӑå
            System.Windows.Forms.MessageBox.Show(plainText);

            // Output the plain text to a file, encoded as UTF-8. 
            System.IO.File.WriteAllText((@"output.txt"), plainText);
        }
    }
}