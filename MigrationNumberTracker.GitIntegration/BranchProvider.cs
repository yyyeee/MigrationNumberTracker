using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MigrationNumberTracker.GitIntegration
{
    public class BranchProvider
    {
        public string SolutionDir { get; set; }

        public IEnumerable<string> GetAllRemoteBranches()
        {
            var cmdScriptDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(SolutionDir);
            var cmdScriptFile = Path.Combine(cmdScriptDir, "getAllRemoteBranches.cmd");
            var scriptLength = File.ReadAllLines(cmdScriptFile).Length;
            var process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    
                    FileName = Path.Combine(cmdScriptDir, "getAllRemoteBranches.cmd")
                }
            };
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var outputLines = output.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            process.WaitForExit();
            outputLines.RemoveAt(0); // removing starting empty line in console
            for (int i = 0; i < scriptLength; ++i)
            {
                outputLines.RemoveAt(0); // removing script itself
            }

            return outputLines;
        }
    }
}
