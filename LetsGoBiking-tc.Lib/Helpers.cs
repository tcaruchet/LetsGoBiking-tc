﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.Lib
{
    public static class Helpers
    {
        public static void Log(string message, 
            [CallerMemberName] string member = null!, 
            [CallerFilePath] string file = null!, 
            [CallerLineNumber] int line = 0)
        {
            var fmt = $"[{DateTime.Now}] [{Path.GetFileName(file)}:{line,2}] [{member}] {message}";
            Debug.WriteLine(fmt);
            Console.WriteLine(fmt);
        }

        public static void StartService<T>()
        {
            var svc = new ServiceHost(typeof(T));
            svc.Open();

            Log($"Starting service {typeof(T).Name}");
            Log($"Listening on {string.Join(", ", svc.BaseAddresses.Select(u => u.ToString()))}");
            Log("Press <enter> to stop");
            Console.ReadLine();
        }
    }
}
