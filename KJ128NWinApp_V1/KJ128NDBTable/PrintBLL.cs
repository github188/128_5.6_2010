using System;
using System.Collections.Generic;
using System.Text;
using PrintCore;
using System.Data;
using KJ128NInterfaceShow;
using System.Windows.Forms;

namespace KJ128NDBTable
{
    public class PrintBLL
    {
        static PrintModel model = new PrintModel();
        public static void Print(DataGridViewKJ128 dgv,string title)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("没有数据，无法打印", "提示");
                return;
            }
            DataGridView dgvs = dgv;
            model = GetModel.getMode(dgvs, title, "");//获得打印参数
            FormPrint print = new FormPrint(model);
            print.CallPrintForm(dgv, title, "");
        }

        public static void Print(DataGridViewKJ128 dgv, string title,string strSum)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("没有数据，无法打印", "提示");
                return;
            }
            DataGridView dgvs = dgv;
            model = GetModel.getMode(dgvs, title, strSum);//获得打印参数
            FormPrint print = new FormPrint(model);
            print.CallPrintForm(dgv, title, strSum);
        }

        public static void Print(System.Windows.Forms.DataGridView dgv, string title)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("没有数据，无法打印", "提示");
                return;
            }
            model = GetModel.getMode(dgv, title,"");//获得打印参数
            FormPrint print = new FormPrint(model);
            print.CallPrintForm(dgv, title,"");
        }

        public static void Print(System.Windows.Forms.DataGridView dgv, string title, string strSum)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("没有数据，无法打印", "提示");
                return;
            }
            model = GetModel.getMode(dgv, title, strSum);//获得打印参数
            FormPrint print = new FormPrint(model);
            print.CallPrintForm(dgv, title, strSum);
        }

        public static void PrintSet(System.Windows.Forms.DataGridView dgv, string title, string strSum)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("没有数据，无法选择输出格式", "提示");
                return;
            }
            model = GetModel.getMode(dgv, title, strSum);//获得打印参数
            Frm_Print_Set cs = new Frm_Print_Set(model, title);
            cs.ShowDialog();
        }
        public static void PrintSet128(DataGridViewKJ128 dgv, string title, string strSum)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("没有数据，无法选择输出格式", "提示");
                return;
            }
            DataGridView dgvs = dgv;
            model = GetModel.getMode(dgvs, title, strSum);//获得打印参数
            Frm_Print_Set cs = new Frm_Print_Set(model, title);
            cs.ShowDialog();
        }

        
        
    }
}
