# BT_Tuan_3 — Ứng dụng Quản lý Tài khoản (WinForms)

## Thành viên nhóm
- MSSV: 24521245 — Tên: Trương Danh Nhân  
- MSSV: 24521216 — Tên: Trương Vĩnh Nguyên  
- MSSV: 24521227 — Tên: Đào Mạnh Nhân
- MSSV: 24521251 — Tên: Lê Ngọc Minh Nhật
- MSSV: 24521285 — Tên: Huỳnh Xuân Nin

## Mô tả bài tập
Ứng dụng WinForms (.NET 8, C# 12) cho phép:
- Đăng ký tài khoản (email, username, mật khẩu, giới tính, số điện thoại, địa chỉ, ngày sinh)
- Đăng nhập (so sánh hash mật khẩu SHA‑256)
- Mở Dashboard cho user đã xác thực
- Lưu dữ liệu người dùng vào SQLite DB (app.db)

## Tính năng chính
- Placeholder UX cho TextBox (username, password, confirm, ...)
- Kiểm tra hợp lệ email, username, mật khẩu (quy tắc: ≥8, hoa/thường/số/kí tự đặc biệt)
- Hash mật khẩu bằng SHA‑256 trước khi lưu
- DB SQLite nội bộ (app.db) tạo tự động khi chạy

## Hướng dẫn cài đặt
1. Yêu cầu:
   - Visual Studio 2022 (hoặc VS 2022+)
   - .NET 8 SDK
2. Mở solution:
   - Mở BT_Tuan_3.sln trong Visual Studio 2022.
3. Khôi phục gói:
   - _Tools > NuGet Package Manager > Package Manager Console_ (nếu cần) — thường dự án chỉ dùng Microsoft.Data.Sqlite đã included.
4. Build:
   - _Build > Build Solution_ hoặc phím tắt _Ctrl+Shift+B_.

## Hướng dẫn chạy
1. Sau khi build, chạy bằng _Debug > Start Debugging_ (F5) hoặc _Start Without Debugging_ (Ctrl+F5).
2. Khi chạy lần đầu, file app.db sẽ được tạo tại thư mục chứa file thực thi (thường bin\Debug\net8.0\).
3. Đăng ký 1 tài khoản bằng màn hình SignUp, rồi đăng nhập bằng SignIn.

## Lưu ý về database
- File DB: app.db (SQLite) nằm cùng thư mục chạy.  
- Để reset DB: xóa file app.db và chạy lại ứng dụng → bảng sẽ được tạo lại tự động.

## Giao diện (Screenshots)

![Giao diện đăng nhập](https://sv2.anhsieuviet.com/2025/10/07/image0a28eaf51b25af49.png)

*Màn hình đăng nhập với username và password*

![Giao diện đăng kí](https://sv2.anhsieuviet.com/2025/10/07/imageab5594b89ed633d0.png)

*Màn hình đăng kí tài khoản mới với form nhập thông tin đầy đủ*

![Giao diện chính](https://sv2.anhsieuviet.com/2025/10/07/c426cedc-7fb8-42c4-b368-4ec7f75f5287.jpg)

*Giao diện chính sau khi đăng nhập thành công, hiển thị danh sách người dùng*


## Vấn đề thường gặp
- Hiện ra 2 form SignUp khi bấm link "Đăng ký": nguyên nhân thường do event LinkClicked bị đăng ký hai lần — một lần trong SignIn.Designer.cs (Designer tự sinh) và một lần trong constructor SignIn() (thêm thủ công).  
  Sửa bằng cách chỉ giữ một đăng ký sự kiện. Ví dụ:
  - Xóa hoặc comment dòng thủ công this.linklb_signup.LinkClicked += linklb_signup_LinkClicked; trong SignIn() nếu Designer đã gán; hoặc xóa dòng auto-generated trong SignIn.Designer.cs nếu bạn muốn gán trong code.

## Cách đóng góp / Ghi chú
- Sửa file, commit và push lên branch của bạn. Tạo Pull Request để merge.
- Gợi ý: giữ event wiring ở một chỗ (hoặc Designer hoặc code) để tránh duplicate invocation.

## Tệp quan trọng
- Program.cs — entry point
- SignIn.cs, SignIn.Designer.cs
- SignUp.cs, SignUp.Designer.cs
- Dashboard.cs
- AppDb helper (trong SignUp.cs) — quản lý kết nối và hàm hash
