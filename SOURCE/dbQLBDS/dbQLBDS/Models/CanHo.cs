using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public enum TrangThaiCanHo
    {
        Da_Duoc_Thue = 1,
        Chua_Duoc_Thue = 2,
        Dang_Xay_Dung = 3
    }

    public class CanHo
    {
        private int maCanHo;
        private string tenCanHo;
        private int maDuong;
        private string diaChi;
        private string mieuTa;
        private string toaDo;
        private double giaThue;
        private double dienTich;
        private int maTrangThaiCanHo;
        private TrangThaiCanHo trangThaiCanHo;
        private DateTime ngayDang;
        private int nguoiDang;
        private string tenNguoiDang;
        private string ghiChu;
        private int kichHoat;
        
        
        public int MaCanHo
        {
            get { return maCanHo; }
            set { maCanHo = value; }
        }
        
        [Required]
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

        public double GiaThue
        {
            get { return giaThue; }
            set { giaThue = value; }
        }

        public double DienTich
        {
            get { return dienTich; }
            set { dienTich = value; }
        }

        public TrangThaiCanHo TrangThaiCanHo
        {
            get { return trangThaiCanHo; }
            set { trangThaiCanHo = value; }
        }

        public int MaTrangThaiCanHo
        {
            get { return maTrangThaiCanHo; }
            set { maTrangThaiCanHo = value; }
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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

        public string TenNguoiDang
        {
            get { return tenNguoiDang; }
            set { tenNguoiDang = value; }
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
            this.maCanHo = 0;
            this.tenCanHo = "";
            this.maDuong = 0;
            this.diaChi = "";
            this.mieuTa = "";
            this.toaDo = "";
            this.giaThue = 0;
            this.dienTich = 0;
            this.trangThaiCanHo = TrangThaiCanHo.Dang_Xay_Dung;
            this.ngayDang = DateTime.Now;
            this.nguoiDang = 0;
            this.tenNguoiDang = "";
            this.ghiChu = "";
            this.kichHoat = 0;

        }

        public CanHo(int _maCanHo, 
                    string _tenCanHo, 
                    int _maDuong, 
                    string _diaChi, 
                    string _mieuTa, 
                    string _toaDo,
                    float _giaThue, 
                    float _dienTich, 
                    TrangThaiCanHo _maTrangThaiCanHo, 
                    DateTime _ngayDang,
                    int _nguoiDang, 
                    string _ghiChu, 
                    int _kichHoat)
        {
            this.maCanHo = _maCanHo;
            this.tenCanHo = _tenCanHo;
            this.maDuong = _maDuong;
            this.diaChi = _diaChi;
            this.mieuTa = _mieuTa;
            this.toaDo = _toaDo;
            this.giaThue = _giaThue;
            this.dienTich = _dienTich;
            this.trangThaiCanHo = _maTrangThaiCanHo;
            this.ngayDang = _ngayDang;
            this.nguoiDang = _nguoiDang;
            this.ghiChu = _ghiChu;
            this.kichHoat = _kichHoat;
        }

        
    }

    
}