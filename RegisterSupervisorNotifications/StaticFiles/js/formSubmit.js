function submitForm(){
    var form = document.querySelector("#notificationForm");
    const data = new FormData(form);

    var jsonData = Array.from(data.keys()).reduce((result, key) => {
                            result[key] = data.get(key);
                            return result;
                        }, {});
    
    $.post("/api/submit", jsonData, function(result){
        console.log(result);
    })
}