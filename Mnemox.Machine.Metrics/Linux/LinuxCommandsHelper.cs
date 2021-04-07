using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCommandsHelper : ILinuxCommandsHelper
    {
        #region consts

        private const string BASH_FILE_NAME = "/bin/bash";

        #endregion

        public string ExecuteBashCommand(string arguments)
        {
            var output = "";

            var info = new ProcessStartInfo()
            {
                FileName = BASH_FILE_NAME,

                Arguments = arguments,

                RedirectStandardOutput = true
            };

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            return output;
        }
    }
}
