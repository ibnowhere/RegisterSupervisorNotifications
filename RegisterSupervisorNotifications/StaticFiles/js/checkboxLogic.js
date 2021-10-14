function emailBoxClick(obj){

    if ($(obj).is(":checked")){
        $("#emailInput").attr('required', 'required');

        if ($("#phoneCheckbox").is(":checked")){
            $("#phoneCheckbox").prop('checked', false);
            $("#pnInput").removeAttr('required');
        }
    }
    else{
        $("#emailInput").removeAttr('required');
    }
}

function pnBoxClick(obj){

    if ($(obj).is(":checked")){
        $("#pnInput").attr('required', 'required');

        if ($("#emailCheckbox").is(":checked")){
            $("#emailCheckbox").prop('checked', false);
            $("#emailInput").removeAttr('required');
        }
    }
    else{
        $("#pnInput").removeAttr('required');
    }
}