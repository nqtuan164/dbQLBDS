﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbQLBDS.Models
{
    public class ThueCanHoModel
    {
        private int maThueCanHo;
        private int maTaiKhoan;
        private int maCanHo;
        private float tienCoc;
        private DateTime thoiGianThue;
        private DateTime thoiGianKetThuc;
        private DateTime thoiGianGiaoDich;
        private string dienThoai;
        private string diaChi;
        private string ghiChu;
        private int kichHoat;

        public int MaThueCanHo
        {
            get { return maThueCanHo; }
            set { maThueCanHo = value; }
        }
        public int MaTaiKhoan
        {
            get { return maTaiKhoan; }
            set { maTaiKhoan = value; }
        }
        public int MaCanHo
        {
            get { return maCanHo; }
            set { maCanHo = value; }
        }
        public float TienCoc
        {
            get { return tienCoc; }
            set { tienCoc = value; }
        }
        public DateTime ThoiGianThue
        {
            get { return thoiGianThue; }
            set { thoiGianThue = value; }
        }
        public DateTime ThoiGianKetThuc
        {
            get { return thoiGianKetThuc; }
            set { thoiGianKetThuc = value; }
        }
        public DateTime ThoiGianGiaoDich
        {
            get { return thoiGianGiaoDich; }
            set { thoiGianGiaoDich = value; }
        }
        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public int KichHoat
        {
            get { return kichHoat; }
            set { kichHoat = value; }
        }

        public ThueCanHoModel(int _maThueCanHo, int _maTaiKhoan, int _maCanHo, float _tienCoc, DateTime _thoiGianThue,
                            DateTime _thoiGianKetThuc, DateTime _thoiGianGiaoDich, string _dienThoai, string _diaChi,
                            string _ghiChu, int _kichHoat)
        {
            this.maThueCanHo = _maThueCanHo;
            this.maTaiKhoan = _maTaiKhoan;
            this.maCanHo = _maCanHo;
            this.tienCoc = _tienCoc;
            this.thoiGianThue = _thoiGianThue;
            this.thoiGianKetThuc = _thoiGianKetThuc;
            this.thoiGianGiaoDich = _thoiGianGiaoDich;
            this.dienThoai = _dienThoai;
            this.diaChi = _diaChi;
            this.ghiChu = _ghiChu;
            this.kichHoat = _kichHoat;
        }
    }
}