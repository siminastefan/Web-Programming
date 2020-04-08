function createTable(array, size) {
    let rows;
    if (Math.floor(size / 5) === size /5) {
        rows = size / 5;
    } else {
        rows = Math.floor(size / 5) + 1;
    }
    const body = document.getElementsByTagName('body')[0];
    const table = document.createElement('table');
    table.style.width = '100%';
    table.setAttribute('border', '2px solid black');
    const tbody = document.createElement('tbody');
    for (let i = 0; i < rows ; i++) {
        const tr = document.createElement('tr');
        for (let j = 0; j < 5; j++) {
            var td = document.createElement('td');
            if (array.length === 0) {
                td.appendChild(document.createTextNode(''));
                tr.appendChild(td);
            } else {
                td.appendChild(document.createTextNode(array[0].toString()));
                tr.appendChild(td);
                array.splice(0, 1);
            }
            tr.setAttribute('align', 'center');
        }
        tbody.appendChild(tr);
    }
    table.appendChild(tbody);
    body.appendChild(table);
}

function readTextarea() {
    const array = document.getElementById("array").value;
    const integers = array.split(' ');
    const size = integers.length;
    integers.sort(function (a, b) {
        return b - a
    });
    integers.reverse();
    createTable(integers, size);
}