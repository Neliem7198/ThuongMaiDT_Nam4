alter table QUANGCAO add ViTriQuangCao varchar(100) null
use QLMobileStore
go
insert into Taikhoan values('hieu7198','123','Nguyen Thanh Hieu','0933600993','','hieu@gmail.com',1,1)
go
insert into  Nhanvien values ('hieu7198','Admin',1)
go
alter table HANGSANXUAT add HienThiTL Bit default 1
go
insert into HANGSANXUAT values('samsung','SamSung',1)
insert into HANGSANXUAT values('apple','Apple',1)
insert into HANGSANXUAT values('nokia','Nokia',1)
insert into HANGSANXUAT values('xiaomi','Xiaomi',1)