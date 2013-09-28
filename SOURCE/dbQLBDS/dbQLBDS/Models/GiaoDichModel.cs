using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class GiaoDichModel
    {
        private int maGiaoDich;
        private int maTaiKhoan;
        private int maThueCanHo;
        private int maTrangThaiCanHo;

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
        public int MaTrangThaiCanHo
        {
            get { return maTrangThaiCanHo; }
            set { maTrangThaiCanHo = value; }
        }

        public GiaoDichModel(int _MaGiaoDich, int _MaTaiKhoan, int _MaThueCanHo, int _MaTrangThaiGiaoDich)
        {
            this.maGiaoDich = _MaGiaoDich;
            this.maTaiKhoan = _MaTaiKhoan;
            this.maThueCanHo = _MaThueCanHo;
            this.maTrangThaiCanHo = _MaTrangThaiGiaoDich;
        }
    }
}