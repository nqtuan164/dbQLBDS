using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class CanHo
    {
        private int maCanHo;
        private string tenCanHo;
        private int maDuong;
        private string diaChi;
        private string mieuTa;
        private string toaDo;
        private float giaThue;
        private float dienTich;
        private int maTrangThaiGiaoDich;
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
        public int MaTrangThaiGiaoDich
        {
            get { return maTrangThaiGiaoDich; }
            set { maTrangThaiGiaoDich = value; }
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

        public CanHo()
        {

        }

        public CanHo(int _maCanHo, string _tenCanHo, int _maDuong, string _diaChi, string _mieuTa, string _toaDo,
                        float _giaThue, float _dienTich, int _maTrangThaiGiaoDich, DateTime _ngayDang,
                        int _nguoiDang, string _ghiChu, int _kichHoat)
        {
            this.maCanHo = _maCanHo;
            this.tenCanHo = _tenCanHo;
            this.maDuong = _maDuong;
            this.diaChi = _diaChi;
            this.mieuTa = _mieuTa;
            this.toaDo = _toaDo;
            this.giaThue = _giaThue;
            this.dienTich = _dienTich;
            this.maTrangThaiGiaoDich = _maTrangThaiGiaoDich;
            this.ngayDang = _ngayDang;
            this.nguoiDang = _nguoiDang;
            this.ghiChu = _ghiChu;
            this.kichHoat = _kichHoat;
        }
    }
}