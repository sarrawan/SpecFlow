﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TechTalk.SpecFlow.Specs.Drivers
{
    public class ProcessHelper
    {
        public string GetCurrentAssemblyFolder()
        {
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Debug.Assert(assemblyFolder != null);
            return assemblyFolder;
        }

        public int RunProcess(string executablePath, string argumentsFormat, params object[] arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo(executablePath, string.Format(argumentsFormat, arguments));
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            var p = Process.Start(psi);

            Console.WriteLine(p.StandardOutput.ReadToEnd());

            p.WaitForExit();

            return p.ExitCode;
        }
    }
}