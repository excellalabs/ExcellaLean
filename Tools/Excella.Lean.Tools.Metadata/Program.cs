namespace Excella.Lean.Core.Models
{
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generating Metadata...");
            var metadata = MetadataGenerator.Instance.Metadata;
            Console.WriteLine("Done");


            Console.WriteLine("Opening Json file...");
            using (var sw = new StreamWriter(MetadataGenerator.Instance.JsonLocation))
            {
                Console.WriteLine("Writing...");
                sw.Write(metadata);
            }

            Console.WriteLine("Done!");            
        }
    }
}