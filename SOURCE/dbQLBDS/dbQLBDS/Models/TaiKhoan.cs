using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public enum LoaiTaiKhoan
    {
        Admin = 1,
        Member = 2,
        Sales = 3
    }

    public class TaiKhoan
    {
        int maTaiKhoan;
        string email;
        string matKhau;
        LoaiTaiKhoan maLoaiTaiKhoan;
        string ten;
        DateTime ngaySinh;
        string diaChi;
        string dienThoai;
        DateTime ngayDangKy;
        int trangThai;

        public int MaTaiKhoan
        {
            get { return maTaiKhoan; }
            set { maTaiKhoan = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public LoaiTaiKhoan MaLoaiTaiKhoan
        {
            get { return maLoaiTaiKhoan; }
            set { maLoaiTaiKhoan = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }

        public DateTime NgayDangKy
        {
            get { return ngayDangKy; }
            set { ngayDangKy = value; }
        }

        public int TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public TaiKhoan()
        {
            this.maTaiKhoan = 0;
            this.email = "";
            this.matKhau = "";
            this.maLoaiTaiKhoan = 0;
            this.ten = "";
            this.ngaySinh = DateTime.Now;
            this.diaChi = "";
            this.dienThoai = "";
            this.ngayDangKy = DateTime.Now;
            this.trangThai = 0;
        }

        public TaiKhoan(int matk, 
                        string mail, 
                        string matkhau, 
                        LoaiTaiKhoan maloai, 
                        string Ten, 
                        DateTime ngaysinh, 
                        string diachi, 
                        string dienthoai, 
                        DateTime ngaydk, 
                        int trangthai)
        {
            this.maTaiKhoan = matk;
            this.email = mail;
            this.matKhau = matkhau;
            this.maLoaiTaiKhoan = maloai;
            this.ten = Ten;
            this.ngaySinh = ngaysinh;
            this.diaChi = diachi;
            this.dienThoai = dienthoai;
            this.ngayDangKy = ngaydk;
            this.trangThai = trangthai;
        }

    }
}