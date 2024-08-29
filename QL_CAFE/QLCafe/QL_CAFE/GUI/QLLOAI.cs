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
    public partial class QLLOAI : Form
    {
        public QLLOAI()
        {
            InitializeComponent();
        }
        CAFEDAL dal = new CAFEDAL();
        public void loaddata()
        {
            dataGridView1.DataSource = dal.getloaisp();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_ten.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else
            {
                LOAISANPHAM n = new LOAISANPHAM();
                n.TENLOAI = txt_ten.Text;
                if (dal.themLoai(n) == true)
                {
                    MessageBox.Show("Them thanh cong");
                    loaddata();
                }
                else
                    MessageBox.Show("Them that bai");
            }
        }

        private void QLLOAI_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text == "")
            {
                MessageBox.Show("Vui long chon 1 Loại để xóa");
            }
            else
            {
                if (MessageBox.Show("XÓA LOẠI MẶT HÀNG " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dal.xoaLoai(int.Parse(txt_ma.Text)) == true)
                    {
                        MessageBox.Show("Xoa thanh cong");
                        loaddata();
                    }
                    else
                        MessageBox.Show("Xoa that bai");
                }

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text == "")
            {
                MessageBox.Show("Vui long chon 1 LOẠI!!");
            }
            else
            {
                txt_ten.Focus();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SỬA LOẠI " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dal.suaLoai(int.Parse(txt_ma.Text), txt_ten.Text) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    loaddata();
                }
                else
                    MessageBox.Show("Sua that bai");
            }
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
