function retrieveSupervisors (){

    $.get('/api/supervisor', function (data) {
            var selectList = document.querySelector("#supervisorSelect");
            var selectListBuilder = "";
            data.forEach(function (item) {
                selectListBuilder += `<option value='${item}'>${item}</option>`;
            });
            selectList.innerHTML = selectListBuilder;
        console.log(data);
    });
}