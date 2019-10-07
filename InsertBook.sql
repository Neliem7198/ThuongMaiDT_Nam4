use QLBookStore

insert into PROMOCODE values
('16DH110117','1/1/2019','1/1/2020',10000),
('16DH110118','1/1/2019','1/1/2020',100000),
('16DH110119','1/1/2019','1/1/2020',1000000);

insert into KHUYENMAI values
('KM00000001',N'Giảm 10%','2019/5/1','2019/6/30',10,1),
('KM00000002',N'Giảm 20%','2019/6/1','2019/6/20',20,1),
('KM00000003',N'Giảm 30%','2019/5/20','2019/5/31',30,1),
('KM00000004',N'Giảm 40%','2019/6/2','2019/6/10',40,1),
('KM00000005',N'Giảm 50%','2019/6/28','2019/6/29',50,1);

insert into NHAXUATBAN values
('NXB0000001','Nhà Xuất Bản Trẻ',1),
('NXB0000002','Nhà Xuất Bản Tổng hợp TP.HCM',1);

insert into THELOAI values
('VanHoc',N'Văn học',1),
('KienThucTongHop',N'Kiến thức tổng hợp',1),
('KyNangSong',N'Kỹ năng sống',1),
('ThieuNhi',N'Thiếu nhi',1),
('KinhTe', N'Kinh tế', 1),
('TruyenTranh', N'Truyện tranh', 1);

