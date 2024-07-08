$(document).ready(function () {

    $('#carBrandSelect').select2({
        width: '100%',
        placeholder: "Marka seçiniz",
        allowClear: true
    });

    $('#carModelSelect').select2({
        width: '100%',
        placeholder: "Model seçiniz",
        allowClear: true
    });







    function getBrands() {
        $.ajax({
            url: '/marka/getlist',
            method: 'GET',
            dataType: 'json',
            success: function (response) {
                // Başarılı olursa, verileri select etiketine ekleyin
                var $select = $('#carBrandSelect');
                console.log("Markaları select'e ekliyorum.");
                console.log(response);
                var option = '<option disabled selected>Marka seçiniz</option>';

                $select.append(option);
                // response.data kısmına erişiyoruz
                $.each(response, function (index, item) {
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

    getBrands();


    function getModels(id) {
        $.ajax({
            url: `/model/GetListByBrandId/${id}`,
            method: 'GET',
            dataType: 'json',
            success: function (response) {
                // Başarılı olursa, verileri select etiketine ekleyin
                var $select = $('#carModelSelect');
                console.log("Markaları select'e ekliyorum.");

                // response kısmına erişiyoruz
                $.each(response, function (index, item) {
                    console.log(item);
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


    $('#carBrandSelect').change(function () {
        var $select = $('#carModelSelect');
        $select.empty();
        getModels($('#carBrandSelect').val());
    });
});
