using System;
using System.IO;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.InteropServices.Marshalling;

public static class PathFinderLoader //Dataset for MSPathFinderT
{
    public static void MSPathFinderSetup(string exePath, string spectraPath, string dataPath, string outPath)
    {
        exePath = @"" + exePath;
        spectraPath = @"" + spectraPath;
        dataPath = @"" + dataPath;
        outPath = @"" + outPath;
        string exeParams = " -s " + "\"" + spectraPath + "\"" + " -d " + "\"" + dataPath + "\"" + " -o " + "\"" + outPath + "\"" +
                           " -ic 2 -f 20 -MinLength 7 -MaxLength 1000000 -MinCharge 1 -MaxCharge 60 -MinFragCharge 1 -MaxFragCharge 10 -MinMass 0 -MaxMass 30000 -tda 1";
       var process = new Process
       {
           StartInfo =
           {
               FileName = exePath,
               WorkingDirectory = Path.GetDirectoryName(exePath),
               Arguments = exeParams,
           }

       };
       process.Start();
       
       process.WaitForExit();


    }
    
    public static void MSPathFinderSetup(string exePath, string spectraPath, string dataPath)//no output, data stored and accessed by this class, not user. 
    {
        string outputDir = Path.GetDirectoryName(@"" + spectraPath); //suppose we've made a .tsv file here. spectraPath.raw -> spectraPath.tsv
        string tsvPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(spectraPath) + ".tsv"); //spectraPath.tsv stored into string format
        try
        {
            using (StreamReader reader = new StreamReader(tsvPath))
            {
                reader.ReadLine(); //theory is that this gets rid of headers, but idek what the tsv file looks like so unsure.
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine(); // Read each line
                    string[] columns = line.Split('\t'); // Split by tab

                    // Example: Print each column
                    Console.WriteLine(string.Join(", ", columns));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(tsvPath);
        }



        MSPathFinderSetup(exePath, spectraPath, dataPath, outputDir);
    } 

}