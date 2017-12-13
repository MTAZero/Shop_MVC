$(window).ready(function () {
    LoadNhaSanXuat();
    LoadLoaiSanPham();
    LoadThongTinSanPham();
    $("#btnSua").click(SuaSanPham);
});

function LoadNhaSanXuat() {
    $.ajax({
        url: "/Home/dsNhaSanXuat",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            //console.log(data);

            $("#cbxNhaSanXuat").empty();
            var str = '';
            data.DsNhaSanXuat.forEach(function (item, index) {
                str += '<option value = ' + item.ID + '>' + item.TEN + '</option>';
                str += '\n';
            });
            $("#cbxNhaSanXuat").html(str);

        }
    });
}

function LoadLoaiSanPham() {
    $.ajax({
        url: "/Home/DsLoaiSanPham",
        data: {},
        dataType: "json",
        type: "POST",
        success: function (data) {
            //console.log(data);

            $("#cbxLoaiSanPham").empty();
            var str = '';
            data.DsLoaiSanPham.forEach(function (item, index) {
                str += '<option value = ' + item.ID + '>' + item.TEN + '</option>';
                str += '\n';
            });
            $("#cbxLoaiSanPham").html(str);

        }
    });
}

function SuaSanPham() {
    var TenSanPham = $("#TenSanPham").val();
    var MaSanPham = $("#MaSanPham").val();
    var NhaSanXuatId = $("#cbxNhaSanXuat").val();
    var LoaiSanPhamId = $("#cbxLoaiSanPham").val();
    var GiaSanPham = $("#GiaSanPham").val();
    var Anh = $("#Anh").prop("files");
    var ChiTietSanPham = $("#ChiTietSanPham").val();

    if (TenSanPham == "" || MaSanPham == "" || GiaSanPham == "" || ChiTietSanPham == "") {
        alert("Nhập thông tin chưa đầy đủ");
        return;
    }

    if (isNaN(GiaSanPham)) {
        alert("Giá sản phẩm phải là số thực");
        return;
    }

    $("#formMain").submit();
}

function LoadThongTinSanPham() {
    var id = $("#MainContent").data("id");
    console.log('id = '+id);

    $.ajax({
        url: "/Admin/dsSanPham/ThongTinSanPham",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
            console.log(data);
            $("#TenSanPham").val(data.TenSanPham);
            $("#MaSanPham").val(data.MaSanPham);
            $("#cbxNhaSanXuat").val(data.NhaSanXuatID);
            $("#cbxLoaiSanPham").val(data.LoaiSanPhamID);
            $("#GiaSanPham").val(data.GiaSanPham);
            $("#ChiTietSanPham").val(data.ChiTietSanPham);

            var str = '';
            str += '<img src="' + data.Anh + '" style="width: 120px; height: 180px;" />'; str += '\n';
            $("#Image").html(str);
        }
    });
}
