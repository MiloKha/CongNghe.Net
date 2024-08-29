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
    public partial class QLNCC : Form
    {
        public QLNCC()
        {
            InitializeComponent();
        }
        CAFEDAL dal = new CAFEDAL();
        public void loaddata()
        {
            dataGridView1.DataSource = dal.getncc();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_ten.Text == "" || txt_sdt.Text == "" || txt_dc.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else
            {
                NHACUNGCAP n = new NHACUNGCAP();
                n.TENNCC = txt_ten.Text;
                n.DIACHI = txt_dc.Text;
                n.SDT = txt_sdt.Text;
                if (dal.themNCC(n) == true)
                {
                    MessageBox.Show("Them thanh cong");
                    loaddata();
                }
                else
                    MessageBox.Show("Them that bai");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text == "")
            {
                MessageBox.Show("Vui long chon 1 Loại để xóa");
            }
            else
            {
                if (MessageBox.Show("XÓA NHÀ CUNG CẤP " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dal.xoaNCC(int.Parse(txt_ma.Text)) == true)
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
                MessageBox.Show("Vui long chon 1 NHÀ CUNG CÂP!!");
            }
            else
            {
                txt_ten.Focus();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SỬA NHÀ CUNG CẤP " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dal.suaNCC(int.Parse(txt_ma.Text), txt_ten.Text,txt_sdt.Text,txt_dc.Text) == true)
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

        private void QLNCC_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_dc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
