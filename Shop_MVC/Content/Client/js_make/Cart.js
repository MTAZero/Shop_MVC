$(window).ready(function () {
    LoadGioHang();
    $("#btnCapNhat").click(LoadGioHang);
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
                str += '        <div class="cart_quantity_button">'; str += '\n';
                str += '            <a class="cart_quantity_up btnUp" href="\#" data-id = ' + item.ID + '> + </a>'; str += '\n';
                str += '            <div class="cart_quantity_input" style="width: 50px;"> <p> ' + item.SoLuong + ' </p> </div>'; str += '\n';
                str += '                <a class="cart_quantity_down btnDown" href="\#" data-id = ' + item.ID + '> - </a>'; str += '\n';
                str += '            </div>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '    <td class="cart_total">'; str += '\n';
                str += '        <p class="cart_total_price">' + item.ThanhTien + ' vnd</p>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '    <td class="cart_delete">'; str += '\n';
                str += '        <a class="cart_quantity_delete btnDelete" data-id=' + item.ID + ' href="\#"><i class="fa fa-times"></i></a>'; str += '\n';
                str += '    </td>'; str += '\n';
                str += '</tr>'; str += '\n';
            });
            $("#GioHang").html(str);

            $("#TongTien").html(data.TongTien + " vnd");
            $("#VAT").html(data.VAT + " vnd");
            $("#PhiVanChuyen").html(data.PhiVanChuyen + " vnd");
            $("#ThanhTien").html(data.ThanhTien + " vnd");

            $(".btnUp").click(ThemHang);
            $(".btnDown").click(GiamHang);
            $(".btnDelete").click(XoaHang);
        }
    });

    LoadTrangThaiGioHang();
}

function ThemHang() {
    var id = $(this).data("id");

    $.ajax({
        url: "/Cart/ThemHang",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
        }
    });

    LoadGioHang();
}

function GiamHang() {
    var id = $(this).data("id");

    $.ajax({
        url: "/Cart/GiamHang",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
        }
    });

    LoadGioHang();
}

function XoaHang() {
    var id = $(this).data("id");
    console.log(id);

    $.ajax({
        url: "/Cart/XoaHang",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
        }
    });

    LoadGioHang();
}
