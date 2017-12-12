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
                str += '                    <img src="' +  item.ANH +'" alt="" + style ="height: 350px;" />'; str += "\n";
                str += '                    <h2>$'+ item.GIA +'</h2>'; str += "\n";
                str += '                    <p><b>' + item.TEN  +'</b></p>'; str += "\n";
                str += '                    <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>'; str += "\n";
                str += '                </div>'; str += "\n";          
                str += '            </div>'; str += "\n";
                str += '        </div>';
                str += '</div>';

                console.log(item.TEN);
            });
            $("#ListProduct").html(str);

        }
    });
}

$(window).ready(function () {
    LoadLoaiSanPham();
    LoadNhaSanXuat();
    LoadSanPham();
});