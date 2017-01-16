$(function () {
    $('#uploadForm').ajaxForm({
        beforeSend: function () {
            $('.progress').show();
        },
        uploadProgress: function (event, position, total, percentComplete) {
            $('.progress-bar').width(percentComplete + '%');
            $('.progress-bar').html(percentComplete + '%');
            $('.sr-only').html(percentComplete + '% Complete');
        },
        success: function () {
            $('progress').hide();
        },
        complete: function (response) {
            if (response.responseText == '0')
                $('.error').html('Не успешно качване. Моля опитайте пак!')
            else
                location.replace("GetDocuments");
        }
    });
    $(".progress").hide();
});