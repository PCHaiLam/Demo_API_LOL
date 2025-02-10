graph TD
    A[Hệ thống Quản lý Nhà hàng] --> B[Quản lý Đặt bàn]
    A --> C[Quản lý Order]
    A --> D[Quản lý Menu]
    A --> E[Quản lý Người dùng]
    A --> F[Báo cáo & Thống kê]
    
    B --> B1[Đặt bàn online]
    B --> B2[Quản lý bàn trống]
    B --> B3[Xác nhận đặt bàn]
    B --> B4[Hủy đặt bàn]
    
    C --> C1[Order tại bàn]
    C --> C2[Order online]
    C --> C3[Quản lý trạng thái order]
    C --> C4[Thanh toán]
    
    D --> D1[Thêm/sửa/xóa món]
    D --> D2[Quản lý danh mục]
    D --> D3[Quản lý giá]
    D --> D4[Quản lý khuyến mãi]
    
    E --> E1[Quản lý khách hàng]
    E --> E2[Quản lý nhân viên]
    E --> E3[Phân quyền]
    E --> E4[Đánh giá & phản hồi]
    
    F --> F1[Báo cáo doanh thu]
    F --> F2[Thống kê đơn hàng]
    F --> F3[Phân tích khách hàng]
    F --> F4[Dự báo & phân tích xu hướng]

    C1 --> C11[Ghi nhận order]
    C1 --> C12[Chuyển bếp]
    C1 --> C13[Cập nhật trạng thái]
    
    C2 --> C21[Xem menu]
    C2 --> C22[Thêm vào giỏ hàng]
    C2 --> C23[Xác nhận đơn hàng]
    
    C4 --> C41[Thanh toán tiền mặt]
    C4 --> C42[Thanh toán online]
    C4 --> C43[Xuất hóa đơn]
    
    E1 --> E11[Quản lý thông tin KH]
    E1 --> E12[Lịch sử giao dịch]
    E1 --> E13[Chương trình thân thiết]
    
    F1 --> F11[Doanh thu theo ngày]
    F1 --> F12[Doanh thu theo tháng]
    F1 --> F13[Doanh thu theo món]
