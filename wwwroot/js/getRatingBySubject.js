function getRatingBySubject(classId, subjectId) {
    var marksTable = document.getElementById("marksTable");
    while (marksTable.rows.length != 1) {
        marksTable.deleteRow(1);
    }
    var lpId;
    $.get("/Rating/GetLPId",
        { classId: classId, subjectId: subjectId },
        function (lpId) {
            var marks;
            $.get("/Rating/GetBySubject", { lpId: lpId }).done(function (marks) {
                $.get("/Students/GetStudents", { classId: classId }).done(function (students) {
                    for (var i = 0; i < students.length; i++) {
                        var tr = marksTable.insertRow();
                        tr.style.height = '40px';
                        tr.dataset.id = students[i].id;
                        for (var j = 0; j < 65; j++) {
                            var td = tr.insertCell();
                            var div = document.createElement('div');
                            var input = document.createElement('input');
                            input.style.width = '100%';
                            input.style.height = '100%';
                            if (j === 0) {
                                td.appendChild(document.createTextNode(students[i].fullName));
                            } else {
                                td.className = 'edit';
                                td.dataset.id = students[i].id + "_" + j+"_"+lpId;
                                td.appendChild(div);
                                td.appendChild(input);
                                for (var k = 0; k < marks.length; k++) {
                                    if (marks[k].studentId === students[i].id && marks[k].index === j) {
                                        var string = document.createTextNode(marks[k].mark);
                                        div.appendChild(string);
                                        input.value = marks[k].mark;
                                        input.defaultValue = marks[k].mark;
                                    }
                                }
                            }
                            td.style.border = '1px solid black';
                        }
                    }
                });
            });
        });
}