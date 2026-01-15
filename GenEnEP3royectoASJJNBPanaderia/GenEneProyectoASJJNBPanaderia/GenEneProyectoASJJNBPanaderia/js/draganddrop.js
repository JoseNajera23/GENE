var contador = 0; //poner un id unico a cada elemento clonado
var elemArrastrableId = "";

var contadorRojo = 0;
var contadorMorado = 3;

//TRABAJA CON EL EVENTO ondragstart
function start(e) {//////////////////////////////////////////////////////Funciones de los objetos Cuadraditos
    console.log("start")
    e.dataTransfer.effectAllowed = "move"; //define el efecto mover ////Se contiene el objeto que se va a manipular, en este caso los Cuadraditos y son permitidos para arrastre
    //Guarda en memoria el elemento a mover
    e.dataTransfer.setData("Data", e.target.id); //Data : arrastrable1
    ///////////////////Se recibe en SetData el Cuadradito pasado por medio de target.id
    $("#" + e.target.id).css("opacity", "0.4");
    //e.target.style.opacity = "0.4";          ////A ese elemento Cuadradito se le asigna un estilo de opacidad antes de que sea soltado en el Cuadro
    elemArrastrableId = e.target.id; //Se pasa el Objeto Cuadradito a la variable elemArrastrableId // arrastrable1
}
function end(e) {
    console.log("end")
    e.target.style.opacity = '';
    e.dataTransfer.clearData("Data");
    elemArrastrableId = "";
}
function enter(e) {
    console.log("enter");
    e.target.style.border = "12px dotted #555";
}
function leave(e) {
    console.log("leave");
    //e.target.style.border = "";
    $("#" + e.target.id).css("border", "");
}
function over(e) {
    console.log("over")
    var id = e.target.id; // cuadro3
    if ((id == "cuadro1") || (id == "cuadro3") || (id == "papelera")) {
        return false; // falso significa que te deje soltar las cosas
    }
    else {
        return true; // true significo que NO TE DEJE SOLTAR LAS COSAS
    }
}

//========================================================================

function drop(e) {
    console.log("drop")
    var elementoArrastrado = e.dataTransfer.getData("Data");
    e.target.appendChild(document.getElementById(elementoArrastrado));
    e.target.style.border = "";
}
function eliminar(e) {
    console.log("eliminar")
    var elementoArrastrado = document.getElementById(e.dataTransfer.getData("Data"));  // arrastrable1
    elementoArrastrado.parentNode.removeChild(elementoArrastrado);    
    e.target.style.border = "";
}
function clonar(e) {
    console.log("clonar")
    var elementoArrastrado = document.getElementById(e.dataTransfer.getData("Data")); //arrastrable1
    elementoArrastrado.style.opacity = "";
    if (contadorRojo < 3)
    {
        var elementoClonado = elementoArrastrado.cloneNode(true);
        elementoClonado.id = "ElemeClonado" + contador;
        contador++;
        elementoClonado.style.position = "static";
        e.target.appendChild(elementoClonado);
    }
    
    e.target.style.border = "";
}