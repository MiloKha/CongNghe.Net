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
using System.IO;
namespace GUI
{
    public partial class QLMATHANG : Form
    {
        public QLMATHANG()
        {
            InitializeComponent();
        }
        CAFEDAL dal = new CAFEDAL();
        public void loaddata()
        {
            dataGridView1.DataSource = dal.getmathang();
        }
        public void loadcb()
        {
            cb_loai.DataSource = dal.getloaisp();
            cb_loai.DisplayMember = "TENLOAI";
            cb_loai.ValueMember = "MALOAI";

            cb_nl.DataSource = dal.getnguyenlieu();
            cb_nl.DisplayMember = "TENNL";
            cb_nl.ValueMember = "MANL";
        }
        private void QLMATHANG_Load(object sender, EventArgs e)
        {
            loaddata();
            loadcb();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_ten.Text == "" || txt_anh.Text == "" || txt_dongia.Text == "" )
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else
            {
                MATHANG n = new MATHANG();
                n.TENMH = txt_ten.Text;
                n.DONGIA = int.Parse(txt_dongia.Text);
                n.ANH = txt_anh.Text;
                n.MANL = int.Parse(cb_nl.SelectedValue.ToString());
                n.MALOAI = int.Parse(cb_loai.SelectedValue.ToString());
                if (dal.themMH(n) == true)
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
                MessageBox.Show("Vui long chon 1 Mặt hàng");
            }
            else
            {
                if (MessageBox.Show("XÓA MẶT HÀNG " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dal.xoaMH(int.Parse(txt_ma.Text)) == true)
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
            if (txt_ma.Text == "" && txt_ten.Text == "")
            {
                MessageBox.Show("Vui long chon 1 mặt hàng!!");
            }
            else
            {
                txt_ten.Focus();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SỬA MẶT HÀNG " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dal.suaMH(int.Parse(txt_ma.Text), txt_ten.Text, int.Parse(txt_dongia.Text), txt_anh.Text, int.Parse(cb_loai.SelectedValue.ToString()), int.Parse(cb_nl.SelectedValue.ToString())) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    loaddata();
                }
                else
                    MessageBox.Show("Sua that bai");
            }
        }

        private void btn_chonanh_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                string t = openFileDialog1.FileName;
                int i = t.LastIndexOf("\\");
                t = t.Substring(i + 1);
                txt_anh.Text = t;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_dongia.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_anh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cb_loai.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            cb_nl.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\hinh\\" + dataGridView1.Rows[e.RowIndex].Cells[3].Value))
            {
                pictureBox1.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\hinh\\" + dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            }
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
