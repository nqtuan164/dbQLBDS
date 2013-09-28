using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class ThanhPho
    {
        int maThanhPho;
        string tenThanhPho;

        public int MaThanhPho
        {
            get { return maThanhPho; }
            set { maThanhPho = value; }
        }

        public string TenThanhPho
        {
            get { return tenThanhPho; }
            set { tenThanhPho = value; }
        }

        public ThanhPho()
        {
            this.maThanhPho = 0;
            this.tenThanhPho = "";
        }

        public ThanhPho(int ma, string ten)
        {
            this.maThanhPho = ma;
            this.tenThanhPho = ten;
        }
    }
}