using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Bowling.Output
{
    /// <summary>
    /// PDFOutput using HTMLoutput to create pdf
    /// </summary>
    public class PDFOutput: HTMLOutput
    {
        /// <summary>
        /// First create html and next create pdf document
        /// </summary>
        /// <param name="bowlings">Collection of BowlingScore</param>
        /// <param name="output">Filename to save</param>
        /// <returns>Output</returns>
        public new dynamic CreateOutput(ref ICollection<BowlingScore> bowlings, string output)
        {
            CreateOutputFromTemplate(ref bowlings);
            CreatePDFFromHTML();
            if (CreateFileOutput)
            {
                SaveToFile(output);
            }

            return Output;
        }
        
        /// <summary>
        /// Save pdf to file
        /// </summary>
        /// <param name="filename"></param>
        public new void SaveToFile(string filename)
        {
            if (Output != null && Output is PdfDocument)
            {
                try
                {
                    Output.Save(filename);
                }
                catch (Exception ex)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Can not save pdf to file with filename: " + filename);
                    Console.ForegroundColor = color;
                }
            }
        }

        /// <summary>
        /// Create pdf documunet from html code
        /// </summary>
        protected void CreatePDFFromHTML()
        {

            Output = PdfGenerator.GeneratePdf(Output, PageSize.A4);
        }

    }
}
