using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PoweTCP.Vert.Classes
{
    public static class MockAttachmentCreator
    {
        private static string FileNameBase() => "attachment";
        private static string FileExtension() => ".txt";
        private static IReadOnlyCollection<int> Sequence() => new List<int> { 1, 2, 3 };

        /// <summary>
        /// 
        /// </summary>
        /// <returns>filePath</returns>
        public static string CreateSingleTextFile() 
        {
            return Create(FileNameBase());
        }

        public static IEnumerable<string> CreateTextFiles()
        {
            var fileNames = new System.Collections.Generic.List<string>();
            Sequence().ToList().ForEach(f =>
            {
                fileNames.Add(Create($@"{FileNameBase()}{f}"));
            });

            return fileNames;
        }

        private static string Create(string _sourceName) 
        {
            var fileCompletePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, $@"{_sourceName}_{DateTime.Now.ToString("hhmmss")}{FileExtension()}");
            var stream = System.IO.File.CreateText(fileCompletePath);
            stream.Write($"text_{_sourceName}");
            stream.Close();

            return fileCompletePath;
        }
    }
}
