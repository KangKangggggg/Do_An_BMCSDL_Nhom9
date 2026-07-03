# Ứng dụng Quản lý Nhân viên — Bảo mật Cơ sở Dữ liệu (Đề 5)

## Giới thiệu đồ án

Đây là đồ án môn **Bảo mật Cơ sở Dữ liệu**, xây dựng ứng dụng quản lý nhân viên với hệ thống phân quyền theo phòng ban trên nền tảng **Oracle Database**, kết hợp ứng dụng desktop viết bằng **C# (.NET Windows Forms)**.

Hệ thống áp dụng đồng thời nhiều cơ chế bảo mật ở tầng lõi cơ sở dữ liệu — **Oracle Roles**, **Virtual Private Database (VPD)** để giới hạn quyền truy cập theo từng dòng dữ liệu, và **Database Trigger** để tự động ghi nhật ký kiểm toán (audit log) cho mọi thay đổi trên dữ liệu nhân viên. Nhờ đó, việc phân quyền không chỉ dừng lại ở giao diện ứng dụng mà được đảm bảo tuyệt đối ngay tại tầng cơ sở dữ liệu, kể cả khi truy cập bằng công cụ khác ngoài ứng dụng chính thức.

### Chính sách phân quyền chính

| Vai trò | Quyền hạn |
|---|---|
| **Nhân viên thường** | Chỉ xem đồng nghiệp cùng phòng, không xem lương, không chỉnh sửa |
| **Trưởng phòng** | Xem mọi thông tin trong phòng (kể cả lương), không chỉnh sửa |
| **Nhân viên HR** | Xem và sửa mọi nhân viên trong công ty, trừ đồng nghiệp cùng phòng HR |
| **Trưởng phòng HR** | Toàn quyền, đồng thời giám sát nhật ký thao tác của nhân viên HR qua Audit Log |
| **Kế toán** | Áp dụng như nhân viên thường, được xem thêm mã nhân viên, lương, mã số thuế của toàn công ty |

---

## Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Hệ quản trị CSDL | Oracle Database |
| Ngôn ngữ ứng dụng | C# (.NET, Windows Forms) |
| Kết nối dữ liệu | Oracle.ManagedDataAccess (ODP.NET) |
| Công cụ quản trị | Oracle SQL Developer |

---

## Thành viên nhóm

| STT | Họ và tên | MSSV | Nhiệm vụ đảm nhận |
|---|---|---|---|
| 1 | Đoàn Vĩnh Phát | 23110283 | Nền tảng Database + Nhân viên thường |
| 2 | Nguyễn Hoàng Tâm | 23110313 | Trưởng phòng + Phòng Kế toán |
| 3 | Huỳnh Tấn Vinh | 23110365 | Phòng Nhân sự (HR) — VPD, Trigger Audit Log, CRUD C# |
| 4 | Huỳnh Trần Thùy Linh | 23110253 | Tích hợp & Kiểm thử toàn hệ thống |

> **Ghi chú:** mỗi thành viên đảm nhận đủ 3 tầng của module được phân công (Oracle Database — Business Layer — Giao diện người dùng), đảm bảo toàn bộ nhóm đều nắm được kiến trúc tổng thể của hệ thống, không chỉ riêng phần việc của mình.

---

## Lời cảm ơn

Nhóm xin chân thành cảm ơn giảng viên đã tận tình hướng dẫn trong suốt quá trình thực hiện đồ án. Trong quá trình xây dựng, nhóm đã gặp và tự khắc phục được nhiều vấn đề thực tế của bảo mật cơ sở dữ liệu ở mức chuyên sâu (ví dụ: cơ chế vô hiệu hoá role trong Definer's Rights của PL/SQL, hành vi "chặn âm thầm" của VPD khi không phát sinh exception...), qua đó hiểu rõ hơn bản chất vận hành của Oracle Security thay vì chỉ dừng lại ở lý thuyết.
