using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NMainRun
{
    public class ConfigXmlWiter
    {
        public static void Write(string filename)
        {
            try
            {
                string DirectoryPath = System.Windows.Forms.Application.StartupPath + "\\Config";
                if (!System.IO.Directory.Exists(DirectoryPath))
                {
                    System.IO.Directory.CreateDirectory(DirectoryPath);
                }
                System.IO.FileStream fs = new System.IO.FileStream(DirectoryPath + "\\" + filename, System.IO.FileMode.OpenOrCreate);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            { }
        }
    }
}
