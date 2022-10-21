let text_headline1 = "Lorem ipsun, dolor sit amet consectetur adipisicing elit. Amet asperiores aut nihil! Corporis debitis labore fugiat id, eligendi ratione veritatis!"
let text_headline2_3 = "Lorem ipsun, dolor sit amet consectetur adipisicing elit. A, alias."
let text_paragraph = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aperiam hic, ipsa, ullam, cupiditate eveniet at voluptate corrupti commodi nobis ratione voluptatem! Vel animi totam cupiditate doloribus ad ab exercitationem officia eveniet impedit? Deleniti quasi nisi consectetur perspiciatis quibusdam nostrum, enim perferendis nam, magni molestias recusandae id libero vitae, repudiandae praesentium."

function openDetail(number) {
    let popupHeader = document.getElementById('popup-header')
    let popupHeadline = document.getElementById('popup-headline')
    let popupText = document.getElementById('popup-text')
    let popupWindow = document.getElementById('popup-news')
    let main = document.getElementById('main')

    let thisHeadline = number === 1 ? text_headline1 : text_headline2_3

    popupHeader.textContent = `Новость ${number}`
    popupHeadline.textContent = `Новость ${number}: ${thisHeadline}`
    popupText.textContent = text_paragraph

    popupWindow.style.display = "block"
    main.style.filter = "blur(3px)"
}


window.addEventListener('mouseup',function(event){
    let popupWindow = document.getElementById('popup-news');
    let main = document.getElementById('main')
    if(event.target != popupWindow && event.target.parentNode != popupWindow){
        popupWindow.style.display = 'none';
        main.style.filter = "none";
    }
});