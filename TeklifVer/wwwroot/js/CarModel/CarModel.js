$(document).ready(function () {


    var table = $('#carModelTable').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/2.0.8/i18n/tr.json'
        }
    });

    $('#brandSelect').select2({
        width: '100%',
        placeholder: "Marka seçiniz",
        allowClear: true
    });

    $('#brandCreateSelect').select2({
        width: '100%',
        placeholder: "Marka seçiniz",
        allowClear: true
    });


    function successMessage() {
        $.ajax({
            url: '/Home/SuccessNotification', // ControllerName ve PartialView adınızı uygun şekilde değiştirin
            type: 'GET',
            success: function (data) {
                $('#partialContainer').html(data); // Partial view içeriğini #partialContainer içine yerleştir
            },
            error: function () {
                alert('Partial view yüklenirken bir hata oluştu.');
            }
        });
    };
    function getBrands() {
        $.ajax({
            url: '/carbrand/getlist',
            method: 'GET',
            dataType: 'json',
            success: function (response) {
                // Başarılı olursa, verileri select etiketine ekleyin
                var $select = $('#brandSelect');
                console.log("Markaları select'e ekliyorum.");

                // response.data kısmına erişiyoruz
                $.each(response.data, function (index, item) {
                    var option = $('<option></option>')
                        .attr('value', item.id) // veya item.value
                        .text(item.definition); // veya item.text
                    $select.append(option);
                });
            },
            error: function (xhr, status, error) {
                console.error('AJAX isteği başarısız oldu:', error);
            }
        });
    }
/*    getBrands();*/

    $('.trigger').click(function () {
        console.log("bastı");
        $('.modal-wrapper').toggleClass('open');
        $('.page-wrapper').toggleClass('blur');
        return false;
    });



    function getCarModels() {
        $.ajax({
            url: '/carModel/getlist',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                console.log(response);
                var tbody = $("#brandTable tbody");
                tbody.empty();
                if (response.data && Array.isArray(response.data)) {
                    response.data.forEach(function (carModel) {
                        table.row.add([
                            carModel.brand.definition, // Markanın resim adı
                            carModel.definition,
                            `<a class="button danger" href="/Carmodel/Remove/${carModel.id}">Remove</a>`,
                            `<a class="button warning" href="/Carmodel/Edit/${carModel.id}">Update</a>`
                        ]).draw(false);
                    });
                } else {
                    console.log('Unexpected response format:', response);
                }
            },
            error: function (error) {
                console.log('Error:', error);
            }
        });
    }

    //getCarModels();


    $('#carModelForm').on('submit', function (event) {
        event.preventDefault();

        var formData = new FormData();
        formData.append("Definition", $("#definition").val());
        formData.append("BrandId", $('#brandSelect').val());
      

        $.ajax({
            url: '/model/olustur',
            method: 'POST',
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                successMessage();
                alert('Model başarıyla oluşturuldu!');
                $('#carModelForm')[0].reset();
                $('#brandSelect').val(null).trigger('change');
          
                getCarModels();
                $('.modal-wrapper').toggleClass('open');
            },
            error: function (xhr, status, error) {
                console.error('Oluşturma hatası:', error);
                alert('Model oluşturulurken bir hata oluştu.');
            }
        });
    });
});