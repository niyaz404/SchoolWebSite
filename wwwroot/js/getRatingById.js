function getRatingById(studentId) {
    var selected = document.getElementById("subjectSelect");
    var subjectId = parseInt(selected.value, 10);
    
    $.get("/Students/GetRating", { studentId: studentId,subjectId: subjectId })
        .done(function (_marks) {
            var tr = document.getElementById('marks');
            while (tr.cells.length != 1) {
                tr.deleteCell(1);
            }
            for (var i = 1; i < 65; i++) {
                var td = tr.insertCell();
                console.log(_marks);
                for (var j = 0; j < _marks.length; j++) {
                    if (_marks[j].index === i) {
                        td.appendChild(document.createTextNode(_marks[j].mark));
                    }
                }
                td.style.border = '1px solid black';
            }
        })

}