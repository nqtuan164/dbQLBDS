using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class DatThueCanHoController : Controller
    {
        public TaiKhoan isLogin()
        {
            if (Session["taikhoan"] != null)
            {
                TaiKhoan tk = new TaiKhoan();
                tk = (TaiKhoan)Session["taikhoan"];
                return tk;
            }
            return null;
        }

        [HttpPost]
        public ActionResult Index(string txtNgayBatDauThue, int txtThoiGianThue,
                                string txtNgayKetThuc, double txtTienThue,
                                double txtGiamGia, double txtTienPhaiTra,
                                double txtTienCoc, string txtHoTen,
                                string txtEmail, string txtDiaChi,
                                string txtDienThoai)
        {
            TaiKhoan tk = isLogin();
            if (tk == null)
            {
                return Redirect("/DangNhap");
            }

            int maCanHo = 0;
            CanHo ch = new CanHo();

            if (!Int32.TryParse(Request.Params["id"], out maCanHo))
            {
                ch.MaTrangThaiCanHo = -999;
                return null;
            }

            DateTime ngaybatdau = DateTime.ParseExact(txtNgayBatDauThue, "yyyy-M-d", null);
            DateTime ngayketthuc = DateTime.ParseExact(txtNgayKetThuc, "d/M/yyyy", null);

            DataProvider dp = new DataProvider();

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@mataikhoan", SqlDbType.Int);
            param[0].Value = tk.MaTaiKhoan;

            param[1] = new SqlParameter("@macanho", SqlDbType.Int);
            param[1].Value = maCanHo;

            param[2] = new SqlParameter("@tiencoc", SqlDbType.Float);
            param[2].Value = txtTienCoc;

            param[3] = new SqlParameter("@thoigianthue", SqlDbType.DateTime);
            param[3].Value = ngaybatdau;

            param[4] = new SqlParameter("@thoigiankethuc", SqlDbType.DateTime);
            param[4].Value = ngayketthuc;

            param[5] = new SqlParameter("@thoigiangiaodich", SqlDbType.DateTime);
            param[5].Value = DateTime.Now;

            param[6] = new SqlParameter("@dienthoai", SqlDbType.NVarChar);
            param[6].Value = txtDienThoai;

            param[7] = new SqlParameter("@diachi", SqlDbType.NVarChar);
            param[7].Value = txtDiaChi;

            param[8] = new SqlParameter("@ghichu", SqlDbType.Text);
            param[8].Value = "";

            ViewBag.taiKhoan = tk;
            ViewBag.ketQuaThueCanHo = dp.ExecuteProcNonQuery("sp_thuecanho", ref param);
            ViewBag.isThueCanHo = true;

            return View("~/Views/Shared/DatThueCanHo.cshtml", new CanHo());
        }


        //
        // GET: /DatThueCanHo/

        public ActionResult Index()
        {
            TaiKhoan tk = isLogin();
            if (tk == null)
            {
                return Redirect("/DangNhap");
            }

            int canHoID = 0;
            CanHo ch = new CanHo();

            if (!Int32.TryParse(Request.Params["id"], out canHoID))
            {
                ch.MaTrangThaiCanHo = -999;
            }
            else
            {
                DataProvider dp = new DataProvider();

                //Load danh sach thanh pho
                string sql = @"SELECT ch.*, d.tenduong, q.tenquan, tp.tenthanhpho
                                FROM canho ch, duong d, quan q, thanhpho tp
                                WHERE ch.kichhoat = 1 AND
                                    ch.matrangthaicanho = 2 AND
                                    ch.maduong = d.maduong AND
                                    d.maquan = q.maquan AND
                                    q.mathanhpho = tp.mathanhpho AND
                                    ch.macanho = " + canHoID.ToString() + @"
                                ";
                DataTable dt = new DataTable();
                dt = dp.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    ch.MaCanHo = (int)dt.Rows[0]["macanho"];
                    ch.TenCanHo = dt.Rows[0]["tencanho"].ToString();
                    ch.MaDuong = (int)dt.Rows[0]["maduong"];
                    ch.DiaChi = dt.Rows[0]["diachi"].ToString() + " " +
                                    dt.Rows[0]["tenduong"].ToString() + ", " +
                                    dt.Rows[0]["tenquan"].ToString() + ", " +
                                    dt.Rows[0]["tenthanhpho"].ToString();
                    ch.MieuTa = dt.Rows[0]["mieuta"].ToString();
                    ch.ToaDo = dt.Rows[0]["toado"].ToString();
                    ch.GiaThue = (double)dt.Rows[0]["giathue"];
                    ch.DienTich = (double)dt.Rows[0]["dientich"];
                    ch.MaTrangThaiCanHo = (int)dt.Rows[0]["matrangthaicanho"];
                    ch.TrangThaiCanHo = (TrangThaiCanHo)dt.Rows[0]["matrangthaicanho"];
                    ch.NgayDang = DateTime.Parse(dt.Rows[0]["ngaydang"].ToString());
                    ch.NguoiDang = (int)dt.Rows[0]["nguoidang"];
                    ch.GhiChu = dt.Rows[0]["ghichu"].ToString();
                    ch.KichHoat = (int)dt.Rows[0]["kichhoat"];
                }
                else
                {
                    ch.MaTrangThaiCanHo = -999;
                }
            }

            ViewBag.taiKhoan = tk;
            ViewBag.ketQuaThueCanHo = false;
            ViewBag.isThueCanHo = false;

            return View("~/Views/Shared/DatThueCanHo.cshtml", ch);
        }

    }
}
