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
    public partial class QLNHANVIEN : Form
    {
        CAFEDAL cf = new CAFEDAL();
        public QLNHANVIEN()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txt_ten.Text=="" || txt_email.Text=="" || txt_sdt.Text=="" || txt_tdn.Text=="" || txt_mk.Text=="")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else
            {
                NHANVIEN n = new NHANVIEN();
                //n.MANV = int.Parse(txt_ma.Text);
                n.TENNV = txt_ten.Text;
                n.EMAIL = txt_email.Text;
                n.SDT = txt_sdt.Text;
                n.TENDANGNHAP = txt_tdn.Text;
                n.MATKHAU = txt_mk.Text;
                n.MAVT = int.Parse(cb_vt.SelectedValue.ToString());
                if (cf.themNV(n) == true)
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
                MessageBox.Show("Vui long chon 1 khoa");
            }
            else
            {
                if (MessageBox.Show("XÓA NHÂN VIÊN "+txt_ma.Text+" !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
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
        public void loaddata()
        {
            dataGridView1.DataSource = cf.getnhanvien();
        }
        public void loadcb()
        {
            cb_vt.DataSource = cf.getvt();
            cb_vt.DisplayMember = "TENVT";
            cb_vt.ValueMember = "MAVT";
        }
        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            loaddata();
            loadcb();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text == "" && txt_ten.Text == "")
            {
                MessageBox.Show("Vui long chon 1 nhân viên!!");
            }
            else
            {
                txt_ten.Focus();
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
            txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_tdn.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_mk.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cb_vt.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SỬA NHÂN VIÊN " + txt_ma.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cf.suaNV(int.Parse(txt_ma.Text), txt_ten.Text, txt_email.Text, txt_sdt.Text, txt_tdn.Text, txt_mk.Text, int.Parse(cb_vt.SelectedValue.ToString())) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    loaddata();
                }
                else
                    MessageBox.Show("Sua that bai");
            }
            
        }
    }
}
