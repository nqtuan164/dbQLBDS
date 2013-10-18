using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public enum TrangThaiGiaoDich
    {
        Cho_Xac_Nhan = 1,
        Dang_Giao_Dich = 2,
        Da_Giao_Dich = 3,
        Thanh_Toan_Hoan_Tat = 4,
        Giao_Dich_Huy_Bo = 5
    }

    public class GiaoDich
    {
        private int maGiaoDich;
        private int maTaiKhoan;
        private string tenTaiKhoan;
        private int maLoaiTaiKhoan;
        private int maThueCanHo;
        private int maTrangThaiGiaoDich;
        private TrangThaiGiaoDich trangThaiGiaoDich;

        public int MaGiaoDich
        {
            get { return maGiaoDich; }
            set { maGiaoDich = value; }
        }
        public int MaTaiKhoan
        {
            get { return maTaiKhoan; }
            set { maTaiKhoan = value; }
        }
        public string TenTaiKhoan
        {
            get { return tenTaiKhoan; }
            set { tenTaiKhoan = value; }
        }

        public int MaLoaiTaiKhoan
        {
            get { return maLoaiTaiKhoan; }
            set { maLoaiTaiKhoan = value; }
        }
        public int MaThueCanHo
        {
            get { return maThueCanHo; }
            set { maThueCanHo = value; }
        }

        public int MaTrangThaiGiaoDich
        {
            get { return maTrangThaiGiaoDich; }
            set { maTrangThaiGiaoDich = value; }
        }

        public TrangThaiGiaoDich TrangThaiGiaoDich
        {
            get { return trangThaiGiaoDich; }
            set { trangThaiGiaoDich = value; }
        }

        public GiaoDich()
        {

        }

        public GiaoDich(int _maGiaoDich, 
                        int _maTaiKhoan, 
                        int _maThueCanHo, 
                        TrangThaiGiaoDich _maTrangThaiGiaoDich)
        {
            this.maGiaoDich = _maGiaoDich;
            this.maTaiKhoan = _maTaiKhoan;
            this.maThueCanHo = _maThueCanHo;
            this.trangThaiGiaoDich = _maTrangThaiGiaoDich;
        }
    }
}