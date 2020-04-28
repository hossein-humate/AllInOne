"use strict";
function thousandSeprator(element) {
    let number = $(element).val().replace(/,/g, '');
    var result = "";
    var mod = number.length % 3;
    if (mod !== 0) {
        for (let i = 0; i < mod; i++) {
            result += number[i];
        }
        result += ',';
    }
    for (let i = 0; i < (number.length - mod) / 3; i++) {

        result += number.substring((i * 3) + mod, (i * 3) + mod + 3) + ',';
    }
    result = result.substring(0, result.length - 1);
    $(element).val(result);
}