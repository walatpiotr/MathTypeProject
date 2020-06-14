using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        private List<string> packages = new List<string>();
        private Dictionary<string, string> packageDictionary = new Dictionary<string, string>();
        EquationToLaTeXConverter form;
        bool visible = false;
        string second_file_path;

        public WordDocumentParser(string inputFilePath, EquationToLaTeXConverter form)
        {
            this.form = form;
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
            
            

            if (form.checkBox1.Checked == true)
            {
                this.app.Visible = true;
                Console.WriteLine("pokazuje");
                this.visible = true;

            }
            if (form.checkBox1.Checked == false)
            {
                this.app.Visible = false;
                //this.app.DisplayAlerts = 0;
                Console.WriteLine("nie pokazuje");
                this.visible = false;
            }

            

            this.docOpen = app.Documents.Open(inputFilePath, Visible: visible);

           

            this.myRange = docOpen.Range();

            packageDictionary.Add("AMS", @"\usepackage{amssymb}");
            packageDictionary.Add("INT", @"\usepackage{esint}");
            packageDictionary.Add("FDS", @"\usepackage{fdsymbol}");
            packageDictionary.Add("STX", @"\usepackage{stix}");
            packageDictionary.Add("TEX", @"\usepackage{textcomp}");
            packageDictionary.Add("GEN", @"\usepackage{gensymb}");
            packageDictionary.Add("COL", @"\usepackage{colonequals}");
            packageDictionary.Add("FRM", @"\usepackage{framed}");

            object isVisible = true;
            File.SetAttributes(inputFilePath, FileAttributes.Normal);
            this.second_file_path = this.inputFileDir + this.inputFileName.Substring(0, inputFileName.IndexOf('.')) + @"_converted.docx";
            docOpen.Activate();
            /*if(form.checkBox2.Checked == false)
            {
                myRange.Copy();
                docOpen.Close();
                
                this.docOpen = app.Documents.Open(second_file_path, Visible: visible, ReadOnly: false);
                docOpen.Range().Paste();
                docOpen.SaveAs();
                docOpen.Close();
                

                this.docOpen = app.Documents.Open(second_file_path, Visible: visible);
                this.myRange = docOpen.Range();
            }*/
        }

        public void findMathTypeEquations()
        {
            Word.Shapes objects = docOpen.Shapes;
            foreach (Word.Shape shape in objects)
            {
                Console.WriteLine(shape.TextFrame);
            }

            int OMathsCount = myRange.OMaths.Count;
            Console.WriteLine(OMathsCount);
            Console.WriteLine("Bar max:");

            form.progressBar1.Maximum = OMathsCount;


            try
            {
                String clipboard_memory = Clipboard.GetText();
                Word.Range endRange = docOpen.Range(myRange.End - 1, myRange.End - 1);



                if (OMathsCount > 0)
                {
                    string final_eq_file_path_clear = this.inputFileDir + @"\EquationsFile.txt";
                    File.WriteAllText(final_eq_file_path_clear, String.Empty);

                    string temp_file_path = this.inputFileDir + @"\EquationTemporaryFile.txt";
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(temp_file_path))
                    
                    {
                        int offset = 1;
                        bool empty_eq_fl;
                        bool break_for_fl = false;
                        for (int i = 0; i < OMathsCount && offset <= myRange.OMaths.Count; i++)
                        {
                            empty_eq_fl = true;
                            Thread staThread = new Thread(
                            delegate ()
                            {
                                Word.OMath currentEquation = myRange.OMaths[offset];
                                while (empty_eq_fl)
                                {
                                    try
                                    {
                                        currentEquation.Range.Select();

                                        currentEquation.Range.TextRetrievalMode.IncludeHiddenText = true;
                                        currentEquation.Range.TextRetrievalMode.IncludeFieldCodes = true;

                                        currentEquation.Range.Application.Selection.Copy();
                                        empty_eq_fl = false;
                                    }
                                    catch (System.Runtime.InteropServices.COMException ex)
                                    {
                                        if (offset <= myRange.OMaths.Count - 1)
                                        {
                                            offset++;
                                            currentEquation = myRange.OMaths[offset];
                                        }
                                        else
                                        {
                                            break_for_fl = true;
                                            break;
                                        }
                                    }
                                }
                                if (!break_for_fl)
                                {
                                    //currentEquation.Range.Application.Selection.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;
                                    String tekst = Clipboard.GetText();
                                    String new_tekst = "$";
                                    /////////////////////////////////////////////////////////////////////////////////////

                                    char[] tokens = tekst.ToCharArray();
                                    string[] parsed = TranslateTokensToTex(tokens);
                                    for (int p = 0; p < parsed.Length; p++)
                                    {
                                        Console.Write(parsed[p] + "^.^");
                                    }
                                    Console.WriteLine("---------------------------------------------------");
                                    for (int p = 0; p < parsed.Length; p++)
                                    {
                                        parsed[p] = ParseToken(ref parsed, p);
                                    }
                                    for (int p = 0; p < parsed.Length; p++)
                                    {
                                        if (parsed[p] != @"")
                                        {
                                            new_tekst += parsed[p];
                                        }
                                    }
                                    new_tekst += "$";
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    file.WriteLine(tekst);

                                    string final_eq_file_path = this.inputFileDir + @"\EquationsFile.txt";
                                    using (System.IO.StreamWriter file2 = File.AppendText(final_eq_file_path))
                                    {
                                        file2.WriteLine(new_tekst);
                                    }

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

                                    if (new_tekst != "$$")
                                    {
                                        currentEquation.Range.InsertBefore(new_tekst);
                                    }
                                }
                            });

                            staThread.SetApartmentState(ApartmentState.STA);
                            staThread.Start();
                            staThread.Join();
                            form.progressBar1.PerformStep();
                            if (break_for_fl)
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No equations found.");
                }

				    if (form.checkBox2.Checked == false)
					 {
						  docOpen.SaveAs(second_file_path);
					 }
					 else
					 {
				        docOpen.SaveAs();
					 }
					 docOpen.Close();
					 app.Quit();

                string final_message = "Process Completed\n\nFile \"EquationsFile.txt\" containing all converted equations and needed packages.\n";
                if(packages.Count != 0)
                {
                    final_message += "Additional packages required for further use:\n";
                    string final_eq_file_path = this.inputFileDir + @"\EquationsFile.txt";
                    using (System.IO.StreamWriter file2 = File.AppendText(final_eq_file_path))
                    {
                        file2.WriteLine("\n" + @"\usepackage{amsmath}");
                        foreach (string pack in packages)
                        {
                            final_message += pack;
                            final_message += "\n";
                            file2.WriteLine(pack);
                        }
                    }
                }
                MessageBox.Show(final_message);

            }
            catch (Exception)
            {
                throw;
            }


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
            int additional_signs_count = 1;
            if (parsed[p] == @"\bar{\bar{}}")
            {
                additional_signs_count = 2;
            }
            else if (parsed[p] == @"\frac{}{}")
            {
                additional_signs_count = 3;
            }
            parsed[p] = parsed[p].Substring(0, parsed[p].Length - additional_signs_count);
            int temp_idx = p - 1;
            while (parsed[temp_idx] == @"" || parsed[temp_idx] == @" ")
            {
                if(parsed[temp_idx] == @" ")
                {
                    parsed[temp_idx] = @"";
                }
                temp_idx--;
            }
            int last_idx = temp_idx;
            if (parsed[temp_idx] == ")")
            {
                int par_count = 1;
                temp_idx--;
                while(par_count != 0)
                {
                    if (parsed[temp_idx] == ")")
                    {
                        par_count++;
                    }
                    else if (parsed[temp_idx] == "(")
                    {
                        par_count--;
                    }
                    temp_idx--;
                }
                temp_idx++;
            }
            else if (additional_signs_count == 3)
            {
                while(temp_idx >= 0 && parsed[temp_idx] != " ")
                {
                    temp_idx--;
                }
                temp_idx++;
            }

            for(int i = temp_idx; i <= last_idx; i++)
            {
                parsed[p] += parsed[i];
                parsed[i] = @"";
            }

            parsed[p] += @"}";
            if(additional_signs_count == 2)
            {
                parsed[p] += @"}";
            }
            else if (additional_signs_count == 3)
            {
                parsed[p] += @"{}";
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
                while (temp_idx < parsed.Length && parsed[temp_idx] != @"^{}" && parsed[temp_idx] != @"_{}" && parsed[temp_idx] != @" " && parsed[temp_idx] != "big operator separator" && parsed[temp_idx] != ")")
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
            if (index == 0 || parsed[index-1] == @"" || !(Char.IsLetter(parsed[index-1].ToCharArray()[0])))
            {
                if (letters_left >= 2)
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
                                else if (parsed[index + 2] == "t")
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
                    if (parsed[index] == "l" && parsed[index + 1] == "n")
                    {
                        changed_to_function = true;
                        parsed[index] = @"\ln";
                        parsed[index + 1] = @"";
                    }
                }
            }

            if (changed_to_function)
            {
                int temp_idx = index+1;
                while(parsed[temp_idx] == @"" || parsed[temp_idx] == " ")
                {
                    temp_idx++;
                }

                if (parsed[temp_idx] == @"^{}")
                {
                    parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    parsed[index] += parsed[temp_idx];
                    parsed[temp_idx] = @"";
                    temp_idx++;
                    while (parsed[temp_idx] == @"" || parsed[temp_idx] == @" ")
                    {
                        temp_idx++;
                    }
                    if (parsed[temp_idx] == ")")
                    {
                        parsed[temp_idx] = @"";
                        parsed[index - 1] = @"";
                        temp_idx++;
                    }
                }
                if (parsed[temp_idx] == @"_{}")
                {
                    parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    parsed[index] += parsed[temp_idx];
                    parsed[temp_idx] = @"";
                    while (parsed[temp_idx] == @"" || parsed[temp_idx] == @" ")
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

        private string ParseMatrix(ref string[] parsed, int index)
        {
            string ending;
            if(index != 0)
            {
                switch (parsed[index - 1])
                {
                    case "(":
                        parsed[index] = @"\begin{pmatrix} ";
                        ending = @" \end{pmatrix}";
                        break;
                    case "[":
                        parsed[index] = @"\begin{bmatrix} ";
                        ending = @" \end{bmatrix}";
                        break;
                    case @"\{":
                        parsed[index] = @"\begin{Bmatrix} ";
                        ending = @" \end{Bmatrix}";
                        break;
                    case "|":
                        parsed[index] = @"\begin{vmatrix} ";
                        ending = @" \end{vmatrix}";
                        break;
                    case @"\|":
                        parsed[index] = @"\begin{Vmatrix} ";
                        ending = @" \end{Vmatrix}";
                        break;
                    default:
                        parsed[index] = @"\begin{matrix} ";
                        ending = @" \end{matrix}";
                        break;
                }
                parsed[index - 1] = @"";
            }
            else
            {
                parsed[index] = @"\begin{matrix} ";
                ending = @" \end{matrix}";
            }

            parsed[index + 1] = @"";
            int temp_idx = index + 2;
            int par_count = 1;
            while(!(par_count == 1 && parsed[temp_idx-1] == ")"))
            {
                int i = temp_idx;
                while(parsed[temp_idx] != "&" && parsed[temp_idx] != "@" && !(par_count == 1 && parsed[temp_idx] == ")"))
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
                for(; i < temp_idx; i++)
                {
                    parsed[index] += parsed[i];
                    parsed[i] = @"";
                }
                if (parsed[temp_idx] == "&")
                {
                    parsed[index] += " ";
                    parsed[index] += parsed[temp_idx];
                    parsed[temp_idx] = @"";
                    parsed[index] += " ";
                }
                else if (parsed[temp_idx] == "@")
                {
                    parsed[index] += @"\\ ";
                    parsed[temp_idx] = @"";
                }
                temp_idx++;
            }
            parsed[index] += ending;
            parsed[temp_idx - 1] = @"";
            if(temp_idx < parsed.Length)
            {
                parsed[temp_idx] = @"";
            }  
            return parsed[index];
        }

        private string ParseFraction(ref string[] parsed, int index)
        {
            parsed[index] = ParseBackwards(ref parsed, index);
            parsed[index] = ParseGenericTokenWithCurlyBraces(ref parsed, index);
            return parsed[index];
        }

        private string ParseNewton(ref string[] parsed, int index)
        {
            int temp_idx = index - 1;
            int par_count = 0;
            while(parsed[temp_idx] != " ")
            {
                if (IsRightPar(parsed[temp_idx]))
                {
                    par_count++;
                }
                else if (IsLeftPar(parsed[temp_idx]))
                {
                    par_count--;
                    if (par_count < 0)
                    {
                        temp_idx--;
                        break;
                    }
                }
                temp_idx--;
            }

            if (IsLeftPar(parsed[temp_idx + 1]))
            {
                parsed[temp_idx + 1] = @"";
            }

            parsed[index] = parsed[index].Substring(1, parsed[index].Length - 1);
            for (int i = index - 1; i > temp_idx; i--)
            {
                parsed[index] = parsed[i] + parsed[index];
                parsed[i] = @"";
            }
            parsed[index] = "{" + parsed[index];



            temp_idx = index + 1;
            par_count = 0;
            while (parsed[temp_idx] != " ")
            {
                if (IsLeftPar(parsed[temp_idx]))
                {
                    par_count++;
                }
                else if (IsRightPar(parsed[temp_idx]))
                {
                    par_count--;
                    if (par_count < 0)
                    {
                        temp_idx++;
                        break;
                    }
                }
                temp_idx++;
            }

            if (IsRightPar(parsed[temp_idx - 1]))
            {
                parsed[temp_idx - 1] = @"";
            }

            parsed[index] = parsed[index].Substring(0, parsed[index].Length - 1);
            for (int i = index + 1; i < temp_idx; i++)
            {
                parsed[i] = ParseToken(ref parsed, i);
            }
            for (int i = index + 1; i < temp_idx; i++)
            {
                parsed[index] += parsed[i];
                parsed[i] = @"";
            }
            parsed[index] += "}";

            return parsed[index];
        }

        private string ParseParenthesisOperator(ref string[] parsed, int index)
        {
            if (index + 7 < parsed.Length && parsed[index+1] == "(" && parsed[index+2] == "2" && parsed[index+3] == "4" && parsed[index+4] == "&")
            {
                parsed[index] = @"\, d" + parsed[index + 6];
                for (int i = index + 1; i <= index + 7; i++)
                {
                    parsed[i] = @"";
                }
            }
            else if (index + 6 < parsed.Length && parsed[index+1] == "(")
            {
                parsed[index + 1] = @"";
                int par_count = 1;
                int temp_idx = index + 2;

                while(par_count != 0)
                {
                    if (parsed[temp_idx] == "(")
                    {
                        par_count++;
                    }
                    else if (parsed[temp_idx] == ")")
                    {
                        par_count--;
                    }
                    else if (parsed[temp_idx] == "text above" || parsed[temp_idx] == "text below")
                    {
                        parsed[temp_idx] = ParseAboveBelow(ref parsed, temp_idx, true);
                    }
                    else
                    {
                        parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    }
                    temp_idx++;
                }
                parsed[temp_idx - 1] = @"";

                parsed[index] = @"";
            }
            else
            {
                parsed[index] = @"";
            }
            return parsed[index];
        }

        private string ParseAboveBelow(ref string[] parsed, int index, bool in_par)
        {
            string ending = @"{";
            string middle = @"";
            if (parsed[index] == "text above")
            {
                parsed[index] = @"\overset{";
            }
            else if (parsed[index] == "text below")
            {
                parsed[index] = @"\underset{";
            }

            if(index != 0)
            {
                int temp_idx = index - 1;
                while(temp_idx > 0 && parsed[temp_idx] == @"")
                {
                    temp_idx--;
                }
                ending += parsed[temp_idx];
                parsed[temp_idx] = @"";
            }
            ending += @"}";

            if(index != parsed.Length - 1 && parsed[index+1] == "(")
            {
                parsed[index + 1] = @"";
                int temp_idx = index + 2;
                int par_count = 1;
                while (!(par_count == 1 && parsed[temp_idx] == ")"))
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
                for (int i = index + 2; i < temp_idx; i++)
                {
                    middle += parsed[i];
                    parsed[i] = @"";
                }
                parsed[temp_idx] = @"";
            }
            else if (in_par)
            {
                int temp_idx = index;
                while(temp_idx < parsed.Length && parsed[temp_idx] != ")")
                {
                    parsed[temp_idx] = ParseToken(ref parsed, temp_idx);
                    temp_idx++;
                }
                for(int i = index + 1; i < temp_idx; i++)
                {
                    middle += parsed[i];
                    parsed[i] = @"";
                }
            }
            else
            {
                middle = ParseToken(ref parsed, index + 1);
                parsed[index + 1] = @"";
            }
            middle += @"}";

            parsed[index] = parsed[index] + middle + ending;
            return parsed[index];
        }

        private string ParseBigCurly(ref string[] parsed, int index)
        {
            bool curly_fl = false;
            if(index != 0 && parsed[index - 1] == @"\{")
            {
                parsed[index - 1] = @"";
                parsed[index] = @"\begin{cases} ";
                curly_fl = true;
            }
            else
            {
                parsed[index] = @"";
            }
            parsed[index + 1] = @"";
            int temp_idx = index + 2;
            int par_count = 1;
            while (!(par_count == 1 && parsed[temp_idx - 1] == ")"))
            {
                int i = temp_idx;
                while (parsed[temp_idx] != "&" && parsed[temp_idx] != "@" && !(par_count == 1 && parsed[temp_idx] == ")"))
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
                for (; i < temp_idx; i++)
                {
                    parsed[index] += parsed[i];
                    parsed[i] = @"";
                }
                if (parsed[temp_idx] == "&")
                {
                    parsed[index] += " ";
                    parsed[index] += parsed[temp_idx];
                    parsed[temp_idx] = @"";
                    parsed[index] += " ";
                }
                else if (parsed[temp_idx] == "@")
                {
                    parsed[index] += @"\\ ";
                    parsed[temp_idx] = @"";
                }
                temp_idx++;
            }
            if (curly_fl)
            {
                parsed[index] += @" \end{cases}";
                parsed[temp_idx] = @"";
            }
            parsed[temp_idx - 1] = @"";
            
            return parsed[index];
        }

        private string ParseToken(ref string[] parsed, int index)
        {
            Regex package_header = new Regex(@"^PACK[A-Z]{3}.*$");
            if(package_header.IsMatch(parsed[index]))
            {
                string package = parsed[index].Substring(4, 3);
                package = packageDictionary[package];

                if (!(packages.Contains(package)))
                {
                    packages.Add(package);
                }

                parsed[index] = parsed[index].Substring(7, parsed[index].Length - 7);
                return ParseToken(ref parsed, index);
            }
            else if (parsed[index] == @"\sqrt[]{}")
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
            else if (parsed[index] == @"\frac{}{}")
            {
                return ParseFraction(ref parsed, index);
            }
            else if (parsed[index] == @"{ \choose }")
            {
                return ParseNewton(ref parsed, index);
            }
            else if (parsed[index] == "big operator separator")
            {
                return @"";
            }
            else if (parsed[index] == "expect matrix")
            {
                return ParseMatrix(ref parsed, index);
            }
            else if (parsed[index] == "expect parenthesis")
            {
                return ParseParenthesisOperator(ref parsed, index);
            }
            else if (parsed[index] == "expect big curly")
            {
                return ParseBigCurly(ref parsed, index);
            }
            else if (parsed[index] == "text above" || parsed[index] == "text below")
            {
                return ParseAboveBelow(ref parsed, index, false);
            }
            else if (BackwardsRequired(parsed[index]))
            {
                return ParseBackwards(ref parsed, index);
            }
            else if (parsed[index] != @"" && Char.IsLetter(parsed[index].ToCharArray()[0]))
            {
                return ParseLetter(ref parsed, index);
            }
            else if (parsed[index] == @"^{}" || parsed[index] == @"_{}")
            {
                return ParseSubSup(ref parsed, index);
            }
            else if (parsed[index] == "big operator separator")
            {
                return @"";
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

        private bool IsLeftPar(string s)
        {
            if (s == "(" || s == "[" || s == @"\{" || s == @"\langle " || s == @"\lfloor " || s == @"\lceil " || s == @"\|" || s == @"\lBrack")
                return true;
            return false;
        }

        private bool IsRightPar(string s)
        {
            if (s == ")" || s == "]" || s == @"\}" || s == @"\rangle " || s == @"\rfloor " || s == @"\rceil " || s == @"\|" || s == @"\rBrack")
                return true;
            return false;
        }

        public void parse() {}
        
    }
}