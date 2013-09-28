using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class CanHoModel
    {
        private int maCanHo;
        private string tenCanHo;
        private int maDuong;
        private string diaChi;
        private string mieuTa;
        private string toaDo;
        private float giaThue;
        private float dienTich;
        private float maTrangThaiCanHo;
        private DateTime ngayDang;
        private int nguoiDang;
        private string ghiChu;
        private int kichHoat;

        public int MaCanHo
        {
            get { return maCanHo; }
            set { maCanHo = value; }
        }
        public string TenCanHo
        {
            get { return tenCanHo; }
            set { tenCanHo = value; }
        }
        public int MaDuong
        {
            get { return maDuong; }
            set { maDuong = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public string MieuTa
        {
            get { return mieuTa; }
            set { mieuTa = value; }
        }
        public string ToaDo
        {
            get { return toaDo; }
            set { toaDo = value; }
        }
        public float GiaThue
        {
            get { return giaThue; }
            set { giaThue = value; }
        }
        public float DienTich
        {
            get { return dienTich; }
            set { dienTich = value; }
        }
        public float MaTrangThaiCanHo
        {
            get { return maTrangThaiCanHo; }
            set { maTrangThaiCanHo = value; }
        }
        public DateTime NgayDang
        {
            get { return ngayDang; }
            set { ngayDang = value; }
        }        
        public int NguoiDang
        {
            get { return nguoiDang; }
            set { nguoiDang = value; }
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

        public CanHoModel(int _MaCanHo, string _TenCanHo, int _MaDuong, string _DiaChi, string _MieuTa, string _ToaDo,
                        float _GiaThue, float _DienTich, float _MaTrangThaiCanHo, DateTime _NgayDang, int _NguoiDang,
                        string _GhiChu, int _KichHoat)
        {
            this.maCanHo = _MaCanHo;
            this.tenCanHo = _TenCanHo;
            this.maDuong = _MaDuong;
            this.diaChi = _DiaChi;
            this.mieuTa = _MieuTa;
            this.toaDo = _ToaDo;
            this.giaThue = _GiaThue;
            this.dienTich = _DienTich;
            this.maTrangThaiCanHo = _MaTrangThaiCanHo;
            this.ngayDang = _NgayDang;
            this.nguoiDang = _NguoiDang;
            this.ghiChu = _GhiChu;
            this.kichHoat = _KichHoat;
        }
    }
}