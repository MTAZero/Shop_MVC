function LoadChiTietSanPham(e) {
    var k = $("#Main");
    var id = k.data('content');
    //console.log(id);

    $.ajax({
        url: "/DetailProduct/ThongTinSanPham",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
            //console.log(data);
            $("#NhaSanXuat").html(' ' + data.NhaSanXuat);
            $("#AnhSP").attr("src", data.Anh);

            // danh sách các sản phẩm liên quan
            $("#SanPhamLienQuan").empty();
            str = '';
            str += '<div class="item active">'; str += "\n";
            data.SanPhamLienQuan.forEach(function (item, index) {
                str += '<a href="/DetailProduct/Index/' + item.ID + '"><img src="' + item.ANH + '" alt="" style="height: 130px; width: 90px;"></a>';
                str += "\n";
            });
            str += '</div>'; str += "\n";

            str += '<div class="item">'; str += "\n";
            data.SanPhamLienQuan.forEach(function (item, index) {
                str += '<a href="/DetailProduct/Index/' + item.ID + '"><img src="' + item.ANH + '" alt="" style="height: 130px; width: 90px;"></a>';
                str += "\n";
            });
            str += "</div>"; str += "\n";
            $("#SanPhamLienQuan").html(str);

            /// panel danh sách sản phẩm liên quan ở phía dưới
            $("#splienquan").empty();
            str = '';
            data.SanPhamLienQuan.forEach(function (item, index) {
                str += '<div class="col-sm-3">'; str += '\n';
                str += '    <div class="product-image-wrapper">'; str += '\n';
                str += '        <div class="single-products">'; str += '\n';
                str += '            <div class="productinfo text-center">'; str += '\n';
                str += '                <a href = "/DetailProduct/Index/' + item.ID + '" ><img src="' + item.ANH + '" alt="" style="width: 150px; height: 230px"/> </a>'; str += '\n';
                str += '                <h2>$' + item.GIA + '</h2>'; str += '\n';
                str += '                <p><a href = "/DetailProduct/Index/' + item.ID + '">' + item.TEN + '</a></p>'; str += '\n';
                str += '                <button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>'; str += '\n';
                str += '            </div>'; str += '\n';
                str += '        </div>'; str += '\n';
                str += '    </div>'; str += '\n';
                str += '</div>'; str += '\n';
            });
            $("#splienquan").html(str);

            /// panel sản phẩm khuyên dùng
            $("#SanPhamKhuyenDung").empty();
            str = '';
            listKD = data.SanPhamKhuyenDung;

            for (i = 0; i < data.SanPhamKhuyenDung.length; i += 3) {
                if (i != 0)
                    str += '<div class="item"> \n';
                else
                    str += '<div class="item active"> \n';

                for (j = i; j <= i + 2; j++) {
                    str += '<div class="col-sm-4">'; str += '\n';
                    str += '    <div class="product-image-wrapper">'; str += '\n';
                    str += '        <div class="single-products">'; str += '\n';
                    str += '            <div class="productinfo text-center">'; str += '\n';
                    str += '                <a href = "/DetailProduct/Index/' + listKD[j].ID + '">'; str += '\n';
                    str += '                    <img src="' + listKD[j].ANH + '" alt="" style="width:150px; height:230px;" />'; str += '\n';
                    str += '                </a>'; str += '\n';
                    str += '                <h2>$' + listKD[j].GIA + '</h2>'; str += '\n';
                    str += '                <p><a href = "/DetailProduct/Index/' + listKD[j].ID + '">' + listKD[j].TEN + '</a></p>'; str += '\n';
                    str += '                <button type="button" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</button>'; str += '\n';
                    str += '            </div>'; str += '\n';
                    str += '        </div>'; str += '\n';
                    str += '    </div>'; str += '\n';
                    str += '</div>'; str += '\n';
                }

                str += '</div> \n';
            }

            $("#SanPhamKhuyenDung").html(str);
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
            //console.log(data);

            $("#accordian").empty();
            var str = '';
            data.DsLoaiSanPham.forEach(function (item, index) {

                str += '<div class="panel panel-default"> '; str += '\n';
                str += '    <div class="panel-heading">'; str += '\n';
                str += '        <h4 class="panel-title">'; str += '\n';
                str += '            <a data-toggle="collapse" data-parent="#accordian" href="#sportswear">'; str += '\n';
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
            //console.log(data);

            $("#dsNhaSanXuat").empty();
            var str = '';
            data.DsNhaSanXuat.forEach(function (item, index) {

                str += '<li><a href="#"> <span class="pull-right">(' + item.SOLUONG + ')</span><b>' + item.TEN + '</b></a></li> ';
                str += '\n';
            });
            $("#dsNhaSanXuat").html(str);

        }
    });
}

$(window).ready(function () {
    LoadLoaiSanPham();
    LoadNhaSanXuat();
    LoadChiTietSanPham();
});
