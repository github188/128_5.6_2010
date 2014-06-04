using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class Graphics_ConfigFileBLL
    {
        private Graphics_ConfigFileDAL gcfd = new Graphics_ConfigFileDAL();
        public DataTable GetAllFileName()
        {
            return gcfd.GetAllFileName();
        }

        public void AddFile(string filename, byte[] xmlbyte, byte[] imgbyte)
        {
            gcfd.AddFile(filename, xmlbyte, imgbyte);
        }

        public bool ExitsFile(string filename)
        {
            return gcfd.ExitsFileName(filename);
        }

        public void UpdateFile(string filename, byte[] xmlbyte, byte[] imgbyte)
        {
            gcfd.UpdateFile(filename, xmlbyte, imgbyte);
        }

        public DataTable GetXmlAndMapByFileName(string filename)
        {
            return gcfd.GetXmlAndMapByFileName(filename);
        }

        public void RemoveFile(string filename)
        {
            gcfd.RemoveFile(filename);
        }
    }
}
