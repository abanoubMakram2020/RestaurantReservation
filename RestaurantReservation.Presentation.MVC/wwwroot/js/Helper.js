var resourceValue;

function ReadFromResources(key) {
    var DTO = { 'key': key };
    $.ajax({
        url: '/Common/ReadFromResources',
        data: JSON.stringify(DTO),
        type: 'POST',
        contentType: 'application/json;',
        dataType: 'json',
        async: false,
        cache: false
    }).success(function (data) {
        resourceValue = data;
    }).fail(function (data) {
        resourceValue = "Failed";
    });
}
