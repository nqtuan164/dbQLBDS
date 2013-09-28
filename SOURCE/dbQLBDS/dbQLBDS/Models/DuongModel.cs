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

        public DuongModel(int _MaDuong, string _TenDuong, int _MaQuan) 
        {
            this.maDuong = _MaDuong;
            this.tenDuong = _TenDuong;
            this.maQuan = _MaQuan;
        }
    }
}