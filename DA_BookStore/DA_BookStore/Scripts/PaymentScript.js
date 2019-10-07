$(document).ready(function () {
    $('#check-giftcode').click(function () {

        $("#giftcode").prop('disabled', true);
        $("#giftcode").css('background-color', "gray");

        $.ajax({
            url:'/api/promocodes/'+$('#giftcode').val()+'/',
            type: 'GET',
            success: function (data) {
                $('#discountdiv').show();
                $('#codePromote').val(data.CODE);
                $('#discountvalue').html(data.SoTienGiam.toLocaleString(undefined, { minimumFractionDigits: 0 }) + ' ₫');
                temp = $('#boxThanhTien').html().replace(/[^0-9]/gi, '');
                $('#boxThanhTien').html((temp - data.SoTienGiam).toLocaleString(undefined, { minimumFractionDigits: 0 }) + ' ₫');
                $("#check-giftcode").hide();
            },
            error: function () {
                $("#giftcode").prop('disabled', false);
                $("#giftcode").css('background-color', "#fff7b2");
                alert("Mã không tồn tại!");
            }

        });

        //$('#review').data({
        //    "ajax": {
        //        "url": "/Payment/GetData",
        //        "type": "GET",
        //        "datatype": "json"
        //    },
        //    "columns": [
        //        { "data": "CODE" },
        //        { "data": "NgayThem" },
        //        { "data": "NgayHetHan" },
        //        {"data": "SoTienGiam"}
        //    ]
        //});


        //$('#giftcode').({
        //    "ajax": {
        //        "url": "/PromotionCodeController/GetCTGIOHANGs",
        //        "type": "GET",
        //        "datatype": "text",
        //        susscess: function (result) {
        //            console.log(result);
        //        }
        //    }
        //});  
        //$.ajax({
        //    url: "/API/PromotionCode",
        //    type: "get",
        //    datatype: "json",
        //    async: false,
        //    success: function (result) {
        //        console.log(result);
        //    }
        //});
        //alert($('#giftcode').val());
    });
});