$(function () {

    var ModalId = $('#Profile');
    $('#ajax-modal').click(function (event) {
        let Url = $('#Profile').data('url');
        $.get(Url, function (data) {
            $('#Profile').html(data);
            $('#Profile').modal('show');
        })
    })

    ModalId.on('click', '[data-save="modal"]', function (event) {

        var form = $('#EditProfile');
        var actionUrl = form.attr('action');
        console.log(form);
        var url = "/Home/" + actionUrl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            console.log(form);
            $('#Profile').html(data);
            $('#u_name').text($('#Name').val() ? $('#Name').val() : $('#u_name').text());
            $('#user_name').text($('#userName').val() ? $('#userName').val() : $('#user_name').text());

            //placeHolderElement.find('.modal').modal('hide');
        })
    })


    ModalId.on('click', '[data-save="modal_pass"]', function (event) {
        var form = $('#EditPassword');
        var actionUrl = form.attr('action');
        var url = "/Home/" + actionUrl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            $('#Profile').html(data);
            $('#home-tab').removeClass('active');
            $('#contact-tab').addClass('active');
            $('#home').removeClass('active show');
            $('#contact').addClass('active show');
            //placeHolderElement.find('.modal').modal('hide');
        })
    })

    ModalId.on('click', '[data-save="modal_img"]', function (event) {
        var form = $('#UploadImage');
        var actionUrl = form.attr('action');
        var file = $('#Files')[0].files[0];
        var url = "/Home/" + actionUrl;
        var formData = new FormData();
        formData.append('id', $('#idUser').val());
        formData.append('email', $('#Email_user').val());
        formData.append('files', $('#Files')[0].files[0]);
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (data) {
                console.log(data);
                $('#Profile').html(data);
                $('#home-tab').removeClass('active');
                $('#home').removeClass('active show');
                $('#image-tab').addClass('active');
                $('#image').addClass('active show');
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#showProfileImage').prop('src', e.target.result)
                  };
                reader.readAsDataURL(file);
            }
          
        });
    })

})
function deleteRow(row_id,url,msg) {
    Swal.fire({
        title: 'Are you sure?',
        text: msg ? msg : "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#435ebe',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ok'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: url,
                data: { id: row_id },
                success: function (result) {
                    $('.section').html(jQuery(result).find('.section').html());
                    $('#table1').DataTable();
                }
            })
        }
    })
}

function getValueofcategory(ev) {
    console.log(ev);
}