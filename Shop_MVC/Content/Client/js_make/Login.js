﻿$(window).ready(function () {
    //alert("Hello! Have a nice day!");
    //window.location.href("/Home/Index");
    $("#btnDangNhap").click(DangNhap);
    $("#btnDangKy").click(DangKy);
});

function DangNhap() {
    var email = $("#EmailDN").val();
    var matkhau = $("#MatKhauDN").val();
    var ok = true;

    $.ajax({
        url: "/Login/DangNhap",
        data: { Email: email, MatKhau: matkhau },
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);
            ok = data.ok;

            if (ok == true) {
                alert("Đăng nhập thành công");
                $("#FormDangNhap").submit();
            }
            else {
                alert("Đăng nhập thất bại");
            }
        }
    });
    
}

function DangKy() {
    var HoTen = $("#HoTenDK").val();
    var Email = $("#EmailDK").val();
    var MatKhau = $("#MatKhauDK").val();
    var MatKhauXacNhan = $("#XacNhanMatKhauDK").val();

    console.log(MatKhau);
    console.log(MatKhauXacNhan);

    if (HoTen == "" ||  Email == "" || MatKhau == "" || MatKhauXacNhan == "") {
        alert("Thông tin nhập chưa đầy đủ");
        return;
    }

    if (MatKhau != MatKhauXacNhan) {
        alert("Mật khẩu xác nhận không chính xác");
        return;
    }

    $.ajax({
        url : "/Login/DangKy",
        data : {Email: Email, HoTen: HoTen, MatKhau: MatKhau},
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);  
            if (data.status == false) {
                alert(data.message);
                return;
            }

            alert("Đăng ký thành công");
            $("#FormDangKy").submit();
        }
    });

}