/*using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.InteropServices.Marshalling;
class Program
{
    static void Main(String[] args) //TODO change to argument pathways, NO QUOTES ANYWHERE but EXEPARAMS
    {
        string exePath = @"C:\Program Files\Informed-Proteomics\MSPathFinderT"; //NO QUOTES IN CONSOLE.READLINE
        string spectraPath = @"C:\Users\avnib\Desktop\SEOutput\RAW\02-17-20_jurkat_td_rep2_fract3.raw"; //my answer: with quotes. We'll see though
        string datPath = @"C:\Users\avnib\Desktop\Databases\uniprotkb_accession_Q9Y6W6_OR_accession_2025_03_12.fasta"; 
        string output = @"Z:\Users\Avni\SEOutput\MsPathFinderT";
        string exeParams = " -s " + "\"" + spectraPath + "\"" + " -d " + "\"" + datPath + "\"" + " -o " + "\""+ output + "\"" +
                           " -ic 2 -f 20 -MinLength 7 -MaxLength 1000000 -MinCharge 1 -MaxCharge 60 -MinFragCharge 1 -MaxFragCharge 10 -MinMass 0 -MaxMass 30000 -tda 1";
        string exeDir = Path.GetDirectoryName(exePath);
        Console.WriteLine(""); //test
        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = exePath,
            Arguments = exeParams,
            WorkingDirectory = exeDir,
        };
        using (Process process = new Process() { StartInfo = start })
        {
            process.Start();
         //   Console.WriteLine(process.StandardError.ReadLine());
            process.WaitForExit();


        }

    }
    
}*/
class Program
{
    public static void Main()
    {
        string exePath = @"C:\Program Files\Informed-Proteomics\MSPathFinderT"; //NO QUOTES IN CONSOLE.READLINE
        string spectraPath = @"C:\Users\avnib\Desktop\SEOutput\RAW\Ecoli_SEC4_F6.raw"; //my answer: with quotes. We'll see though
        string datPath = @"Z:\RawSpectraFiles\Ecoli_SEC_CZE\uniprot-proteome UP000000625.fasta";
        string output = @"C:\Users\avnib\Desktop\SEOutput\MST"; 

        PathFinderLoader.MSPathFinderSetup(exePath, spectraPath, datPath,output);
    }



}