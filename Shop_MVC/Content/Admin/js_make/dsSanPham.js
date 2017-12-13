$(window).ready(function () {
    LoadSanPham();
});

function LoadSanPham() {
    $.ajax({
        url: "/Home/ListProduct",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {

            $("#adBody").empty();
            var str = '';
            data.ListProduct.forEach(function (item, index) {
                str += '<tr>\n';
                str += '    <th scope="row">' + (index + 1) + '</th>'; str += '\n';
                str += '    <td><b>' + item.TEN + '</b></td>'; str += '\n';
                str += '    <td>' + item.LOAISANPHAM + '</td>'; str += '\n';
                str += '    <td>' + item.NHASANXUAT + '</td>'; str += '\n';
                str += '    <th><img src="' + item.ANH + '" style="width: 100px; height: 150px;" /></th>'; str += '\n';
                str += '    <td><a href="\#" class="btn btn-primary">Sửa</a></td>'; str += '\n';
                str += '    <td><a href="\#" class="btn btn-danger btnXoa" data-id = ' + item.ID + '>Xóa</a></td>'; str += '\n';
                str += '<\tr>\n';
            });
            $("#adBody").html(str);
            $("td").css("border", "1px solid black");
            $("th").css("border", "1px solid black");

            $(".btnXoa").click(XoaSanPham);
        }
    });
}

function XoaSanPham() {
    var ok = confirm("Bạn có chắc chắn xóa sản phẩm này?");
    var id = $(this).data("id");

    if (ok == false) return;

    $.ajax({
        url: "/Admin/dsSanPham/XoaSanPham",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
            if (data.status == false) {
                alert(data.tinnhan);
                return;
            }
            alert("Xóa thành công");
            LoadSanPham();
        }
    });

    
}