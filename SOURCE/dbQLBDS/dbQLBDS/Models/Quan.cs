using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class Quan
    {
        int maQuan;
        string tenQuan;
        int maThanhPho;

        public int MaQuan
        {
            get { return maQuan; }
            set { maQuan = value; }
        }

        public string TenQuan
        {
            get { return tenQuan; }
            set { tenQuan = value; }
        }

        public int MaThanhPho
        {
            get { return maThanhPho; }
            set { maThanhPho = value; }
        }

        public Quan()
        {
            this.maQuan = 0;
            this.tenQuan = "";
            this.maThanhPho = 0;
        }

        public Quan(int maquan, string tenquan, int matp)
        {
            this.maQuan = maquan;
            this.tenQuan = tenQuan;
            this.maThanhPho = matp;
        }
    }
}