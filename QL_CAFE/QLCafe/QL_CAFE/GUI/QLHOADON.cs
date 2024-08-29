using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace GUI
{
    public partial class QLHOADON : Form
    {
        public QLHOADON()
        {
            InitializeComponent();
        }
        CAFEDAL dal = new CAFEDAL();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        public void loaddata()
        {
            dataGridView1.DataSource = dal.gethoadon();
            txt_tongdt.Text = dal.gettongdt().ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = dal.getcthd(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            mahd = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void QLHOADON_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dal.gethoadontheongay(dateTimePicker1.Value);
        }
        public int mahd = 0;
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (mahd == 0)
            {
                MessageBox.Show("Vui long chon 1 hoadon");
            }
            else
            {
                if (MessageBox.Show("XÓA HÓA ĐƠN " + mahd + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dal.xoaHD(mahd) == true)
                    {
                        MessageBox.Show("Xoa thanh cong");
                        loaddata();
                    }
                    else
                        MessageBox.Show("Xoa that bai");
                }

            }
        }
    }
}
