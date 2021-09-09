
Create Database QLKS_SML
go

Use QLKS_SML
go

--tạo bảng và thêm dữ liệu
CREATE TABLE DangNhap (
    Taikhoan nvarchar(50) NOT NULL PRIMARY KEY, -- tao khoa chinh
    Matkhau nvarchar(50),
    FullName nvarchar(50),
	Email varchar(50),
    phanquyen nvarchar(30) NOT NULL,
)
Insert into DangNhap(Taikhoan,Matkhau,FullName,Email,phanquyen) 
Values('quanly','123456',N'Nguyễn Hữu Hùng','anh@gmail.com',N'quản lý'),
('nvtmk','123456',N'Trần Mạnh Kim','hung@gmail.com',N'nhân viên'),
('nvnvd','123456',N'nguyễn văn đại','anhkh@gmail.com',N'nhân viên'),
('nvtth','123456',N'trịnh thị hoa','anhkh@gmail.com',N'nhân viên');
Create Table DichVu (
	MaDV nvarchar(15) not null primary key,
	TenDV nvarchar(500),
	giaDV int
)
Insert into DichVu (MaDV,TenDV,giaDV)
Values ('BSSV1','Giặt ủi',200000),
('BSSV2','Đưa đón sân bay',100000),
('BSSV3','Spa',150000),
('BSSV4','Điểm tâm sáng',125000),
('BSSV5','Fitness center',165000);

Create Table HDDichVu (
	MahoadonDV nvarchar(15) not null primary key,
	Makh nvarchar(15),
	MaDV nvarchar(15) not null,
	TenDV nvarchar(500),
	MaPhong nvarchar(15),
	Manv nvarchar(15),
	giaDV int,
	ngaybatdaudv datetime,
	ngaykethucdv datetime,
	phidv int

)
insert into HDDichVu (MahoadonDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv)
values ('hdsv1','kh01','BSSV1','Giặt ủi','ph01','nv01',200000,'2021-08-06 00:00:00.000','2021-08-08 00:00:00.000',400000),
('hdsv2',	'kh02'	,'BSSV3'	,'Spa',	'ph02',	'nv02',	150000,'2021-08-06 00:00:00.000','2021-08-08 00:00:00.000',300000),
('hdsv3'	,'kh03'	,'BSSV3'	,'Spa'	,'ph03'	,'nv03',150000,'2021-08-09 00:00:00.000',	'2021-08-09 00:00:00.000',150000),
('hdsv4'	,'kh04'	,'BSSV5'	,'Fitness center'	,'ph04'	,'nv04',165000,'2021-08-11 00:00:00.000',	'2021-08-11 00:00:00.000',165000);
Create TABLE Phong (
	MaPhong nvarchar(15) NOT NULL PRIMARY KEY,-- tao khoa chinh
	TenPhong nvarchar(50),
	loaiphong nvarchar(50),
	Mota nvarchar(1000),
	songtoida int,
	tthaiphong nvarchar(50) NOT NULL	
)
Insert into Phong(MaPhong,TenPhong,loaiphong,Mota,songtoida,tthaiphong) values
('ph01',N'6001',N'VIP',N'Phòng đẹp, rộng 5*15m, có cửa sổ, view đẹp nhìn ra biển',4,N'Trống'),
('ph02',N'4001',N'Standard',N'Phòng đẹp, rộng 4*6m, có cửa sổ, view hồ ',2,N'Trống'),
('ph03',N'4002',N'Superior ',N'Phòng đẹp, rộng 10*4m, có cửa sổ, view đẹp nhìn ra biển',4,N'Trống'),
('ph04',N'4003',N'Deluxe',N'Phòng đẹp, rộng 3*8m, có cửa sổ, view đẹp nhìn ra biển',4,N'Trống'),
('ph05',N'4004',N'Standard',N'Phòng đẹp, rộng 4*6m, có cửa sổ, view đẹp nhìn ra biển',2,N'Trống'),
('ph06',N'4005',N'Standard',N'Phòng đẹp, rộng 4*6m, có cửa sổ, view đẹp nhìn ra biển',2,N'Trống'),
('ph07',N'4006',N'Superior',N'Phòng đẹp, rộng 10*4m, có cửa sổ, view đẹp nhìn ra biển',4,N'Trống');
Create TABLE TTthuephong (
	MaThuep nvarchar(15) not null primary key,-- tao khoa chinh
	MaPhong nvarchar(15) NOT NULL ,
	Makh nvarchar(15),
	Manv nvarchar(15),
	TenPhong nvarchar(50),
	loaiphong nvarchar(50),
	Ngaydatphong datetime,
	Ngaynhanphong datetime,
	giaphong int,
	songuoi int not null,
	trangthai nvarchar(50) NOT NULL,
)
--insert into TTthuephong (MaThuep,MaPhong,Makh,Manv,TenPhong,loaiphong,Ngaydatphong,Ngaynhanphong,giaphong,songuoi,trangthai)
--values ('th01',	'ph01',	'kh01',	'nv01',	'6001',	'VIP','2021-08-01 00:00:00.000','2021-08-06 00:00:00.000',600000,2,'Đã trả'),
--		('th02'	,'ph02'	,'kh02'	,'nv02'	,'4001'	,'Standard','2001-01-01 00:00:00.000','2001-01-01 00:00:00.000'	,300000,1,'	Đã trả'),
---		('th03'	,'ph03'	,'kh03'	,'nv03'	,'4002'	,'Superior' ,'2001-08-09 00:00:00.000','2001-08-09 00:00:00.000',400000,2,'	Đã trả'),
--		('th04'	,'ph08'	,'kh04'	,'nv04'	,'6002'	,'VIP','2021-08-09 00:00:00.000','2021-08-11 00:00:00.000',600000,3,'Đã trả');
Create Table LPhong
(
	loaiphong nvarchar(50) NOT NULL PRIMARY KEY,
	mota nvarchar(50),
	giaphong int
)
Insert into LPhong(loaiphong,mota,giaphong) Values
('VIP',N'Phòng cao cấp',600000),
('Deluxe',N'Phòng trung cấp',500000),
('Superior',N'Phòng thường',400000),
('Standard',N'Phòng bình dân',300000);
CREATE TABLE Khachhang (
    Makh nvarchar(15) NOT NULL PRIMARY KEY,-- tao khoa chinh
    Tenkh nvarchar(50),
    Ngaysinh datetime,
    gioitinh nvarchar(10),
    sdt nvarchar(10),
	Cmnd nvarchar(30),
	quoctich nvarchar(500), 
)
Insert into Khachhang(MaKh,Tenkh,Ngaysinh,gioitinh,sdt,Cmnd,quoctich) values
('kh01',N'Đoàn Duy Khanh','1993-02-03',N'Nam',0386123242,'146582362','Việt nam'),
('kh02',N'Trần Doãn Mạnh','1992-12-05',N'Nam',0386427880,'146582895','Việt nam'),
('kh03',N'Trần Văn Minh','1996-09-11',N'Nam' ,0366421315,'146582662','Việt nam'),
('kh04',N'Trần Hoài Nam','1999-01-14',N'Nam' ,0976445444,'146582321','Việt nam');
CREATE TABLE Nhanvien (
    Manv nvarchar(15) NOT NULL PRIMARY KEY, -- tao khoa chinh
    Tennv nvarchar(50),
    Ngaysinh datetime,
    gioitinh nvarchar(10),
    sdt nvarchar(15),
	Cmnd nvarchar(30),
	Email nvarchar(500), 
	Taikhoan nvarchar(50),
	chucvu nvarchar(60)
)
Insert into Nhanvien(Manv,Tennv,Ngaysinh,gioitinh,sdt,Cmnd,Email,Taikhoan,chucvu) 
Values ('nv02',	'Trần Mạnh Kim',	'1998-12-15 00:00:00.000',	'Nam',	'0366524687',	'145715189',	'hieptr.hh@gmail.com',	'nvtmk',	'nhân viên'),
		('nv03', 'nguyễn văn đại',	'1999-03-02 00:00:00.000',	'Nam',	'0385145235',	'145715125'	,'namhv.hh@gmail.com',	'nvnvd',	'nhân viên'),
		('nv04', 'trịnh thị hoa',	'2000-06-07 00:00:00.000',	'Nữ',	'0366888521',	'154862123',	'linhtt.hh@gmail.com',	'nvtth',	'nhân viên'),
		('nvql01',	'Nguyễn Hữu Hùng',	'1996-08-25 00:00:00.000',	'Nam',	'0386140000',	'145715186',	'anhth.hh@gmail.com',	'quanly',	'quản lý ');
