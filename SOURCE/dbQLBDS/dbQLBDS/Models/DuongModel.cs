using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class DuongModel
    {
        private int maDuong;
        private string tenDuong;
        private int maQuan;

        public int MaDuong
        {
            get { return maDuong; }
            set { maDuong = value; }
        }
        public string TenDuong
        {
            get { return tenDuong; }
            set { tenDuong = value; }
        }
        public int MaQuan
        {
            get { return maQuan; }
            set { maQuan = value; }
        }

        public DuongModel(int _maDuong, string _tenDuong, int _maQuan) 
        {
            this.maDuong = _maDuong;
            this.tenDuong = _tenDuong;
            this.maQuan = _maQuan;
        }
    }
}