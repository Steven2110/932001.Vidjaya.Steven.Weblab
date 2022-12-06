function addDocument() {
    const newDocument = document.createElement('div');
    newDocument.className = 'documentContainer';
    newDocument.innerHTML = `
        <input type="text" class="item1">
        <input type="text" class="item2">
        <button class="moveUp" onclick="moveUp(this)">↑</button>
        <button class="moveDown" onclick="moveDown(this)">↓</button>
        <button class="remove" onclick="removeDocument(this)">x</button>
    `;

    documentsList = document.getElementById("documentsContainer");
    documentsList.appendChild(newDocument);
};

function saveDocument() {
    jsonSummary = document.querySelector(".jsonSummary");
    keyDocument = document.querySelectorAll(".item1");
    valueDocument = document.querySelectorAll(".item2");
   
    JsonArray = [];
    kov = "&quot";

    for (var i = 0; i < keyDocument.length; i++) {
        JsonArray.push(keyDocument[i].value + kov + ":" + kov + valueDocument[i].value);
    }
    result ='{'+  JSON.stringify(JsonArray).slice(1, -1)+ '}';
    jsonSummary.innerHTML = result;
};

function moveUp(document) {
    previous = document.parentElement.previousElementSibling;
    if(previous != null) {
        document.parentElement.after(previous);
    }
};

function moveDown(document) {
    next = document.parentElement.nextElementSibling;
    if(next != null) {
        document.parentElement.before(next);
    }
};

function removeDocument(document) {
    document.parentElement.remove()
}