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
    public partial class QLBANHANG : Form
    {
        public QLBANHANG()
        {
            InitializeComponent();
        }
        CAFEDAL dal = new CAFEDAL();
        private void QLBANHANG_Load(object sender, EventArgs e)
        {
            load_hang();
            
        }
        public void load_hang()
        {

            foreach (var row in dal.getmathang())
            {
                Button btn = new Button() { Width = 150, Height = 150 };
                btn.Click += btn_Click;
                btn.Text = row.MAMH.ToString() + "-" + row.TENMH.ToString();
                btn.Font = new Font(btn.Font.FontFamily, 11, FontStyle.Bold);
                btn.ForeColor = Color.Blue;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.BackgroundImage = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\hinh\\" + row.ANH.ToString());
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        public int gia = 0;
        void btn_Click(object sender, EventArgs e)
        {
            if(txt_mahd.Text == "")
            {
                MessageBox.Show("Chưa tạo hóa đơn");
            }
            else
            {
                Button btn = (Button)sender;
                string ma = btn.Text;
                int i = ma.IndexOf("-");
                ma = ma.Substring(0, i);
                gia = dal.getgiamh(int.Parse(ma));
                CHITIETHOADON n = new CHITIETHOADON();
                n.MAHD = int.Parse(txt_mahd.Text);
                n.MAMH = int.Parse(ma);
                n.SL = 1;
                n.DONGIA = gia;
                n.THANHTIEN = n.DONGIA * n.SL;
                if (dal.themCTHD(n) == true)
                {
                    MessageBox.Show("Them thanh cong");
                    loadcthd();
                    dal.capnhatTT(int.Parse(txt_mahd.Text));
                }
                else
                    MessageBox.Show("Them that bai");
            }
            
        }

        public void loadcthd()
        {
            dataGridView1.DataSource = dal.getcthd(int.Parse(txt_mahd.Text));
        }
        private void btn_taohd_Click(object sender, EventArgs e)
        {
            HOADON n = new HOADON();
            DateTime currentDateTime = DateTime.Now;
            DateTime currentDate = currentDateTime.Date;
            n.NGAYLAP = currentDate;
            n.MANV = DangNhap.manv;
            if (dal.themHD(n) == true)
            {
                MessageBox.Show("Đã tạo đơn","TẠO HÓA ĐƠN",MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Them that bai");

            HOADON hd = new HOADON();
            hd = dal.gethoadoncuoi();
            txt_mahd.Text = hd.MAHD.ToString();
        }
        public int mamh = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mathang.Text = dal.gettenmh(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));
            mamh = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            txt_sl.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            gia = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btn_capnhatsl_Click(object sender, EventArgs e)
        {
            if (dal.suaCTHD(int.Parse(txt_mahd.Text), mamh,int.Parse(txt_sl.Text),gia) == true)
            {
                MessageBox.Show("Cập nhật thanh cong");
                loadcthd();
                dal.capnhatTT(int.Parse(txt_mahd.Text));
            }
            else
                MessageBox.Show("Cập nhật that bai");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_mathang.Text == "")
            {
                MessageBox.Show("Vui long chon 1 mặt hàng muốn xóa");
            }
            else
            {
                if (MessageBox.Show("XÓA MẶT HÀNG " + txt_mathang.Text + " !", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dal.xoaCTHD(int.Parse(txt_mahd.Text),mamh) == true)
                    {
                        MessageBox.Show("Xoa thanh cong");
                        loadcthd();
                        dal.capnhatTT(int.Parse(txt_mahd.Text));
                    }
                    else
                        MessageBox.Show("Xoa that bai");
                }

            }
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            List<CHITIETHOADON> hd = dal.getcthd(int.Parse(txt_mahd.Text));
            var texcontent = "\t\t    CAFE QUÁN\n\t\tHÓA ĐƠN THANH TOÁN\nTÊN NHÂN VIÊN : "+DangNhap.tennv
                +" \nTênMón\t        SL       ĐG     T.Tiền\n";
            texcontent += "***************************************\n";
            var file = new StreamWriter("hoadon.txt");
            foreach (CHITIETHOADON item in hd)
            {
                texcontent += dal.gettenmh(item.MAMH) + "\t"
                    + item.SL.ToString() + "\t" + item.DONGIA.ToString() + "\t"
                    + item.THANHTIEN.ToString();

                texcontent += "\n";
            }
            texcontent += "***************************************\n";
            texcontent += "TỔNG CỘNG                  "+ dal.gettongtien(int.Parse(txt_mahd.Text)) + " VNĐ\nCHÚC QUÝ KHÁCH VUI VẺ, HẸN GẶP LẠI";

            File.WriteAllText("D:\\PTPMUDTM\\QL_CAFE\\QLCafe\\QL_CAFE\\GUI\\hoadon.txt", texcontent);
            MessageBox.Show("Thanh toán thành công");
            txt_mahd.Text = "";
            dataGridView1.DataSource = null;
        }
    }
}
