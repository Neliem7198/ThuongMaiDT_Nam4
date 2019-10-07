use master
go
drop database QLBookStore
go
create database QLBookStore
go
use QLBookStore
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
Create table NHAXUATBAN (
	MaNhaXuatBan Char(10) NOT NULL primary key,
	TenNhaXuatBan Nvarchar(50) NULL,
	SoDauSachXB Smallint NULL,
)
go
Create table THELOAI (
	MaTheLoai varchar(30) NOT NULL primary key,
	TenTheLoai nVarchar(30) NULL,
	HienThiTL Bit default 1,
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
Create table SACH (
	MaSach Char(10) NOT NULL primary key,
	TenSach nVarchar(100) not null,
	SKU varchar(20) null,
	MaKhuyenMai Char(10) null foreign key references KHUYENMAI,
	MaNhaXuatBan Char(10) NULL foreign key references NHAXUATBAN,
	GiaBan Integer NULL,
	SoLanTruyCap Integer default 0,
	HinhSach Varchar(100) NULL,
	SoLuongTon int NULL,
	TenTacGia nVarchar(50) NULL,
	GioiThieuSach nVarchar(max) NULL,
	NgayXuatBan date NULL,
	HienThiS Bit default 1,

	MaTL1 varchar(30) null foreign key references THELOAI,
	MaTL2 varchar(30) null foreign key references THELOAI,
	MaTL3 varchar(30) null foreign key references THELOAI,
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
	MaSach Char(10) NOT NULL foreign key references SACH,
	MaHDMua Char(10) NOT NULL foreign key references HOADONMUAHANG,
	SoLuongMua Smallint NULL,
	GiaHienHanh Integer NULL,
	primary key (MaSach, MaHDMua)
)
go
Create table CTXEMSACH (
	MaSach Char(10) NOT NULL foreign key references SACH,
	TenTaiKhoan Varchar(50) NOT NULL foreign key references TAIKHOAN,
	NgayXemSach datetime,
	primary key (MaSach, TenTaiKhoan, NgayXemSach)
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
	MaSach Char(10) foreign key references SACH,
	TenTaiKhoan Varchar(50) foreign key references TAIKHOAN,
	SoLuongGioHang Smallint NULL,
	primary key (MaSach, TenTaiKhoan)
)

alter table QUANGCAO add ViTriQuangCao varchar(100) null