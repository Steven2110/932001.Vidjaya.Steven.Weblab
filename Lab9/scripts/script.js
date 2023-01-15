{
    var comma = false
}

function clearScreen() {
    document.getElementById("display").value = "";
    comma = false
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
    let operator = ["+", "*", ".", "/", "-"];

    let val = document.getElementById("display").value;
    if (operator.includes(value) && operator.includes(val.slice(-1))) {
        alert("Wrong input");
    } else {
        if(val == "0") {
            document.getElementById("display").value = value
        } else {
            document.getElementById("display").value += value;
        }
    }
}

function calculate() {
    let str = document.getElementById("display").value;
    let result = "";
    try {
        result = eval(str);
        document.getElementById("display").value = result;
    } catch (error) {
        alert("Wrong input");
    }
}