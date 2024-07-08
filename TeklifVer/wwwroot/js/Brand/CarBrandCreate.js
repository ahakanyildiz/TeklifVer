$(document).ready(function () {


    //var table = new DataTable('#brandTable', {
    //    language: {
    //        url: 'https://cdn.datatables.net/plug-ins/2.0.8/i18n/tr.json',
    //    },
    //});
    var table = new DataTable('#brandTable', { language: {
            url: 'https://cdn.datatables.net/plug-ins/2.0.8/i18n/tr.json'
        }
    }
    );




    $('.trigger').click(function () {
        $('.modal-wrapper').toggleClass('open');
        $('.page-wrapper').toggleClass('blur');
        return false;
    });

    //function successMessage() {
    //    $.ajax({
    //        url: '/Home/SuccessNotification',
    //        type: 'GET',
    //        success: function (data) {
    //            $('#partialContainer').html(data);
    //        },
    //        error: function () {
    //            alert('Partial view yüklenirken bir hata oluştu.');
    //        }
    //    });
    //};


    //function getBrands() {
    //    $.ajax({
    //        url: '/carbrand/getlist',
    //        type: 'GET',
    //        dataType: 'json',
    //        success: function (response) {
    //            var tbody = $("#brandTable tbody");
    //            tbody.empty();
    //            if (response.data && Array.isArray(response.data)) {
    //                table.clear();
    //                response.data.forEach(function (brand) {
    //                    table.row.add([
    //                        brand.definition,
    //                    ]).draw(false);
    //                });
    //            } else {
    //                console.log('Unexpected response format:', response);
    //            }
    //        },
    //        error: function (error) {
    //            console.log('Error:', error);
    //        }
    //    });
    //}



    // Form verilerinin gönderilmesini sağlayan fonksiyon
 //   $("#btnCreate").click(function () {
 //       event.preventDefault();

 //       var formData = new FormData();
 //       formData.append("Definition", $("#Definition").val());
 //       formData.append("ImgName", "bos");
 //       formData.append("Image", $("#Image")[0].files[0]);


 //       $.ajax({
 //           url: '/marka/olustur',
 //           type: 'POST',
 //           contentType: false,
 //           processData: false,
 //           data: formData,
 //           success: function (response) {
 //          /*     successMessage();*/
 //               $("#brandForm")[0].reset();
 //               $('.modal-wrapper').toggleClass('open');
 //               window.location.reload();
 ///*               getBrands();*/
 //           },
 //           error: function (error) {
 //               console.log(error);
 //           }
 //       });
 //   });



});