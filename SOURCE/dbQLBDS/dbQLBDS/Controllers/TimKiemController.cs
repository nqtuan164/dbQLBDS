using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        public ActionResult Index()
        {
            DataProvider dp = new DataProvider();

            //Load danh sach thanh pho
            string sql = @"SELECT * FROM thanhpho t ";
            DataTable dt = new DataTable();
            dt = dp.ExecuteQuery(sql);

            List<ThanhPho> dsThanhPho = new List<ThanhPho>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThanhPho item = new ThanhPho();
                    item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
                    item.TenThanhPho = dt.Rows[i]["tenthanhpho"].ToString();
                    dsThanhPho.Add(item);
                }
            }

            ViewBag.dsThanhPho = dsThanhPho;
            ViewBag.txtTimKiem = "";
            ViewBag.cmbDienTich = 0;
            ViewBag.cmbGia = 0;
            ViewBag.cmbThanhPho = 0;
            ViewBag.cmbQuan = 0;
            ViewBag.cmbDuong = 0;
            ViewBag.isTimKiem = false;
            ViewBag.dsCanHoCount = 0;

            return View("~/Views/Shared/TimKiem.cshtml");
        }

        [HttpPost]
        public ActionResult Index(string txtTimKiem, int cmbDienTich, 
                                    int cmbGia, int cmbDuong, 
                                    int cmbQuan, int cmbThanhPho)
        {
            //Load danh sach thanh pho
            DataProvider dp = new DataProvider();
            string sql = @"SELECT * FROM thanhpho t ";
            DataTable dt = new DataTable();
            dt = dp.ExecuteQuery(sql);

            List<ThanhPho> dsThanhPho = new List<ThanhPho>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThanhPho item = new ThanhPho();
                    item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
                    item.TenThanhPho = dt.Rows[i]["tenthanhpho"].ToString();
                    dsThanhPho.Add(item);
                }
            }
            ViewBag.dsThanhPho = dsThanhPho;

            ViewBag.txtTimKiem = txtTimKiem;
            ViewBag.cmbDienTich = cmbDienTich;
            ViewBag.cmbGia = cmbGia;
            ViewBag.cmbThanhPho = cmbThanhPho;
            ViewBag.cmbQuan = cmbQuan;
            ViewBag.cmbDuong = cmbDuong;


            //TRUY VAN TIM KIEM CAN HO
            sql = @"SELECT ch.*, d.tenduong, q.tenquan, tp.tenthanhpho
                    FROM canho ch, duong d, quan q, thanhpho tp
                    WHERE ch.kichhoat = 1 AND
	                    ch.matrangthaicanho = 2 AND
	                    ch.maduong = d.maduong AND
	                    d.maquan = q.maquan AND
	                    q.mathanhpho = tp.mathanhpho 
	                    AND ch.tencanho LIKE N'%" + txtTimKiem + @"%'
                    ";

            switch (cmbGia)
            {
                case 1:
                    sql += " AND ch.giathue < 1000000 ";
                    break;
                case 2:
                    sql += " AND 1000000 <= ch.giathue AND ch.giathue < 3000000 ";
                    break;
                case 3:
                    sql += " AND 3000000 <= ch.giathue AND ch.giathue < 5000000 ";
                    break;
                case 4:
                    sql += " AND 5000000 <= ch.giathue AND ch.giathue < 10000000 ";
                    break;
                case 5:
                    sql += " AND ch.giathue >= 10000000 ";
                    break;
                default:
                    break;
            }

            switch (cmbDienTich)
            {
                case 1:
                    sql += " AND ch.dientich < 30 ";
                    break;
                case 2:
                    sql += " AND 30 <= ch.dientich AND ch.dientich < 50 ";
                    break;
                case 3:
                    sql += " AND 50 <= ch.dientich AND ch.dientich < 80 ";
                    break;
                case 4:
                    sql += " AND 80 <= ch.dientich AND ch.dientich < 100 ";
                    break;
                case 5:
                    sql += " AND ch.dientich >= 100 ";
                    break;
                default:
                    break;
            }

            if (cmbThanhPho != 0)
            {
                sql += " AND tp.mathanhpho = " + cmbThanhPho + " ";
            }
            if (cmbQuan != 0)
            {
                sql += " AND q.maquan = " + cmbQuan + " ";
            }
            if (cmbDuong != 0)
            {
                sql += " AND d.maduong = " + cmbDuong + " ";
            }


            dt = new DataTable();
            dt = dp.ExecuteQuery(sql);

            List<CanHo> dsCanHo = new List<CanHo>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CanHo item = new CanHo();
                    item.MaCanHo = (int)dt.Rows[i]["macanho"];
                    item.TenCanHo = dt.Rows[i]["tencanho"].ToString();
                    item.MaDuong = (int)dt.Rows[i]["maduong"];
                    item.DiaChi = dt.Rows[i]["diachi"].ToString() + " " +
                                    dt.Rows[i]["tenduong"].ToString() + ", " +
                                    dt.Rows[i]["tenquan"].ToString() + ", " +
                                    dt.Rows[i]["tenthanhpho"].ToString();
                    item.MieuTa = dt.Rows[i]["mieuta"].ToString();
                    item.ToaDo = dt.Rows[i]["toado"].ToString();
                    item.GiaThue = (double)dt.Rows[i]["giathue"];
                    item.DienTich = (double)dt.Rows[i]["dientich"];
                    item.MaTrangThaiCanHo = (int)dt.Rows[i]["matrangthaicanho"];
                    item.TrangThaiCanHo = (TrangThaiCanHo)dt.Rows[i]["matrangthaicanho"];
                    item.NgayDang = DateTime.Parse(dt.Rows[i]["ngaydang"].ToString());
                    item.NguoiDang = (int)dt.Rows[i]["nguoidang"];
                    item.GhiChu = dt.Rows[i]["ghichu"].ToString();
                    item.KichHoat = (int)dt.Rows[i]["kichhoat"];
                    
                    dsCanHo.Add(item);
                }
            }

            ViewBag.dsCanHoCount = dsCanHo.Count;
            ViewBag.isTimKiem = true;

            return View("~/Views/Shared/TimKiem.cshtml", dsCanHo);
        }

    }
}
