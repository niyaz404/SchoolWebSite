function getStudentsList() {
    var selected = document.getElementById("selectId");
    var classId = parseInt(selected.value, 10);
    $.get("/Students/GetStudents", { classId: classId })
        .done(function (data) {
            var studentsJson=JSON.stringify(data)
            var students = JSON.parse(studentsJson);
            var count = students.length;
            //var form = document.form;
            var form = document.createElement("form");
            var ol = document.createElement('ol');
            for (var i = 0; i < count;i++)
            {
                var li = document.createElement('li');
                var a = document.createElement('a');
                a.className = "a-students";
                a.href = "profile/"+students[i].id;
                a.appendChild(document.createTextNode((i+1)+". "+students[i].fullName));
                li.appendChild(a);
                ol.appendChild(li);
            }
            var h2 = document.createElement('h2');
            h2.appendChild(document.createTextNode("Ученики " + $('#selectId option:selected').text() + " класса"));
            $("#classHeader").html(h2);
            $("#resultList").html(ol);
            console.log(data);
        })

}

function fillSubjectSelect(classId) {
    var selected = document.getElementById("selectClassId");
    $.get("/Rating/GetSubjects", { classId: classId })
        .done(function (data) {
            var JsonString = JSON.stringify(data);
            var subjects = JSON.parse(JsonString);
            var count = subjects.length;
            var select = document.createElement('select');
            var disOption = document.createElement('option');
            disOption.disabled = true;
            disOption.appendChild(document.createTextNode("Выберите предмет"));
            select.appendChild(disOption);
            for (var i = 0; i < count; i++) {
                var option = document.createElement('option');
                option.value = subjects[i].subjectId;
                option.appendChild(document.createTextNode(subjects[i].subjectName));
                select.appendChild(option);
            }
            select.id = "selectSubjectId";
            $("#div-subjectChoice").html(select);
            console.log(select);
            console.log(data);
            console.log(JsonString);
        })
}