select * from Nhanvien
Create Table Hoadon
(
	Mahoadon nvarchar(15) not null primary key,
	MaThuep nvarchar(15) not null,
	MaPhong nvarchar(15)not null,
	Makh nvarchar(15),
	Manv nvarchar(15),
	Ngaydatphong datetime,
	Ngaynhanphong datetime,
	Ngaytraphong datetime,
	soluongnguoi int,
	phiphong int,

)
--insert into Hoadon (Mahoadon,Mathuep,MaPhong,Makh,Manv,Ngaydatphong,Ngaynhanphong,Ngaytraphong,soluongnguoi,phiphong)
--values ('HD01',	'th01',	'ph01',	'kh01',	'nv01',	'2021-08-01 00:00:00.000',	'2021-08-06 00:00:00.000',	'2021-08-08 00:00:00.000',	2,	2400000),
--		('HD02','th02',	'ph02',	'kh02',	'nv02',	'2001-01-01 00:00:00.000',	'2001-01-01 00:00:00.000',	'2001-01-05 00:00:00.000',	1,	1200000),
--		('HD03','th03',	'ph03',	'kh03',	'nv03',	'2001-08-09 00:00:00.000',	'2001-08-09 00:00:00.000',	'2001-08-09 00:00:00.000',	2,	800000),
--		('HD04','th04',	'ph08',	'kh04',	'nv04',	'2021-08-09 00:00:00.000',	'2021-08-11 00:00:00.000',	'2021-08-11 00:00:00.000',	3,	1800000);