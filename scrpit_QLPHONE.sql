use master
go
drop database QLMobileStore
go
create database QLMobileStore
go
use QLMobileStore
go
create table PROMOCODE(
	CODE char(10) primary key,
	NgayThem date,
	NgayHetHan date,
	SoTienGiam int
)
go
Create table TAIKHOAN (
	TenTaiKhoan Varchar(50) primary key,
	MauKhau Varchar(200) NOT NULL,
	HoTen nVarchar(50) NULL,
	Sdt Varchar(10) NOT NULL,
	DiaChi nvarChar(100) not null,
	Email Varchar(50) NULL,
	GioiTinh Bit NULL,
	HienThiTK Bit default 1,
)
go
Create table NHANVIEN (
	TenTaiKhoanNV Varchar(50) NOT NULL primary key foreign key references TAIKHOAN,
	ChucVuNV nVarchar(20) NULL,
	HienThiNV bit default 1,
)
go
Create table KHUYENMAI (
	MaKhuyenMai Char(10) NOT NULL primary key,
	TenKhuyenMai nVarchar(30) NULL,
	NgayBatDau Datetime NULL,
	NgayKetThuc Datetime NULL,
	PhanTramKhuyenMai Tinyint NULL,
	HienThiKM Bit default 1,
)
go
Create table HANGSANXUAT (
	MaHangSanXuat Char(10) NOT NULL primary key,
	TenHangSanXuat varchar(50)
)
Create table DIENTHOAI (
	MaDienThoai Char(10) NOT NULL primary key,
	TenDienThoai nVarchar(100) not null,
	ManHinh Char(15) NULL,
	CameraSau Char(5) NULL,
	CameraTruoc Char(5) NULL,
	HeDieuHanh varchar(50) NULL,
	CPU varchar(50) NULL,
	--
	--
	MaKhuyenMai Char(10) null foreign key references KHUYENMAI,
	MaHangSanXuat Char(10) NULL foreign key references HANGSANXUAT,
	GiaBan Integer NULL,
	GiaNhap Integer NULL,
	SoLanTruyCap Integer default 0,
	HinhDienThoai Varchar(100) NULL,
	SoLuongTon int NULL,
	GioiThieuDienThoai nVarchar(max) NULL,
	NgayPhatHanh date NULL,
	HienThiDT Bit default 1,
)
go
Create table HOADONMUAHANG (
	MaHDMua Char(10) NOT NULL primary key,
	TinhTrangThanhToan nVarchar(10) NULL,
	ThoiGianMua date,
	TenTaiKhoan Varchar(50) NOT NULL foreign key references TAIKHOAN,
	TongTien int,
	CODE Char(10) foreign key references PROMOCODE
)
go
Create table CTHOADONMUAHANG (
	MaDienThoai Char(10) NOT NULL foreign key references DIENTHOAI,
	MaHDMua Char(10) NOT NULL foreign key references HOADONMUAHANG,
	SoLuongMua Smallint NULL,
	GiaHienHanh Integer NULL,
	primary key (MaDienThoai, MaHDMua)
)
go
Create table CTXEM (
	MaDienThoai Char(10) NOT NULL foreign key references DIENTHOAI,
	TenTaiKhoan Varchar(50) NOT NULL foreign key references TAIKHOAN,
	NgayXem datetime,
	primary key (MaDienThoai, TenTaiKhoan, NgayXem)
)
go
Create table QUANGCAO (
	MaQuangCao Char(10) NOT NULL primary key,
	TenQC nVarchar(50) NULL,
	LinkQC Varchar(200) NULL,
	HinhQC Varchar(100) NULL,
	NgayBatDauQC date NULL,
	NgayHetQC date NULL,
	ChuSoHuuQC nVarchar(50) NULL,
	SdtChuQC Char(10) NULL,
	EmailChuQC Varchar(30) NULL,
	LoaiQC varchar(20),
	HienThiQC Bit default 1,
)
go
Create table CTGIOHANG (
	MaDienThoai Char(10) foreign key references DIENTHOAI,
	TenTaiKhoan Varchar(50) foreign key references TAIKHOAN,
	SoLuongGioHang Smallint NULL,
	primary key (MaDienThoai, TenTaiKhoan)
)
go
Create table BINHLUAN (
	TenTaiKhoan Varchar(50) foreign key references TAIKHOAN,
	MaDienThoai Char(10)foreign key references DIENTHOAI,
	NoiDung nVarchar(max)NULL,
	primary key (TenTaiKhoan, MaDienThoai)
)
go
--Create table HOADONNHAPHANG (
--	MaHDNhap Char(10) NOT NULL primary key,
--	MaHangSanXuat Char(10) NULL foreign key references HANGSANXUAT,
--	SoLuongNhap integer NULL,
--	ThoiGianMua date,
--	TongTien int,
--)
--go
--Create table CTHOADONNHAPHANG (
--	MaDienThoai Char(10) NOT NULL foreign key references DIENTHOAI,
--	MaHDNhap Char(10) NOT NULL foreign key references HOADONNHAPHANG,
--	SoLuongMua Smallint NULL,
--	GiaVon Integer NULL,
--	primary key (MaDienThoai, MaHDNhap)
--)


