using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class ChiTietCanHoController : Controller
    {
        //
        // GET: /CanHo/

        public ActionResult Index()
        {
            bool fixDirtyRead = true;
            Boolean.TryParse(Request.Params["dirtyread"], out fixDirtyRead);

            int canHoID = 0;
            CanHo ch = new CanHo();

            if (!Int32.TryParse(Request.Params["id"], out canHoID))
            {
                ch.MaTrangThaiCanHo = -999;
            }

            else
            {
                DataProvider dp = new DataProvider();
                string sql = "";
                //Load danh sach thanh pho
                /*string sql = @"SELECT ch.*, d.tenduong, q.tenquan, tp.tenthanhpho
                                FROM canho ch, duong d, quan q, thanhpho tp
                                WHERE ch.kichhoat = 1 AND
                                    ch.matrangthaicanho = 2 AND
                                    ch.maduong = d.maduong AND
                                    d.maquan = q.maquan AND
                                    q.mathanhpho = tp.mathanhpho AND
                                    ch.macanho = " + canHoID.ToString() + @"
                                ORDER BY ch.ngaydang DESC
                                ";*/

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@macanho", SqlDbType.Int);
                param[0].Value = canHoID.ToString();

                DataTable dt = new DataTable();

                if (fixDirtyRead == true)
                {
                    dt = dp.ExecuteProcQuery("sp_XemCanHo_Fixed", ref param);
                }
                else
                {
                    dt = dp.ExecuteProcQuery("sp_XemCanHo", ref param);
                }

                

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


                    //Lay hinh anh
                    sql = @"SELECT *
                            FROM hinhanhcanho
                            WHERE macanho = " + canHoID.ToString();
                    dt = new DataTable();
                    dt = dp.ExecuteQuery(sql);
                    List<HinhAnhCanHo> dsHinhAnhCanHo = new List<HinhAnhCanHo>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HinhAnhCanHo h = new HinhAnhCanHo();
                        h.MaHinhAnh = (int)dt.Rows[i]["mahinhanh"];
                        h.LienKet = dt.Rows[i]["lienket"].ToString();
                        h.MaCanHo = canHoID;

                        dsHinhAnhCanHo.Add(h);
                    }
                    ViewBag.dsHinhAnhCanHo = dsHinhAnhCanHo;


                    //Lay thong tin nguoi dang tin
                    sql = @"SELECT *
                            FROM taikhoan
                            WHERE mataikhoan = " + ch.NguoiDang.ToString();
                    dt = new DataTable();
                    dt = dp.ExecuteQuery(sql);

                    TaiKhoan tk = new TaiKhoan();
                    tk.MaTaiKhoan = (int)dt.Rows[0]["mataikhoan"];
                    tk.Email = dt.Rows[0]["email"].ToString();
                    tk.MaLoaiTaiKhoan = (int)dt.Rows[0]["maloaitaikhoan"];
                    tk.LoaiTaiKhoan = (LoaiTaiKhoan)dt.Rows[0]["maloaitaikhoan"];
                    tk.Ten = dt.Rows[0]["ten"].ToString();
                    tk.NgaySinh = (DateTime)dt.Rows[0]["ngaysinh"];
                    tk.DiaChi = dt.Rows[0]["diachi"].ToString();
                    tk.DienThoai = dt.Rows[0]["dienthoai"].ToString();
                    tk.NgayDangKy = (DateTime)dt.Rows[0]["ngaydangky"];
                    tk.MaTrangThai = (int)dt.Rows[0]["trangthai"];
                    tk.TrangThai = (TrangThaiTaiKhoan)dt.Rows[0]["trangthai"];

                    ViewBag.taiKhoan = tk;
                }
                else
                {
                    ch.MaTrangThaiCanHo = -999;
                }
            }


            return View("~/Views/Shared/ChiTietCanHo.cshtml", ch);
        }


    }
}
