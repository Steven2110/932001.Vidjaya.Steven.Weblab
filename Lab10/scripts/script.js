const stage = document.querySelector(".stage");
const animal = document.querySelector("#animal");
const container = document.querySelector(".magic");
const lamp = document.querySelector(".lamp");
const stagePerformer =  document.querySelector(".stagePerformer");
const light = document.querySelector(".light");

stage.addEventListener("click", () => { 
    stage.classList.remove("stageEffect");
    stage.classList.add("startPlay");
    setTimeout(1);
    stage.style.visibility = "gone";
})

container.addEventListener("click", () =>{
    animal.style.top = "200px";
    if (animal.classList.contains("rabbit")){
        setTimeout(() => {
            animal.classList.remove("rabbit")
            animal.classList.add("bird")
        }, 500);
        
    } else{
        setTimeout(() => {
            animal.classList.remove("bird")
            animal.classList.add("rabbit")
        }, 500);
    }
    setTimeout(() => {animal.style.top = "0px";}, 500);
})

lamp.addEventListener("click", () =>{
    if (stagePerformer.style.visibility == "hidden" || stagePerformer.style.visibility == ""){
        stagePerformer.style.visibility = "visible";
        light.style.visibility = "visible";
    } else {
        stagePerformer.style.visibility = "hidden";
        light.style.visibility = "hidden";
    }
})