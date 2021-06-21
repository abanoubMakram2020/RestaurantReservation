jQuery.validator.addMethod("MaxValue",
    function (value, element, param) {
        return value > 10 ? false : true
    });
jQuery.validator.unobtrusive.adapters.addBool("MaxValue");

jQuery.validator.addMethod("MinValue",
    function (value, element, param) {
        return value < 1 ? false : true

    });
jQuery.validator.unobtrusive.adapters.addBool("MinValue");