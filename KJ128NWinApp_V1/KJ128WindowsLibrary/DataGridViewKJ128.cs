using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace KJ128NInterfaceShow
{
    /// <summary>
    /// DataGridViewKJ128Style��ʽ
    /// </summary>
    public enum DataGridViewKJ128Style
    {
        /// <summary>
        /// windows Ĭ�Ͽ��ӻ�Ч��
        /// </summary>
        WindowsStyle,
        /// <summary>
        ///��ɫ
        /// </summary>
        GreenStyle,
        /// <summary>
        /// KJ70���
        /// </summary>
        KJ70Style,
        /// <summary>
        /// ��ɫ���
        /// </summary>
        BlueStyle,
        /// <summary>
        /// ����ʽ
        /// </summary>
        None
    }
    /// <summary>
    /// �̳�DataGridView
    /// </summary>
    public class DataGridViewKJ128 : DataGridView
    {
        #region ˽�б���

        private DataGridViewKJ128Style dgvKJ128Style = DataGridViewKJ128Style.WindowsStyle;

        #endregion

        #region  ���캯��
        /// <summary>
        ///  ���캯��
        /// </summary>
        public DataGridViewKJ128()
            : base()
        {
            //InitDataGridViewKJ128();
            //MouseWheel += DataGridViewKJ128_MouseWheel;
            Scroll += DataGridViewKJ128_Scroll;
        }

        void DataGridViewKJ128_Scroll(object sender, ScrollEventArgs e)
        {
            Focus();
        }

        //void DataGridViewKJ128_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    Update();
        //}

        #endregion

        #region ����
        private void SetShowStyle()
        {
            switch(dgvKJ128Style)
            {
                case DataGridViewKJ128Style.WindowsStyle:
                    {
                        this.EnableHeadersVisualStyles = true;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("����", 10, System.Drawing.FontStyle.Bold,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region ���
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(197, 197, 197);//������ɫ
                        this.BackgroundColor = Color.FromArgb(244, 244, 244);//����
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);//����ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//�е�ǰ��ɫ
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//�� ������ɫ

                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//ѡ��ı���ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//ǰ��ɫ
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//ѡ���ǰ��ɫ
                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.GreenStyle:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("����", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region ���
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        this.BackColor = Color.FromArgb(231, 241, 251);
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(197, 197, 197);//������ɫ
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//����
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231,241,251);//����ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//�е�ǰ��ɫ
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//����ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//ǰ��ɫ
                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(49, 106, 197);//ѡ��ı���ɫ
                        
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(255,255,255);//ѡ���ǰ��ɫ

                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(39,163,91);//���ⱳ��ɫ
                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255,255,255);//����ǰ��ɫ
                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.KJ70Style:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("����", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region ���
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(197, 197, 197);//������ɫ
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//����
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//�еı���ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 128, 0);//�е�ǰ��ɫ

                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//�� ������ɫ

                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//ѡ��ı���ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//ǰ��ɫ
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//ѡ���ǰ��ɫ

                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 217);//���ⱳ��ɫ

                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 255);//����ǰ��ɫ

                        this.RowHeadersVisible = true;

                        this.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 217);
                        this.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 255);//����ǰ��ɫ

                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.BlueStyle:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("����", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region ���
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        
                        //this.BackColor = Color.FromArgb(231, 241, 251);
                        this.BackColor = Color.FromArgb(255, 255, 255);

                        this.BorderStyle = BorderStyle.Fixed3D;
                        //this.GridColor = Color.FromArgb(184,191,219);//������ɫ
                        this.GridColor = Color.FromArgb(117, 154, 198);//������ɫ
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//����
                        //this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//����ɫ
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(249, 255, 255);//����ɫ

                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//�е�ǰ��ɫ
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//����ɫ
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//�� ������ɫ
                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//ѡ��ı���ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//ǰ��ɫ
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//ѡ���ǰ��ɫ

                        //this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);//���ⱳ��ɫ
                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(236, 251, 248);//���ⱳ��ɫ
                        //this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);//����ǰ��ɫ
                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0,0);//����ǰ��ɫ

                        this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //����ߵ�ģʽ
                        

                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.None:
                    {
                        break;
                    }
            }
        }

        private void InitDataGridViewKJ128()
        {
            
            #region ��������
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            
            this.ReadOnly = false;
            this.RowHeadersVisible = false;//��������ͷ
            #endregion
            #region ���
            //this.BorderStyle = BorderStyle.Fixed3D;
            //this.GridColor = Color.FromArgb(197, 197, 197);//������ɫ
            //this.BackgroundColor = this.BackgroundColor = Color.FromArgb(244, 244, 244);//����
            //this.RowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);//����ɫ
            //this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//�� ������ɫ

            //this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//ѡ��ı���ɫ
            //this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//ǰ��ɫ
            //this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//ѡ���ǰ��ɫ
            #endregion
            #region �б���
            if (!this.EnableHeadersVisualStyles)
            {
                this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(221, 231, 238);
                this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(62, 22, 110);
            }
            this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("����", 10, System.Drawing.FontStyle.Bold,
              System.Drawing.GraphicsUnit.Point, (byte)(134));
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 32;
            this.ReadOnly = true;
            #endregion
        }
        #endregion

        #region ����
        /// <summary>
        /// �趨����趨��ʽ
        /// </summary>
        [Category("��չ������"), Description("�Ƿ����ֱ���ڴ�����ҷģʽ")]
        public DataGridViewKJ128Style DataGridShowStype
        {
            get
            {
                return dgvKJ128Style;
            }
            set
            {
                dgvKJ128Style = value;
                SetShowStyle();
            }
        }
        /// <summary>
        /// ��ȡ��ֱ��������ֵ
        /// </summary>
        [Category("��չ������"), Description("��ȡ��ֱ��������ֵ")]
        public int VerticalScrollBarValue
        {
            get
            {
                return this.VerticalScrollBar.Value;
            }
            set
            {
                this.VerticalScrollBar.Value = value;
            }

        }

        /// <summary>
        /// ��ȡ��ֱ������������
        /// </summary>
        [Category("��չ������"), Description("��ȡ��ֱ������������")]
        public int VerticalScrollBarMax
        {
            get 
            {
                return this.VerticalScrollBar.Maximum;
            }
            set 
            {
                this.VerticalScrollBar.Maximum = value;
            }
        }
        #endregion

        #region blue


        /*
         * case DataGridViewKJ128Style.BlueStyle:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("����", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region ���
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        this.BackColor = Color.FromArgb(231, 241, 251);
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(184,191,219);//������ɫ
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//����
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//����ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//�е�ǰ��ɫ
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//����ɫ
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//�� ������ɫ
                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//ѡ��ı���ɫ
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//ǰ��ɫ
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//ѡ���ǰ��ɫ

                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);//���ⱳ��ɫ
                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);//����ǰ��ɫ

                        this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //����ߵ�ģʽ
                        

                        #endregion
                        break;
                    }
         * 
         */

        #endregion
    }
}
