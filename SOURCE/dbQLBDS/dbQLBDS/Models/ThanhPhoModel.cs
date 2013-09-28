using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class ThanhPhoModel
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

        public ThanhPhoModel()
        {
            this.maThanhPho = 0;
            this.tenThanhPho = "";
        }

        public ThanhPhoModel(int ma, string ten)
        {
            this.maThanhPho = ma;
            this.tenThanhPho = ten;
        }
    }
}