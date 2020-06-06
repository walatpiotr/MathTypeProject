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
            Console.WriteLine(inputFileName);
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
            Word.Shapes objects = docOpen.Shapes;
            foreach (Word.Shape shape in objects)
            {
                Console.WriteLine(shape.TextFrame);
            }
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
                            while (myRange.OMaths.Count != 0)
                            {
                                Word.OMath currentEquation = myRange.OMaths[1];

                                currentEquation.Range.Select();

                                currentEquation.Range.TextRetrievalMode.IncludeHiddenText = true;
                                currentEquation.Range.TextRetrievalMode.IncludeFieldCodes = true;

                                currentEquation.Range.Application.Selection.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;

                                currentEquation.Range.Application.Selection.Copy();


                                String tekst = Clipboard.GetText();
                                String new_tekst = "$$";
                                /////////////////////////////////////////////////////////////////////////////////////

                                char[] tokens = tekst.ToCharArray();
                                string[] parsed = TranslateTokensToTex(tokens);
                                for(int p = 0; p < parsed.Length; p++)
                                {
                                    Console.Write(parsed[p]+"^.^");
                                }
                                Console.WriteLine("---------------------------------------------------");
                                for (int p = 0; p < parsed.Length; p++)
                                {
                                    parsed[p] = ParseToken(ref parsed, p);
                                }
                                for (int p = 0; p < parsed.Length; p++)
                                {
                                    if(parsed[p] != @"")
                                    {
                                        new_tekst += parsed[p];
                                    }       
                                }
                                new_tekst += "$$";
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

                                //removing text from start to end
                               
                                int start = currentEquation.Range.Start;
                                int end = currentEquation.Range.End;
                                currentEquation.Range.Application.Selection.Delete();
                                currentEquation.Range.InsertBefore(new_tekst);
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
        private string[] TranslateTokensToTex(char[] tokens)
        {
            int iterator = 0;
            string[] new_tokens = new string[tokens.Length];
            DictionaryWrapper dict = new DictionaryWrapper();

            while(iterator < tokens.Length)
            {
                if(dict.unicodeToLatex.ContainsKey(tokens[iterator]))
                {
                    new_tokens[iterator] = dict.unicodeToLatex[tokens[iterator]];
                }
                else
                {
                    new_tokens[iterator] = tokens[iterator].ToString();
                }
                iterator++;
            }
            return new_tokens;
        }

        private string ParseSqrt(ref string[] parsed, int p)
        {
            if (parsed[p + 1] == "(")
            {
                int amp_idx = 0;
                int par_count = 1;
                int temp_idx = p + 2;
                while (par_count != 0)
                {
                    if (parsed[temp_idx] == "(")
                    {
                        par_count++;
                    }
                    else if (parsed[temp_idx] == ")")
                    {
                        par_count--;
                    }
                    else if (parsed[temp_idx] == "&")
                    {
                        amp_idx = temp_idx;
                        temp_idx = p + 2;
                        parsed[p] = @"\sqrt[";
                        parsed[p + 1] = @"";
                        while (temp_idx != amp_idx)
                        {
                            parsed[p] += parsed[temp_idx];
                            parsed[temp_idx] = @"";
                            temp_idx++;
                        }
                        parsed[temp_idx] = @"";
                        parsed[p] += @"]{}";
                    }
                    else
                    {
                        parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    }
                    temp_idx++;
                }
                parsed[p + 1] = @"";
                parsed[temp_idx - 1] = @"";
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
                if(amp_idx == 0)
                {
                    amp_idx = p + 1;
                }
                for(int idx = amp_idx+1; idx < temp_idx-1; idx++)
                {
                    parsed[p] += parsed[idx];
                    parsed[idx] = @"";
                }
                parsed[p] += @"}";
            }
            else
            {
                int temp_idx = p + 1;
                while(temp_idx < parsed.Length && Char.IsDigit(parsed[temp_idx].ToCharArray()[0]))
                {
                    temp_idx++;
                }
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
                for (int idx = p + 1; idx < temp_idx; idx++)
                {
                    parsed[p] += parsed[idx];
                    parsed[idx] = @"";
                }
                parsed[p] += @"}";
            }
            return parsed[p];
        }

        private string ParseGenericTokenWithCurlyBraces(ref string[] parsed, int p)
        {
            if (parsed[p + 1] == @" ")
                parsed[p + 1] = @"";
            if (parsed[p + 1] == "(")
            {
                int par_count = 1;
                int temp_idx = p + 2;
                while (par_count != 0)
                {
                    if (parsed[temp_idx] == "(")
                    {
                        par_count++;
                    }
                    else if (parsed[temp_idx] == ")")
                    {
                        par_count--;
                    }
                    else
                    {
                        parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    }
                    temp_idx++;
                }
                parsed[p + 1] = @"";
                parsed[temp_idx - 1] = @"";
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
                for (int idx = p + 2; idx < temp_idx - 1; idx++)
                {
                    parsed[p] += parsed[idx];
                    parsed[idx] = @"";
                }
                parsed[p] += @"}";
            }
            else
            {
                int temp_idx = p + 1;
                while (temp_idx < parsed.Length && Char.IsLetterOrDigit(parsed[temp_idx].ToCharArray()[0]))
                {
                    temp_idx++;
                }
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
                for (int idx = p + 1; idx < temp_idx; idx++)
                {
                    parsed[p] += parsed[idx];
                    parsed[idx] = @"";
                }
                parsed[p] += @"}";
            }
            return parsed[p];
        }
        private string ParseBackwards(ref string[] parsed, int p)
        {
            bool nested = false;
            if(parsed[p] == @"\bar{\bar{}}")
            {
                nested = true;
            }
            parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
            if (nested)
            {
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
            }
            int temp_idx = p - 1;
            while (parsed[temp_idx] == @"" || parsed[temp_idx] == @" ")
            {
                if(parsed[temp_idx] == @" ")
                {
                    parsed[temp_idx] = @"";
                }
                temp_idx--;
            }
            parsed[p] += parsed[temp_idx];
            parsed[temp_idx] = @"";
            parsed[p] += @"}";
            if(nested)
            {
                parsed[p] += @"}";
            }
            return parsed[p];
        }

        private string ParseSubSup(ref string[] parsed, int p)
        {
            if (parsed[p + 1] == "(")
            {
                int par_count = 1;
                int temp_idx = p + 2;
                while (par_count != 0)
                {
                    if (parsed[temp_idx] == "(")
                    {
                        par_count++;
                    }
                    else if (parsed[temp_idx] == ")")
                    {
                        par_count--;
                    }
                    else
                    {
                        parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    }
                    temp_idx++;
                }
                parsed[p + 1] = @"";
                parsed[temp_idx - 1] = @"";
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
                for (int idx = p + 2; idx < temp_idx - 1; idx++)
                {
                    parsed[p] += parsed[idx];
                    parsed[idx] = @"";
                }
                parsed[p] += @"}";
                if (temp_idx != parsed.Length && parsed[temp_idx] == "big operator separator")
                {
                    parsed[temp_idx] = @"";
                }
            }
            else
            {
                int temp_idx = p + 1;
                while (temp_idx < parsed.Length && parsed[temp_idx] != @"^{}" && parsed[temp_idx] != "big operator separator")
                {
                    temp_idx++;
                }
                if (temp_idx != parsed.Length && parsed[temp_idx] == "big operator separator")
                {
                    parsed[temp_idx] = @"";
                }
                parsed[p] = parsed[p].Substring(0, parsed[p].Length - 1);
                for (int idx = p + 1; idx < temp_idx; idx++)
                {
                    parsed[p] += parsed[idx];
                    parsed[idx] = @"";
                }
                parsed[p] += @"}";
            }
            return parsed[p];
        }

        private string ParseLetter(ref string[] parsed, int index)
        {
            bool changed_to_function = false;
            int letters_left = parsed.Length - (index + 1);
            if(letters_left >= 2)
            {
                switch (parsed[index])
                {
                    case "c":   //cos, cosh, cot, coth, csc, csch
                        if (parsed[index + 1] == "o")
                        {
                            if (parsed[index + 2] == "s")
                            {
                                if (letters_left > 2 && parsed[index + 3] == "h")
                                {
                                    changed_to_function = true;
                                    parsed[index] = @"\cosh";
                                    parsed[index + 3] = @"";
                                }
                                else
                                {
                                    changed_to_function = true;
                                    parsed[index] = @"\cos";
                                }
                                parsed[index + 1] = @"";
                                parsed[index + 2] = @"";
                            }
                            else if(parsed[index + 2] == "t")
                            {
                                if (letters_left > 2 && parsed[index + 3] == "h")
                                {
                                    changed_to_function = true;
                                    parsed[index] = @"\coth";
                                    parsed[index + 3] = @"";
                                }
                                else
                                {
                                    changed_to_function = true;
                                    parsed[index] = @"\cot";
                                }
                                parsed[index + 1] = @"";
                                parsed[index + 2] = @"";
                            }
                        }
                        else if (parsed[index + 1] == "s" && parsed[index + 2] == "c")
                        {
                            if (letters_left > 2 && parsed[index + 3] == "h")
                            {
                                changed_to_function = true;
                                parsed[index] = @"\text{csch}";
                                parsed[index + 3] = @"";
                            }
                            else
                            {
                                changed_to_function = true;
                                parsed[index] = @"\csc";
                            }
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        break;
                    case "l":   //lim, ln, log
                        if (parsed[index + 1] == "i" && parsed[index + 2] == "m")
                        {
                            changed_to_function = true;
                            parsed[index] = @"\lim";
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        else if (parsed[index + 1] == "n")
                        {
                            changed_to_function = true;
                            parsed[index] = @"\ln";
                            parsed[index + 1] = @"";
                        }
                        else if (parsed[index + 1] == "o" && parsed[index + 2] == "g")
                        {
                            changed_to_function = true;
                            parsed[index] = @"\log";
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        break;
                    case "m":   //max, min
                        if (parsed[index + 1] == "a" && parsed[index + 2] == "x")
                        {
                            changed_to_function = true;
                            parsed[index] = @"\max";
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        else if (parsed[index + 1] == "i" && parsed[index + 2] == "n")
                        {
                            changed_to_function = true;
                            parsed[index] = @"\min";
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        break;
                    case "s":   //sec, sech, sin, sinh
                        if (parsed[index + 1] == "i" && parsed[index + 2] == "n")
                        {
                            if (letters_left > 2 && parsed[index + 3] == "h")
                            {
                                changed_to_function = true;
                                parsed[index] = @"\sinh";
                                 parsed[index + 3] = @"";
                            }
                            else
                            {
                                changed_to_function = true;
                                parsed[index] = @"\sin";
                            }
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        else if (parsed[index + 1] == "e" && parsed[index + 2] == "c")
                        {
                            if (letters_left > 2 && parsed[index + 3] == "h")
                            {
                                changed_to_function = true;
                                parsed[index] = @"\text{sech}";
                                parsed[index + 3] = @"";
                            }
                            else
                            {
                                changed_to_function = true;
                                parsed[index] = @"\sec";
                            }
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        break;
                    case "t":   //tan, tanh
                        if (parsed[index + 1] == "a" && parsed[index + 2] == "n")
                        {
                            if (letters_left > 2 && parsed[index + 3] == "h")
                            {
                                changed_to_function = true;
                                parsed[index] = @"\tanh";
                                parsed[index + 3] = @"";
                            }
                            else
                            {
                                changed_to_function = true;
                                parsed[index] = @"\tan";
                            }
                            parsed[index + 1] = @"";
                            parsed[index + 2] = @"";
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (letters_left == 1)
            {
                if(parsed[index] == "l" && parsed[index+1] == "n")
                {
                    changed_to_function = true;
                    parsed[index] = @"\ln";
                    parsed[index + 1] = @"";
                }
            }

            if (changed_to_function)
            {
                int temp_idx = index+1;
                while(parsed[temp_idx] == @"")
                {
                    temp_idx++;
                }

                if (parsed[temp_idx] == @"^{}")
                {
                    parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    parsed[index] += parsed[temp_idx];
                    parsed[temp_idx] = @"";
                    temp_idx++;
                    if(parsed[temp_idx] == ")")
                    {
                        parsed[temp_idx] = @"";
                        parsed[index - 1] = @"";
                    }
                    while (parsed[temp_idx] == @"" || parsed[temp_idx] == @" ")
                    {
                        temp_idx++;
                    }
                }
                if (parsed[temp_idx] == @"_{}")
                {
                    parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    parsed[index] += parsed[temp_idx];
                    parsed[temp_idx] = @"";
                    while (parsed[temp_idx] == @"")
                    {
                        temp_idx++;
                    }
                }

                parsed[index] += " (";
                if (parsed[temp_idx] == "(")
                {
                    int par_count = 1;
                    parsed[temp_idx] = @"";
                    temp_idx++;
                    if (parsed[temp_idx] == "(")
                    {
                        par_count++;
                        parsed[temp_idx] = @"";
                        temp_idx++;
                    }
                    while(par_count != 0)
                    {
                        if (parsed[temp_idx] == "(")
                        {
                            par_count++;
                        }
                        else if (parsed[temp_idx] == ")")
                        {
                            par_count--;
                            if (par_count == 1 && parsed[temp_idx+1] == ")")
                            {
                                parsed[temp_idx] = @"";
                            }
                        }
                        parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                        parsed[index] += parsed[temp_idx];
                        parsed[temp_idx] = @"";
                        temp_idx++;
                    }
                }
                else
                {
                    while(temp_idx < parsed.Length && parsed[temp_idx] != " ")
                    {
                        parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                        parsed[index] += parsed[temp_idx];
                        parsed[temp_idx] = @"";
                        temp_idx++;
                    }
                    parsed[index] += ")";
                }
            }

            return parsed[index];
        }

        private string ParseToken(ref string[] parsed, int index)
        {
            if (parsed[index] == @"\sqrt[]{}")
            {
                return ParseSqrt(ref parsed, index);
            }
            else if (parsed[index] == @"\cbrt{}" || parsed[index] == @"\qdrt{}" || parsed[index] == @"\overbrace{}" || parsed[index] == @"\brace{}" || parsed[index] == @"\overline{}" || parsed[index] == @"\underline{}")
            {
                return ParseGenericTokenWithCurlyBraces(ref parsed, index);
            }
            else if (parsed[index] == @"^{}" || parsed[index] == @"_{}")
            {
                return ParseSubSup(ref parsed, index);
            }
            else if (parsed[index] == "big operator separator")
            {
                return @"";
            }
            else if (BackwardsRequired(parsed[index]))
            {
                return ParseBackwards(ref parsed, index);
            }
            else if (parsed[index] != @"" && Char.IsLetter(parsed[index].ToCharArray()[0]))
            {
                return ParseLetter(ref parsed, index);
            }
            else
            {
                return parsed[index];
            }
        }

        private bool BackwardsRequired(string s)
        {
            if (s == @"\dot{}" || s == @"\ddot{}" || s == @"\dddot{}" || s == @"\hat{}" || s == @"\check{}" || s == @"\acute{}" || s == @"\grave{}" || s == @"\breve{}" || s == @"\tilde{}" || s == @"\bar{}" || s == @"\bar{\bar{}}" || s == @"\overleftarrow{}" || s == @"\vec{}" || s == @"\overleftrightarrow{}")
                return true;
            return false;
        }

        public void parse() {}
        
    }
}