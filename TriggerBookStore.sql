use QLBookStore
go


create trigger trg_NV_CV
	on NHANVIEN
	for insert, update
as
	if (select ChucVuNV from inserted) not in ('Admin', 'Manager')
	begin
		raiserror('Chức vụ không hợp lệ',16,1)
		rollback tran

	end

go
/*Check khuyen mai phan tram*/
create trigger trg_KM_PT
	on KHUYENMAI
	for insert, update
as
	if not ((select PhanTramKhuyenMai from inserted) between 0 and 100)
	begin
		raiserror('Phần trăm khuyến mãi từ 0 - 100%',16,1)
		rollback tran
	end

go
/*Check QC Date*/
create trigger trg_QC_Date
	on QUANGCAO
	for insert, update
as
	if ((select NgayHetQC from inserted) < (select NgayBatDauQC from inserted))
	begin
		raiserror('Ngày hết quảng cáo phải hơn ngày bắt đầu',16,1)
		rollback tran
	end