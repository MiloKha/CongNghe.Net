using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CAFEDAL
    {
        QLCAFEDataContext ql = new QLCAFEDataContext();
        public List<LOAISANPHAM> getloaisp()
        {

            var data = (from dt in ql.LOAISANPHAMs select dt).ToList();
            return data;
        }
        public List<MATHANG> getmathang()
        {

            var data = (from dt in ql.MATHANGs select dt).ToList();
            return data;
        }
        public List<NHANVIEN> getnhanvien()
        {

            var data = (from dt in ql.NHANVIENs select dt).ToList();
            return data;
        }
        public List<HOADON> gethoadon()
        {

            var data = (from dt in ql.HOADONs select dt).ToList();
            return data;
        }
        public List<HOADON> gethoadontheongay(DateTime n)
        {

            var data = (from dt in ql.HOADONs where dt.NGAYLAP == n select dt).ToList();
            return data;
        }
        public List<CHITIETHOADON> getcthd(int ma)
        {

            var data = (from dt in ql.CHITIETHOADONs where dt.MAHD == ma select dt).ToList();
            return data;
        }
        public List<NGUYENLIEU> getnguyenlieu()
        {

            var data = (from dt in ql.NGUYENLIEUs select dt).ToList();
            return data;
        }
        public List<NHACUNGCAP> getncc()
        {

            var data = (from dt in ql.NHACUNGCAPs select dt).ToList();
            return data;
        }
        public List<VAITRO> getvt()
        {

            var data = (from dt in ql.VAITROs select dt).ToList();
            return data;
        }

        public int getvtdn(int ma)
        {
            var data = (from dt in ql.NHANVIENs where dt.MANV == ma select dt.MAVT);
            //var data = ql.NHANVIENs.Where(t => t.MANV == ma).FirstOrDefault();
            //int kq = int.Parse(data);
            int vt = 0;
            foreach (int kq in data)
            {
                vt = kq;
            }
            return vt;
        }
        public VAITRO getvttheoma(int ma)
        {
            var data = (from dt in ql.VAITROs where dt.MAVT == ma select dt).FirstOrDefault();
            return data;
        }

        public HOADON gethoadoncuoi()
        {
            var last = ql.HOADONs.OrderByDescending(r => r.MAHD).FirstOrDefault();
            return last;
        }
        public int getgiamh(int ma)
        {
            var data = (from dt in ql.MATHANGs where dt.MAMH == ma select dt.DONGIA);
            //var data = ql.NHANVIENs.Where(t => t.MANV == ma).FirstOrDefault();
            //int kq = int.Parse(data);
            int vt = 0;
            foreach (int kq in data)
            {
                vt = kq;
            }
            return vt;
        }
        public int gettongdt()
        {
            var data = (from dt in ql.HOADONs select dt.THANHTIEN);
            //var data = ql.NHANVIENs.Where(t => t.MANV == ma).FirstOrDefault();
            //int kq = int.Parse(data);
            int vt = 0;
            foreach (int kq in data)
            {
                vt += kq;
            }
            return vt;
        }
        public int gettongtien(int ma)
        {
            var data = (from dt in ql.CHITIETHOADONs where dt.MAHD == ma select dt.THANHTIEN);
            //var data = ql.NHANVIENs.Where(t => t.MANV == ma).FirstOrDefault();
            //int kq = int.Parse(data);
            int vt = 0;
            foreach (int kq in data)
            {
                vt += kq;
            }
            return vt;
        }
        public string gettenmh(int ma)
        {
            var data = (from dt in ql.MATHANGs where dt.MAMH == ma select dt.TENMH);
            //var data = ql.NHANVIENs.Where(t => t.MANV == ma).FirstOrDefault();
            //int kq = int.Parse(data);
            string vt = "";
            foreach (string kq in data)
            {
                vt = kq;
            }
            return vt;
        }
        public bool themNV(NHANVIEN n)
        {
            try
            {
                n.MANV = ql.NHANVIENs.Max(x => x.MANV) + 1;
                ql.NHANVIENs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool themMH(MATHANG n)
        {
            try
            {
                n.MAMH = ql.MATHANGs.Max(x => x.MAMH) + 1;
                ql.MATHANGs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool themHD(HOADON n)
        {
            try
            {
                n.MAHD = ql.HOADONs.Max(x => x.MAHD) + 1;
                n.THANHTIEN = 0;
                ql.HOADONs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool themLoai(LOAISANPHAM n)
        {
            try
            {
                n.MALOAI = ql.LOAISANPHAMs.Max(x => x.MALOAI) + 1;
                ql.LOAISANPHAMs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool themNCC(NHACUNGCAP n)
        {
            try
            {
                n.MANCC = ql.NHACUNGCAPs.Max(x => x.MANCC) + 1;
                ql.NHACUNGCAPs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool themCTHD(CHITIETHOADON n)
        {
            try
            {
                ql.CHITIETHOADONs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaNV(int manv)
        {
            try
            {
                NHANVIEN k = ql.NHANVIENs.Where(t => t.MANV == manv).FirstOrDefault();
                ql.NHANVIENs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaLoai(int ma)
        {
            try
            {
                LOAISANPHAM k = ql.LOAISANPHAMs.Where(t => t.MALOAI == ma).FirstOrDefault();
                ql.LOAISANPHAMs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaNCC(int ma)
        {
            try
            {
                NHACUNGCAP k = ql.NHACUNGCAPs.Where(t => t.MANCC == ma).FirstOrDefault();
                ql.NHACUNGCAPs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaMH(int ma)
        {
            try
            {
                MATHANG k = ql.MATHANGs.Where(t => t.MAMH == ma).FirstOrDefault();
                ql.MATHANGs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaHD(int ma)
        {
            try
            {
                HOADON k = ql.HOADONs.Where(t => t.MAHD == ma).FirstOrDefault();
                ql.HOADONs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaCTHD(int ma,int mamh)
        {
            try
            {
                CHITIETHOADON k = ql.CHITIETHOADONs.Where(t => t.MAHD == ma).Where(t2 => t2.MAMH == mamh).FirstOrDefault();
                ql.CHITIETHOADONs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool suaNV(int ma, string ten, string mail, string sdt, string tdn, string mk,int mavt)
        {
            try
            {
                NHANVIEN k = ql.NHANVIENs.Where(t => t.MANV == ma).FirstOrDefault();
                k.TENNV = ten;
                k.EMAIL = mail;
                k.SDT = sdt;
                k.TENDANGNHAP = tdn;
                k.MATKHAU = mk;
                k.MAVT = mavt;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool suaLoai(int ma, string ten)
        {
            try
            {
                LOAISANPHAM k = ql.LOAISANPHAMs.Where(t => t.MALOAI == ma).FirstOrDefault();
                k.TENLOAI = ten;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool suaNCC(int ma, string ten,string sdt,string dc)
        {
            try
            {
                NHACUNGCAP k = ql.NHACUNGCAPs.Where(t => t.MANCC == ma).FirstOrDefault();
                k.TENNCC = ten;
                k.SDT = sdt;
                k.DIACHI = dc;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        
        public bool capnhatTT(int ma)
        {
            int tt = 0;
            try
            {
                var data = (from dt in ql.CHITIETHOADONs where dt.MAHD == ma select dt).ToList();
                foreach (var item in data)
                {
                    tt += int.Parse(item.THANHTIEN.ToString());
                }
                HOADON k = ql.HOADONs.Where(t => t.MAHD == ma).FirstOrDefault();
                k.THANHTIEN = tt;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaCTHD(int ma,int mamh, int sl, int dg)
        {
            try
            {
                CHITIETHOADON k = ql.CHITIETHOADONs.Where(t => t.MAHD == ma).Where(t2 => t2.MAMH == mamh).FirstOrDefault();
                k.SL = sl;
                k.DONGIA = dg;
                k.THANHTIEN = sl * dg;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool themNL(NGUYENLIEU n)
        {
            try
            {
                n.MANL = ql.NGUYENLIEUs.Max(x => x.MANL) + 1;
                ql.NGUYENLIEUs.InsertOnSubmit(n);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaNL(int ma)
        {
            try
            {
                NGUYENLIEU k = ql.NGUYENLIEUs.Where(t => t.MANL == ma).FirstOrDefault();
                ql.NGUYENLIEUs.DeleteOnSubmit(k);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool suaNL(int ma, string ten, int sl, int mancc, DateTime cnn)
        {
            try
            {
                NGUYENLIEU k = ql.NGUYENLIEUs.Where(t => t.MANL == ma).FirstOrDefault();
                k.TENNL = ten;
                k.SOLUONG = sl;
                k.MANCC = mancc;
                k.CAPNHATNGAY = cnn;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool suaMH(int ma, string ten, int dg, string anh, int ml, int mnl)
        {
            try
            {
                MATHANG k = ql.MATHANGs.Where(t => t.MAMH == ma).FirstOrDefault();
                k.TENMH = ten;
                k.DONGIA = dg;
                k.ANH = anh;
                k.MALOAI = ml;
                k.MANL = mnl;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
