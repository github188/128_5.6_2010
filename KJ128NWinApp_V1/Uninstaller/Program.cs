using System;
using System.Collections.Generic;
using System.Text;

namespace Uninstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Diagnostics.Process.Start("msiexec", "/X{652AB376-43B4-411C-9E8D-3531B6B872CE}");
            System.Diagnostics.Process.Start("msiexec", "/X{652AB376-43B4-411C-9E8D-3531B6B872CE}");
        }
    }
}
