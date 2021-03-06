﻿using System.Diagnostics;
using System.Threading.Tasks;

namespace Materal.WindowsHelper
{
    public class CmdManager
    {
        public event DataReceivedEventHandler OutputDataReceived;
        public event DataReceivedEventHandler ErrorDataReceived;
        public async Task<string> RunCmdCommandsAsync(params string[] commands)
        {
            ProcessStartInfo processStartInfo = ProcessManager.GetProcessStartInfo("cmd.exe", string.Empty);
            string output;
            using (var process = new Process { StartInfo = processStartInfo })
            {
                if (OutputDataReceived != null)
                {
                    process.OutputDataReceived += OutputDataReceived;
                }

                if (ErrorDataReceived != null)
                {
                    process.OutputDataReceived += ErrorDataReceived;
                }
                process.Start();
                process.BeginErrorReadLine();//开始异步读取
                foreach (string command in commands)
                {
                    await process.StandardInput.WriteLineAsync(command);
                }
                await process.StandardInput.WriteLineAsync("exit");
                process.StandardInput.AutoFlush = true;
                output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();
                process.Close();
            }
            return output;
        }
    }
}
