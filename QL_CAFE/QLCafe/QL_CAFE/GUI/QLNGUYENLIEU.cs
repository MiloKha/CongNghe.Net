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
using System.Globalization;
namespace GUI
{
    public partial class QLNGUYENLIEU : Form
    {
        CAFEDAL cf = new CAFEDAL();
        public QLNGUYENLIEU()
        {
            InitializeComponent();
        }
        public void loaddata()
        {
            dataGridView1.DataSource = cf.getnguyenlieu();
        }
        public void loadcb()
        {
            cb_ncc.DataSource = cf.getncc();
            cb_ncc.DisplayMember = "TENNCC";
            cb_ncc.ValueMember = "MANCC";
        }
        private void QLNGUYENLIEU_Load(object sender, EventArgs e)
        {
            loaddata();
            loadcb();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_ten.Text == "" || txt_sl.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else
            {
                NGUYENLIEU n = new NGUYENLIEU();
                n.TENNL = txt_ten.Text;
                n.SOLUONG = int.Parse(txt_sl.Text);
                n.MANCC = int.Parse(cb_ncc.SelectedValue.ToString());
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                string dateString = formattedDate;
                DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                n.CAPNHATNGAY = date;
                if (cf.themNL(n) == true)
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
                MessageBox.Show("Vui long chon 1 Nguyên liệu để xóa");
            }
            else
            {
                if (MessageBox.Show("XÓA NGUYÊN LIỆU " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (cf.xoaNV(int.Parse(txt_ma.Text)) == true)
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
                MessageBox.Show("Vui long chon 1 NGUYÊN LIỆU!!");
            }
            else
            {
                txt_ten.Focus();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SỬA NGUYÊN LIỆU " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                string dateString = formattedDate;
                DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (cf.suaNL(int.Parse(txt_ma.Text), txt_ten.Text, int.Parse(txt_sl.Text), int.Parse(cb_ncc.SelectedValue.ToString()), date) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    loaddata();
                }
                else
                    MessageBox.Show("Sua that bai");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_sl.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cb_ncc.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
