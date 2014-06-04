using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using KJ128NInterfaceShow;

namespace PrintCore
{
    /// <summary>
    /// �ֶκͱ����е�ӳ����
    /// </summary>
    public class FieldMappingColumn
    {
        /// <summary>
        /// ����Դ�ֶ�
        /// </summary>
        private string filed;
        /// <summary>
        /// ����Դ�ֶ�
        /// </summary>
        public string Filed
        {
            get { return filed; }
            set { filed = value; }
        }

        /// <summary>
        /// ��������ʾ������
        /// </summary>
        private string columnName;
        /// <summary>
        /// ��������ʾ������
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// �ڱ������г���
        /// </summary>
        private string columnWidth;
        /// <summary>
        /// �ڱ������г���
        /// </summary>
        public string ColumnWidth
        {
            get { return columnWidth; }
            set { columnWidth = value; }
        }

        /// <summary>
        /// ��ʾ�����Ƿ�ɼ�
        /// </summary>
        private bool visible = true;
        /// <summary>
        /// ��ʾ�����Ƿ�ɼ�
        /// </summary>
        public bool Visible 
        {
            get { return visible; }
            set { visible = value; }
        }
    }

    /// <summary>
    /// ��ӡ����ӿ�
    /// </summary>
    public interface IPrintComponent
    {
        #region [��ʱ]

        /// <summary>
        /// �жϱ���ģ���Ƿ���ع�
        /// </summary>
        //bool IsTemplateFileLoaded { get;}

        /// <summary>
        /// ���ر���ģ��
        /// </summary>
        /// <param name="path">����ģ��·��</param>
        //void LoadTemplateFile(string path);

        /// <summary>
        /// ������ӡ����
        /// </summary>
        /// <param name="dt">DataTable����Դ</param>
        /// <param name="mappings">�ֶζ�Ӧ�����е�ӳ��</param>
        /// <param name="printParams">�������� �������� 
        /// ��һ��Dataset�����������
        /// �ڶ��Ǵ�ӡ����
        /// �����Ǵ�ӡ����
        /// </param>
        //void CallPrintForm(DataTable dt, Collection<FieldMappingColumn> mappings, params object[] printParams);

        #endregion

        #region [Common parts]

        /// <summary>
        /// ������ӡ����
        /// </summary>
        /// <param name="dgv">Ҫ��ӡ��DataGridView�ؼ�</param>
        /// <param name="title">��ӡ����</param>
        /// <param name="sum">��������</param>
        //void CallPrintForm( DataGridViewKJ128 dgv, string title,string sum);


        /// <summary>
        /// ������ӡ����
        /// </summary>
        /// <param name="dgv">Ҫ��ӡ��DataGridView�ؼ�</param>
        /// <param name="title">��ӡ����</param>
        /// <param name="sum">��������</param>
        /// <param name="isAutoPrint">�Ƿ��Զ���ӡ</param>
        //void CallPrintForm(DataGridViewKJ128 dgv, string title, string sum, bool isAutoPrint);

        /// <summary>
        /// ������ӡ����
        /// </summary>
        /// <param name="dgv">Ҫ��ӡ��DataGridView�ؼ�</param>
        /// <param name="title">��ӡ����</param>
        /// <param name="sum">��������</param>
        void CallPrintForm(DataGridView dgv, string title, string sum);

        /// <summary>
        /// ������ӡ����
        /// </summary>
        /// <param name="dgv">Ҫ��ӡ��DataGridView�ؼ�</param>
        /// <param name="title">��ӡ����</param>
        /// <param name="sum">��������</param>
        /// <param name="isAutoPrint">�Ƿ��Զ���ӡ</param>
        void CallPrintForm(DataGridView dgv, string title, string sum, bool isAutoPrint);



        #endregion
    }
}
