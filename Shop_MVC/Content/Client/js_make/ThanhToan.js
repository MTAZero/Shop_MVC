$(window).ready(function () {
    LoadGioHang();
    $("#btnThanhToan").click(ThanhToan);
});

function LoadTrangThaiGioHang() {
    $.ajax({
        url: "/Cart/SoLuong",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            $("#TrangThaiGioHang").html("Giỏ hàng (" + data.SoLuong + ")");
        }
    });
}

function LoadGioHang() {
    $.ajax({
        url: "/Cart/DanhSach",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);

            var str = '';
            data.Carts.forEach(function (item, index) {
                str += '<tr>'; str += '\n';
                str += '    <td class="cart_product">'; str += '\n';
                str += '        <a href="/DetailProduct/Index/' + item.ID + '"><img src="' + item.Anh + '" alt="" style="width: 66px; height: 100px;"></a>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '    <td class="cart_description">'; str += '\n';
                str += '        <h4><a href="/DetailProduct/Index/' + item.ID + '"><b>' + item.Ten + '</b></a></h4>'; str += '\n';
                str += '        <p>ID : ' + item.Ma + '</p>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '    <td class="cart_price">'; str += '\n';
                str += '        <p>' + item.Gia + ' vnd</p>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '    <td class="cart_quantity">'; str += '\n';
                str += '        <div class="cart_quantity_input" style="width: 50px;"> <p> ' + item.SoLuong + ' </p> </div>'; str += '\n';
                str += '        </div>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '    <td class="cart_total">'; str += '\n';
                str += '        <p class="cart_total_price">' + item.ThanhTien + ' vnd</p>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '</tr>'; str += '\n';
            });

            str += '<tr>'; str += '\n';
            str += '      <td colspan="4">&nbsp;</td>'; str += '\n';
            str += '      <td colspan="2">'; str += '\n';
            str += '          <table class="table table-condensed total-result">'; str += '\n';
            str += '              <tr>'; str += '\n';
            str += '                  <td>Thành tiền</td>'; str += '\n';
            str += '                  <td>' + data.TongTien + ' vnd</td>'; str += '\n';
            str += '              </tr>'; str += '\n';
            str += '              <tr>'; str += '\n';
            str += '                  <td>VAT</td>'; str += '\n';
            str += '                  <td>' + data.VAT + ' vnd</td>'; str += '\n';
            str += '              </tr>'; str += '\n';
            str += '              <tr class="shipping-cost">'; str += '\n';
            str += '                  <td>Chi phí vận chuyển</td>'; str += '\n';
            str += '                  <td>' + data.PhiVanChuyen + ' vnd</td>'; str += '\n';
            str += '              </tr>'; str += '\n';
            str += '              <tr>'; str += '\n';
            str += '                  <td>Tổng cộng</td>'; str += '\n';
            str += '                  <td><span>' + data.ThanhTien + ' vnd</span></td>'; str += '\n';
            str += '              </tr>'; str += '\n';
            str += '          </table>'; str += '\n';
            str += '      </td>'; str += '\n';
            str += '  </tr>'; str += '\n';
            $("#GioHang").html(str);
        }
    });

    LoadTrangThaiGioHang();
}

function ThanhToan() {
    var sdt = $("#SDTTT").val();
    var diachi = $("#DiaChiTT").val();
    var yeucau = $("#YeuCauMuaHangTT").val();

    

    if (sdt == "" || diachi == "" || yeucau == "") {
        alert("Nhập thông tin chưa đầy đủ");
        return;
    }

    console.log("yezzz");
    
    $.ajax({
        url: "/Cart/ThanhToan",
        data: { SDT: sdt, DiaChi: diachi, YeuCau: yeucau },
        dataType: "json",
        type: "POST",
        success: function (data) {
            if (data.ok == true) {
                alert("Đơn hàng đã được chấp nhận\nQuý khách sẽ thanh toán khi nhận được hàng\nCảm ơn bạn đã sử dụng dịch vụ\n");
                window.location.href = "/Home/Index";
                return;
            }
            else {
                alert(data.exception);

            }
        }
    });
}
