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
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        CAFEDAL dal = new CAFEDAL();
        private void Main_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = DangNhap.tennv.ToString();
            if(dal.getvtdn(DangNhap.manv) != 1)
            {
                qUẢNLÝToolStripMenuItem.Enabled = false;
            }
        }

        private void nHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNHANVIEN frm = new QLNHANVIEN();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nGUYÊNLIỆUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNGUYENLIEU frm = new QLNGUYENLIEU();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bÁNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLBANHANG frm = new QLBANHANG();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mẶTHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLMATHANG frm = new QLMATHANG();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHOADON frm = new QLHOADON();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lOẠIMẶTHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLLOAI frm = new QLLOAI();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nHÀCUNGCẤPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNCC frm = new QLNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất !!", "ĐĂNG XUẤT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                DangNhap f = new DangNhap();
                f.Show();
            }
            
        }
    }
}
