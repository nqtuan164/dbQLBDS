using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class GiaoDich
    {
        private int maGiaoDich;
        private int maTaiKhoan;
        private int maThueCanHo;
        private int maTrangThaiGiaoDich;

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

        public GiaoDich()
        {

        }

        public GiaoDich(int _maGiaoDich, int _maTaiKhoan, int _maThueCanHo, int _maTrangThaiGiaoDich)
        {
            this.maGiaoDich = _maGiaoDich;
            this.maTaiKhoan = _maTaiKhoan;
            this.maThueCanHo = _maThueCanHo;
            this.maTrangThaiGiaoDich = _maTrangThaiGiaoDich;
        }
    }
}