function getStudClass() {
    var selected = document.getElementById("selectId");
    var classId = parseInt(selected.value, 10);
    $.get("/Students/GetStudents", { classId: classId })
        .done(function (data) {
            var studentsJson = JSON.stringify(data);
            var students = JSON.parse(studentsJson);
            var count = students.length;
            var form = document.form,
                tbl = document.createElement('table');
            tbl.style.width = '30%';
            tbl.style.border = '1px solid black';
            for (var i = 0; i < count+1; i++) {
                var tr = tbl.insertRow();
                for (var j = 0; j < 2; j++) {

                    if (i == 0) {
                        if (j == 0) {
                            var td = tr.insertCell();
                            td.appendChild(document.createTextNode("id"));
                        }
                        else
                        {
                            var td = tr.insertCell();
                            td.appendChild(document.createTextNode("ФИО"));
                        }
                    }
                    else
                    {
                        if (j == 0) {
                            var td = tr.insertCell();
                            td.appendChild(document.createTextNode(students[i-1].Id));
                        }
                        else {
                            var td = tr.insertCell();
                            td.appendChild(document.createTextNode(students[i-1].FullName));
                        }
                    }
                    td.style.border = '1px solid black';
                }
            }
            //form.appendChild(tbl);
            $("#result").html(tbl);
            //$("#json").html(str);
            console.log(data);
        })
    
}