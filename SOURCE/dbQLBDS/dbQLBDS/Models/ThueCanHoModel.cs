using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class ThueCanHoModel
    {
        private int maThueCanHo;
        private int maTaiKhoan;
        private int maCanHo;
        private float tienCoc;
        private DateTime thoiGianThue;
        private DateTime thoiGianKetThuc;
        private DateTime thoiGianGiaoDich;
        private string dienThoai;
        private string diaChi;
        private string ghiChu;
        private int kichHoat;

        public int MaThueCanHo
        {
            get { return maThueCanHo; }
            set { maThueCanHo = value; }
        }
        public int MaTaiKhoan
        {
            get { return maTaiKhoan; }
            set { maTaiKhoan = value; }
        }
        public int MaCanHo
        {
            get { return maCanHo; }
            set { maCanHo = value; }
        }
        public float TienCoc
        {
            get { return tienCoc; }
            set { tienCoc = value; }
        }
        public DateTime ThoiGianThue
        {
            get { return thoiGianThue; }
            set { thoiGianThue = value; }
        }
        public DateTime ThoiGianKetThuc
        {
            get { return thoiGianKetThuc; }
            set { thoiGianKetThuc = value; }
        }
        public DateTime ThoiGianGiaoDich
        {
            get { return thoiGianGiaoDich; }
            set { thoiGianGiaoDich = value; }
        }
        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public int KichHoat
        {
            get { return kichHoat; }
            set { kichHoat = value; }
        }

        public ThueCanHoModel(int _MaThueCanHo, int _MaTaiKhoan, int _MaCanHo, float _TienCoc, DateTime _ThoiGianThue,
                            DateTime _ThoiGianKetThuc, DateTime _ThoiGianGiaoDich, string _DienThoai,
                            string _DiaChi, string _GhiChu, int _KichHoat) 
        {
            this.maThueCanHo = _MaThueCanHo;
            this.maTaiKhoan = _MaTaiKhoan;
            this.maCanHo = _MaCanHo;
            this.tienCoc = _TienCoc;
            this.thoiGianThue = _ThoiGianThue;
            this.thoiGianKetThuc = _ThoiGianKetThuc;
            this.thoiGianGiaoDich = _ThoiGianGiaoDich;
            this.dienThoai = _DienThoai;
            this.diaChi = _DiaChi;
            this.ghiChu = _GhiChu;
            this.kichHoat = _KichHoat;
        }

    }
}