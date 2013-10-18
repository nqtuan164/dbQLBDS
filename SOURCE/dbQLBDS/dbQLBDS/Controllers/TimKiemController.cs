using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
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
                                    int cmbQuan, int cmbThanhPho,
                                    string chkSuaLoi)
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
            ViewBag.chkSuaLoi = chkSuaLoi;

            

            //TRUY VAN TIM KIEM CAN HO
            sql = @"FROM canho ch, duong d, quan q, thanhpho tp
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

            
            //Tao lenh moi
            string sqlHeader = "SELECT COUNT(ch.macanho) ";
            SqlCommand cmd = new SqlCommand(sqlHeader + sql, dp.Connect);
            SqlDataReader reader = null;
            List<CanHo> dsCanHo = new List<CanHo>();
            dp.OpenConnect();

            //Tao transaction moi
            if (chkSuaLoi != null)
            {
                //Set level = Serializable để giải quyết Phantom
                cmd.Transaction = cmd.Connection.BeginTransaction(IsolationLevel.Serializable);
            }
            else
            {
                //Set level = ReadCommitted mức mặc định
                cmd.Transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }

            try
            {
                reader = cmd.ExecuteReader();

                //Doc so dong du lieu
                while (reader.Read())
                {
                    ViewBag.dsCanHoCount = reader.GetValue(0);
                }
                reader.Close();

                Thread.Sleep(5000); //Wait for 15 seconds

                //truy van tim kiem
                sqlHeader = "SELECT ch.*, d.tenduong, q.tenquan, tp.tenthanhpho ";
                cmd.CommandText = sqlHeader + sql;
                reader = cmd.ExecuteReader();

                /*
                    0 macanho
                    1 tencanho
                    2 maduong
                    3 diachi
                    4 mieuta
                    5 toado
                    6 giathue
                    7 dientich
                    8 matrangthaicanho
                    9 ngaydang
                    10 nguoidang
                    11 ghichu
                    12 kichhoat
                    13 tenduong
                    14 tenquan
                    15 tenthanhpho
                 */

                while (reader.Read())
                {
                    //Tao mang luu tru dong du lieu (FieldCount = so cot du lieu)
                    object[] row = new object[reader.FieldCount];

                    //Doc gia tri vao mang
                    reader.GetValues(row);
                    

                    CanHo item = new CanHo();
                    item.MaCanHo = int.Parse(row[0].ToString());
                    item.TenCanHo = row[1].ToString();
                    item.MaDuong = int.Parse(row[2].ToString());
                    item.DiaChi = row[3].ToString() + " " + row[13].ToString() + ", " +
                                    row[14].ToString() + ", " + row[15].ToString();
                    item.MieuTa = row[4].ToString();
                    item.ToaDo = row[5].ToString();
                    item.GiaThue = double.Parse(row[6].ToString());
                    item.DienTich = double.Parse(row[7].ToString());
                    item.MaTrangThaiCanHo = int.Parse(row[8].ToString());
                    item.TrangThaiCanHo = (TrangThaiCanHo)int.Parse(row[8].ToString());
                    item.NgayDang = DateTime.Parse(row[9].ToString());
                    item.NguoiDang = int.Parse(row[10].ToString());
                    item.GhiChu = row[11].ToString();
                    item.KichHoat = int.Parse(row[12].ToString());

                    dsCanHo.Add(item);
                    
                }
                reader.Close();

                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                //Roll back neu bi loi
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }
            }
            finally
            {
                //Dong ket noi
                dp.Connect.Close();
            }
            
            ViewBag.isTimKiem = true;

            return View("~/Views/Shared/TimKiem.cshtml", dsCanHo);
        }

    }
}
