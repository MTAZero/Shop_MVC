$(window).ready(function () {
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
                window.location.href = "/Home/Index";
            }
            else {
                alert("Đăng nhập thất bại");
            }
        }
    });
    
    
   
}

function DangKy() {

}