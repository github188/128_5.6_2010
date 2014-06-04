﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace KJ128NMainRun.Graphics.Config
{
    public class FileChanger
    {
        public byte[] XmlToBytes(XmlDocument xmldoc)
        { 
            //Stream stream=new MemoryStream();
            //xmldoc.Save(stream);
            //byte[] xmlbyte = new byte[Convert.ToInt32(stream.Length)];
            //stream.Read(xmlbyte, 0, Convert.ToInt32(stream.Length));
            //return xmlbyte;
            xmldoc.Save(System.Windows.Forms.Application.StartupPath + "\\MapGis\\MapConfigFiles\\Buffer.shz");
            FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + "\\MapGis\\MapConfigFiles\\Buffer.shz", FileMode.Open);
            byte[] xmlbyte = new byte[Convert.ToInt32(fs.Length)];
            fs.Read(xmlbyte, 0, xmlbyte.Length);
            fs.Close();
            return xmlbyte;
        }

        public XmlDocument BytesToXml(byte[] xmlbyte)
        {
            FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + "\\MapGis\\MapConfigFiles\\Buffer.shz", FileMode.Create);
            fs.Write(xmlbyte, 0, xmlbyte.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(System.Windows.Forms.Application.StartupPath + "\\MapGis\\MapConfigFiles\\Buffer.shz");
            return xmldoc;
        }

        public byte[] ImageToBytes(string filapath)
        {
            Stream stream = new FileStream(filapath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            return buffer;
        }

        public Image BytesToImage(byte[] buffer)
        {
            Stream stream = new MemoryStream(buffer);
            Image img = Image.FromStream(stream);
            return img;
        }

        public void CreateFile(string filepath, byte[] filebyte)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate);
            fs.Write(filebyte, 0, filebyte.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        public bool IsValidFileName(string strIn)
        {
            Regex regEx = new Regex("[\\*\\\\/:?<>|\"]");
            return !regEx.IsMatch(strIn);
        }
    }
}
