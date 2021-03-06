﻿function ThemHang() {
    var id = $(this).data("id");
    console.log(id);

    $.ajax({
        url: "/Cart/ThemHang",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
            if (data.status == "ok") {
            }
        }
    });

    LoadTrangThaiGioHang();
}


function LoadSanPham(e) {

    $.ajax({
        url: "/Home/ListProduct",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);

            $("#ListProduct").empty();
            var str = '';
            data.ListProduct.forEach(function (item, index) {

                str += '<div class="col-sm-4">'; str += "\n";
                str += '        <div class="product-image-wrapper">'; str += "\n";
                str += '            <div class="single-products">'; str += "\n";
                str += '                <div class="productinfo text-center">'; str += "\n";
                str += '                    <a href="/DetailProduct/index/' + item.ID + '">'; str += '\n';
                str += '                        <img src="' + item.ANH + '" alt="" style ="height: 370px;" />'; str += "\n";
                str += '                    </a>'; str += '\n';
                str += '                    <h2>' + item.GIA + 'vnd</h2>'; str += "\n";
                str += '                    <p><a href= "/DetailProduct/index/' + item.ID + '"><b>' + item.TEN + '</b></a></p>'; str += "\n";
                str += '                    <a href="\#" class="btn btn-default add-to-cart btnAdd" data-id = ' + item.ID + '><i class="fa fa-shopping-cart"></i>Add to cart</a>'; str += "\n";
                str += '                </div>'; str += "\n";
                str += '            </div>'; str += "\n";
                str += '        </div>';
                str += '</div>';
            });

            $("#ListProduct").html(str);
            $(".btnAdd").click(ThemHang);
        }
    });
}

function LoadLoaiSanPham(e) {

    $.ajax({
        url: "/Home/DsLoaiSanPham",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);

            $("#accordian").empty();
            var str = '';
            data.DsLoaiSanPham.forEach(function (item, index) {

                str += '<div class="panel panel-default"> '; str += '\n';
                str += '    <div class="panel-heading">'; str += '\n';
                str += '        <h4 class="panel-title">'; str += '\n';
                str += '            <a data-toggle="collapse" data-parent="#accordian" href="\#">'; str += '\n';
                str += '                ' + item.TEN; str += '\n';
                str += '            </a>'; str += '\n';
                str += '        </h4>'; str += '\n';
                str += '    </div>'; str += '\n';
                str += ' </div>'; str += '\n';
            });
            $("#accordian").html(str);

        }
    });
}

function LoadNhaSanXuat(e) {
    $.ajax({
        url: "/Home/dsNhaSanXuat",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);

            $("#dsNhaSanXuat").empty();
            var str = '';
            data.DsNhaSanXuat.forEach(function (item, index) {

                str += '<li><a href="\#"> <span class="pull-right">(' + item.SOLUONG + ')</span><b>' + item.TEN + '</b></a></li> ';
                str += '\n';
            });
            $("#dsNhaSanXuat").html(str);

        }
    });
}

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

$(window).ready(function () {
    LoadLoaiSanPham();
    LoadNhaSanXuat();
    LoadSanPham();
    LoadTrangThaiGioHang();

});