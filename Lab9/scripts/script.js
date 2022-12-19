function clearScreen() {
    document.getElementById("display").value = "";
}

function backspace(){
    let val = document.getElementById("display").value;
    if(val.length > 1) {
        val = val.slice(0, -1);
        document.getElementById("display").value = val;
    } else {
        document.getElementById("display").value = "0";
    }
}

function display(value) {
    var val = document.getElementById("display").value
    if(val == "0") {
        document.getElementById("display").value = value
    } else {
        document.getElementById("display").value += value;
    }
}

function calculate() {
    var p = document.getElementById("display").value;
    var q = eval(p);
    document.getElementById("display").value = q;
}