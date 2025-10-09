function CambiarPalabra(texto) {
  const div = document.getElementById("palabra");
  div.innerHTML = texto;
}
function CambiarIntentos(texto) {
  const div = document.getElementById("intentos");
  div.innerHTML = texto;
}
function CambiarUsadas(texto) {
  const div = document.getElementById("usadas");
  div.innerHTML = texto;
}
function CambiarMensaje(texto) {
  const div = document.getElementById("msg");
  div.innerHTML = texto;
}
var PalabraReal = document.getElementById("palabraServer");
var PalabraRealCaracteres = document.getElementById("palabraServer").split("");
var PalabraActual = document.getElementById("palabra");
var Intentos = 0;
var LetrasFallidas = 0;
var Mensaje = "La letra ya había sido usada";

var BotonArriesgarLetra = document.getElementById("btnLetra");
var ArriesgarLetra = document.getElementById("entrada");
var BotonArriesgarPalabra = document.getElementById("btnPalabra");
var ArriesgarPalabra = document.getElementById("entradaPalabra");

if (ArriesgarLetra) {
  for (let i = 0; i <= PalabraRealCaracteres.lenght(); i++) {
    if (PalabraRealCaracteres[i] == ArriesgarLetra) {

    }
  }
}
else if(ArriesgarPalabra){

}
