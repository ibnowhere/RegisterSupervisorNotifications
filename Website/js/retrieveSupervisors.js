function retrieveSupervisors (){
    // $.ajax({
    //     type: "GET",
    //     url: 'http://localhost/api/supervisors',
    //     dataType: 'json'
    // }).done(function (data) {
    //     console.log(data.message);

    //     if (data.success === true) {
    //         console.log(data);
    //     }
    //     else {
    //         console.log("too bad");
    //     }
    // });

    var xmlhttp = new XMLHttpRequest();
    var url = "https://localhost:44372/api/supervisor";

    xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
        var myArr = JSON.parse(this.responseText);
        console.log(myArr);
    }
    else{
        console.log(this.readyState);
    }
    };
    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}