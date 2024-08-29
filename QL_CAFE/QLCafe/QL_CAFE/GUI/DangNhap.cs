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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        CAFEDAL dal = new CAFEDAL();
        public static int manv;
        public static int vt;
        public static string tennv;
        private void btn_dangNhap_Click(object sender, EventArgs e)
        {
            bool dn = false;
            if (txt_tk.Text == "" || txt_mk.Text == "")
            {
                MessageBox.Show("Vui Lòng nhập đầy đủ thông tin!");
            }
            else
            {
                foreach (var row in dal.getnhanvien())
                {
                    if(txt_tk.Text == row.TENDANGNHAP.ToString() && txt_mk.Text == row.MATKHAU.ToString())
                    {
                        manv = row.MANV;
                        tennv = row.TENNV.ToString();
                        vt = int.Parse(row.MAVT.ToString());
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();
                        Main f = new Main();
                        f.Show();
                        dn = true;
                    }
                }
                if(dn == false)
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác");
                }
            }
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                txt_mk.UseSystemPasswordChar = true;

            }
            else
                txt_mk.UseSystemPasswordChar = false;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
