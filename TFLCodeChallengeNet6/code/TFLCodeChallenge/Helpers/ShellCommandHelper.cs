using System.Diagnostics;

namespace TFLCodeChallengeSpecs.Helpers
{
    public static class ShellCommandHelper
    {
        public static string Execute(string fileName, string arguments)
        {
            string output = string.Empty;
            string error = string.Empty;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                // Synchronously read the standard output of the spawned process. 
                error = process.StandardError.ReadToEnd();
                output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
            }

            if (!string.IsNullOrWhiteSpace(error))
            {
                throw new Exception(error);
            }

            return output;
        }
    }
}
