using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class HinhAnhCanHoModel
    {
        int maHinhAnh;
        int maCanHo;
        string lienKet;

        public int MaHinhAnh
        {
            get { return maHinhAnh; }
            set { maHinhAnh = value; }
        }

        public int MaCanHo
        {
            get { return maCanHo; }
            set { maCanHo = value; }
        }

        public string LienKet
        {
            get { return lienKet; }
            set { lienKet = value; }
        }

        public HinhAnhCanHoModel()
        {
            this.maHinhAnh = 0;
            this.maCanHo = 0;
            this.lienKet = "";
        }

        public HinhAnhCanHoModel(int mahinh, int macanho, string lienket)
        {
            this.maHinhAnh = mahinh;
            this.maCanHo = macanho;
            this.lienKet = lienket;
        }

    }
}