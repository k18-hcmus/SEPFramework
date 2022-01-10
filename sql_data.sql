use StudentManagement
go

-- nhập liệu cho bảng Khóa Học
Insert into Khoa(Ma_Khoa, Ten_Khoa, Nam_Thanh_Lap) values( 'CNTT', N'Công nghệ thông tin',1995)
go
Insert into Khoa values('VL', N'Vật Lý' , 1970)
go


-- nhập liệu cho bảng Khóa Học
Insert into Khoa_Hoc(Nam_Bat_Dau, Ma_Khoa_Hoc, Nam_Ket_Thuc) values( 2002, 'K2002',2006)
go
Insert into Khoa_Hoc values('K2003', 2003, 2007)
go
Insert into Khoa_Hoc values('K2004', 2004, 2008)
go


-- Nhập liệu cho bảng Chương trình học
Insert into Chuong_Trinh_Hoc values('CQ', N'Chính Quy')
go

-- nhập liệu cho bảng Lớp
Insert into Lop values('TH2002/01', 'CNTT','K2002', 'CQ', 1)
go
Insert into Lop values('TH2002/02', 'CNTT','K2002', 'CQ', 2)
go
Insert into Lop values('TH2003/01', 'VL','K2003', 'CQ', 1)
go

-- Nhập liệu cho sinh viên
Insert into Sinh_Vien values('0212001', N'Nguyễn Vĩnh An', 1984, N'Kinh', 'TH2002/01')
go
Insert into Sinh_Vien values('0212002', N'Nguyễn Thanh Bình', 1985, N'Kinh', 'TH2002/01')
go
Insert into Sinh_Vien values('0212003', N'Nguyễn Thanh Cường', 1984, N'Kinh', 'TH2002/02')
go
Insert into Sinh_Vien values('0212004', N'Nguyễn Quốc Duy', 1983, N'Kinh', 'TH2002/02')
go
Insert into Sinh_Vien values('0311001', N'Phan Tuấn Anh', 1985, N'Kinh', 'TH2003/01')
go
Insert into Sinh_Vien values('0311002', N'Huỳnh Thanh Sang', 1984, N'Kinh', 'TH2003/01')
go

-- Nhập liệu cho bảng Môn học
Insert into Mon_Hoc values('THT01', 'CNTT', N'Toán cao cấp A1')
go
Insert into Mon_Hoc values('VLT01', 'VL', N'Toán cao cấp A1')
go
Insert into Mon_Hoc values('THT02', 'CNTT', N'Toán rời rạc')
go
Insert into Mon_Hoc values('THCS01', 'CNTT', N'Cấu trúc dữ liệu 1')
go
Insert into Mon_Hoc values('THCS02', 'CNTT', N'Hệ điều hành')
go

-- Nhập liệu cho bảng Kết quả
Insert into Ket_Qua values('0212001', 'THT01', 1,4)
go
Insert into Ket_Qua values('0212001', 'THT01', 2,7)
go
Insert into Ket_Qua values('0212002', 'THT01', 1,8)
go
Insert into Ket_Qua values('0212003', 'THT01', 1,6)
go
Insert into Ket_Qua values('0212004', 'THT01', 1,9)
go
Insert into Ket_Qua values('0212001', 'THT02', 1,8)
go
Insert into Ket_Qua values('0212002', 'THT02', 1,5.5)
go
Insert into Ket_Qua values('0212003', 'THT02', 1,4)
go
Insert into Ket_Qua values('0212003', 'THT02', 2,6)
go
Insert into Ket_Qua values('0212001', 'THCS01', 1,6.5)
go
Insert into Ket_Qua values('0212002', 'THCS01', 1,4)
go
Insert into Ket_Qua values('0212003', 'THCS01', 1,7)
go

-- Nhập liệu cho bảng Giảng Khoa
Insert into Giang_Khoa values('CQ', 'CNTT', 'THT01',2003, 1, 60, 30, 5)
go
Insert into Giang_Khoa values('CQ', 'CNTT', 'THT02',2003, 2, 45, 30, 4)
go
Insert into Giang_Khoa values('CQ', 'CNTT', 'THCS01',2004, 1, 45, 30, 4)
go