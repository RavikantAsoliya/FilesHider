using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
namespace Files_Hider
{
    class SubProcess
    {
        public static void Call(string fileName, string arguments)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = fileName,
                Arguments = arguments,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
            process.WaitForExit();
        }
    }
}