insert into SACH values
('S000000001',N'Vũ Trụ Trong Vỏ Hạt Dẻ','7698722291931','KM00000001','NXB0000001',100000,FLOOR(rand()*10000),'Image/Book/VuTruTrongVoHatDe.jpg',FLOOR(rand()*200), N'Stephen Hawking',N'Lòng khát khao khám phá luôn là động lực cho trí sáng tạo của con người trong mọi lĩnh vực không chỉ trong khoa học. Điều đó được kiểm chứng trong quyển Vũ trụ trong vỏ hạt dẻ.','3/3/2008',1,'KienThucTongHop', null, null),
('S000000002',N'Lược Sử Thời Gian','8934974144175','KM00000001','NXB0000001',87000,FLOOR(rand()*10000),'Image/Book/LuocSuThoiGian.jpg',FLOOR(rand()*200),N'Stephen Hawking',N'Cùng với Vũ trụ trong vỏ hạt dẻ, Lược sử thời gian được xem là cuốn sách nổi tiếng và phổ biến nhất về vũ trụ học của Stephen Hawking, liên tục được nằm trong danh mục sách bán chạy nhất của các tạp chí nổi tiếng thế giới.Lược sử thời gian là cuốn sử thi về sự ra đời, sự hình thành và phát triển của vũ trụ. Tác giả đưa, vào tác phẩm của mình toàn bộ tiến bộ tiến trình khám phá của trí tuệ loài người trên nhiều lĩnh vực: Triết học, Vật lý, Thiên văn học…','1/12/2016',1,'KienThucTongHop', null, null),
('S000000003',N'Ông Trăm Tuổi Trèo Qua Cửa Sổ Và Biến Mất','4509304972090','KM00000001','NXB0000001',170000,FLOOR(rand()*10000),'Image/Book/OngTramTuoi.jpg',FLOOR(rand()*200),N'Jonas Jonasson',N'Cuốn tiểu thuyết Ông trăm tuổi bốc hơi qua cửa sổ đã trở thành hiện tượng quốc gia ở Thụy Điển, đem lại cho người đọc một cái nhìn hài hước kín đáo của văn hóa Bắc Âu, nơi có truyền thống tôn quý văn học lâu đời.','1/12/2018',1,'KienThucTongHop', null, null),
('S000000004',N'Đắc Nhân Tâm','8935086838143','KM00000001','NXB0000002',76000,FLOOR(rand()*10000),'Image/Book/DacNhanTam.jpg',FLOOR(rand()*200),N'Dale Carnegie',N'Được đánh giá là cuốn sách có sức lan tỏa rộng lớn, được dịch ra hầu hết các ngôn ngữ trên thế giới và luôn nằm trong Top sách bán chạy ở mọi thị trường xuất bản, Đắc Nhân Tâm đã có đời sống xứng tầm với giá trị thực tế của mình. Đây có thể coi là một trong những cuốn sách dòng self-hepl chính thống đầu tiên. Và Ngài Dale cũng trở thành một trong những tác giả ảnh hưởng trực tiếp nhiều nhất đến sự thay đổi tích cực của hàng triệu độc giả trên thế giới.','1/3/2016',1,'KyNangSong', null, null),
('S000000005',N'Conan - Tập 40','9786042082389', null,'NXB0000002',25000,FLOOR(rand()*10000),'Image/Book/conan40.jpg',FLOOR(rand()*200),N'Aoyama Gosho',N'Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.','4/1/2017',1,'TruyenTranh', null, null),
('S000000006',N'Conan - Tập 41','9786042082389', null,'NXB0000002',25000,FLOOR(rand()*10000),'Image/Book/conan41.jpg',FLOOR(rand()*200),N'Aoyama Gosho',N'Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.','4/1/2017',1,'TruyenTranh', null, null),
('S000000007',N'Conan - Tập 42','9786042082389', null,'NXB0000002',25000,FLOOR(rand()*10000),'Image/Book/conan42.jpg',FLOOR(rand()*200),N'Aoyama Gosho',N'Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.','4/1/2017',1,'TruyenTranh', null, null),
('S000000008',N'Đọc Vị Bất Kỳ Ai (Tái Bản)','2868533384121', null,'NXB0000002',69000,FLOOR(rand()*10000),'Image/Book/doc-vi-bat-ky-ai.jpg',FLOOR(rand()*200), N'TS. David J. Lieberman',N'Bạn băn khoăn không biết người ngồi đối diện đang nghĩ gì? Họ có đang nói dối bạn không? Đối tác đang ngồi đối diện với bạn trên bàn đàm phán đang nghĩ gì và nói gì tiếp theo?','1/1/2018',1,'KinhTe', null, null),
('S000000009',N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh','1490893640473', null,'NXB0000002',125000,0,'Image/Book/aa.jpg',FLOOR(rand()*200),N'Nguyễn Nhật Ánh',N'Ta bắt gặp trong Tôi Thấy Hoa Vàng Trên Cỏ Xanh một thế giới đấy bất ngờ và thi vị non trẻ với những suy ngẫm giản dị thôi nhưng gần gũi đến lạ. Câu chuyện của Tôi Thấy Hoa Vàng Trên Cỏ Xanh có chút này chút kia, để ai soi vào cũng thấy mình trong đó, kiểu như lá thư tình đầu đời của cu Thiều chẳng hạ ngây ngô và khờ khạo. Nhưng Tôi Thấy Hoa Vàng Trên Cỏ Xanh hình như không còn trong trẻo, thuần khiết trọn vẹn của một thế giới tuổi thơ nữa. Cuốn sách nhỏ nhắn vẫn hồn hậu, dí dỏm, ngọt ngào nhưng lại phảng phất nỗi buồn, về một người cha bệnh tật trốn nhà vì không muốn làm khổ vợ con, về một người cha khác giả làm vua bởi đứa con tâm thầm của ông luôn nghĩ mình là công chúa, Những bài học về luân lý, về tình người trở đi trở lại trong day dứt và tiếc nuối. Tôi Thấy Hoa Vàng Trên Cỏ Xanh lắng đọng nhẹ nhàng trong tâm tưởng để rồi ai đã lỡ đọc rồi mà muốn quên đi thì thật khó.','12/1/2017',1,'VanHoc', null, null),
('S000000010',N'Nhà giả kim','8935235200524', null,'NXB0000002',69000,FLOOR(rand()*10000),'Image/Book/8935235213746',FLOOR(rand()*200),N'Paulo Coelho',N'Tất cả những trải nghiệm trong chuyến phiêu du theo đuổi vận mệnh của mình đã giúp Santiago thấu hiểu được ý nghĩa sâu xa nhất của hạnh phúc, hòa hợp với vũ trụ và con người.','8/1/2017',1,'VanHoc', null, null),
('S000000011',N'Lòng Tốt Của Bạn Cần Thêm Đôi Phần Sắc Sảo','8935235219472', null,'NXB0000002',108000,FLOOR(rand()*10000),'Image/Book/6783URWS.jpg',FLOOR(rand()*200),N'Mộ Nhan Ca',N'Một người có thể sống cả đời theo cách mình thích là chuyện vô cùng khó khăn. Chúng ta không giây phút nào không bị thế giới bên ngoài chỉ trỏ, lâu dần sẽ quên mất tâm tư ban sơ, mất đi khả năng suy nghĩ độc lập và giữ vững cái tôi.','11/1/2018',1,'VanHoc', null, null);

insert into TAIKHOAN values
('phatnghi','123456',N'Nguyễn Phát Nghị','0399999999','SVH','abc1@gmail.com',1,1),
('thanhhieu','123456',N'Nguyễn Thành Hiếu','0399999999','SVH','abc2@gmail.com',1,1),
('congquang','123456',N'Bùi Công Quang','0399999999','SVH','abc3@gmail.com',1,1),
('duyhau','123456',N'Vũ Nguyễn Duy Hậu','0399999999','SVH','abc5@gmail.com',1,1),
('nguyenduy','123456',N'Nguyễn Duy','0399999999','SVH','abc6@gmail.com',1,1);

insert into nhanvien values('nguyenduy','Admin', 1);

insert into QUANGCAO values ('QC00000001','quang cao a',null,'Image/QuangCao/66934858_p0.jpg','2019/06/01','2019-06-02','a','0123456789','a@gmail.com','A',1,'vitri0');

insert into CTGIOHANG values
('S000000001','phatnghi',1),
('S000000002','phatnghi',1),
('S000000003','phatnghi',1),
('S000000004','phatnghi',1),
('S000000001','thanhhieu',3),
('S000000003','congquang',10),
('S000000003','duyhau',2),
('S000000002','duyhau',1),
('S000000003','nguyenduy',2);

insert into HOADONMUAHANG values
('HD00000001','Chua','2019-1-4','phatnghi', 100000, null),
('HD00000002','Xong','2019-1-7','phatnghi', 250000, null),
('HD00000003','Chua','2019-1-8','thanhhieu', 70000, null),
('HD00000004','Xong','2019-1-10','congquang', 50000, null),
('HD00000005','Chua','2019-3-2','duyhau', 2500000, null),
('HD00000006','Xong','2019-3-15','duyhau', 1000000, null),
('HD00000007','Van chuyen',GETDATE(),'duyhau', 1000000, null),
('HD00000008','Chua',GETDATE(),'duyhau', 2500000, null),
('HD00000009','Xong',GETDATE(),'duyhau', 1000000, null)

insert into CTHOADONMUAHANG values
('S000000001','HD00000001', 1, 50000),
('S000000002','HD00000001', 1, 50000),
('S000000001','HD00000002', 2, 50000),
('S000000003','HD00000002', 3, 50000),
('S000000005','HD00000003', 1, 70000),
('S000000007','HD00000004', 1, 50000),
('S000000003','HD00000005', 2, 50000),
('S000000004','HD00000005', 1, 50000),
('S000000010','HD00000005', 1, 50000),
('S000000008','HD00000005', 1, 50000),
('S000000011','HD00000006', 10, 30000),
('S000000010','HD00000006', 10, 20000),
('S000000002','HD00000006', 10, 50000)