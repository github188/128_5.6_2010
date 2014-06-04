using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDBTable
{
    public class A_GraphicsBLL
    {
        private KJ128NDataBase.A_GraphicsDAL dal = new KJ128NDataBase.A_GraphicsDAL();

        public void InsertBackMap(string filename, byte[] buffer)
        {
            dal.DelBackMap();
            dal.InsertBackMap(filename, buffer);
        }

        public byte[] GetBackMapByFileName(string filename)
        {
            return dal.GetBackMapByFileName(filename);
        }

        public DataTable GetBackMap()
        {
            return dal.GetBackMap();
        }

        public int GetFlashTime()
        {
            return dal.GetFlashTime();
        }
    }
}
