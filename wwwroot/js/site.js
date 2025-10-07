document.addEventListener('DOMContentLoaded', function () {
  //Cliente pipipi
  var PalabraSecreta = (document.getElementById('palabraServer').value || '').toLowerCase();
  var CantidadIntentos = 0;
  var LetrasUsadas = [];
  var LetrasDescubiertas = [];
  //Lo uso para guardar cada letra de la palabra y si se a hadivinado o no
  //no se guarda tipo a:false, b:true. Si no que se guarda tipo false, true, false

  //Cosas del DOM
  var PalabraReal = document.getElementById('palabra');
  var Intentos = document.getElementById('intentos');
  var LetrasFallidas = document.getElementById('usadas');
  var Mensaje = document.getElementById('msg');

  var BotonArriesgarLetra = document.getElementById('btnLetra');
  var BotonArriesgarPalabra = document.getElementById('btnPalabra');

  //Start
  for (var i = 0; i < PalabraSecreta.length; i++) {
    LetrasDescubiertas.push(false);
  }
  Intentos.textContent = CantidadIntentos;
  DibujarPalabra();
  DibujarLetrasFallidas();
  LimpiarMensaje();

  //Event
  if (BotonArriesgarLetra) {
    BotonArriesgarLetra.addEventListener('click', function () {
      LimpiarMensaje();

      var Entrada = document.getElementById('entrada');
      var LetraIngresada = (Entrada.value || '').toLowerCase();
      Entrada.value = '';
      if (LetraIngresada === '') return;

      if (LetraYaUsada(LetraIngresada)) {
        MostrarMensaje('Esa letra ya la intentaste.');
        return;
      }

      LetrasUsadas.push(LetraIngresada);

      var HuboAcierto = false;
      for (var i = 0; i < PalabraSecreta.length; i++) {
        if (PalabraSecreta[i] === LetraIngresada) {
          LetrasDescubiertas[i] = true;
          HuboAcierto = true;
        }
      }

      if (!HuboAcierto) {
        CantidadIntentos++;
        Intentos.textContent = CantidadIntentos;
      }

      DibujarPalabra();
      DibujarLetrasFallidas();
      ChequearVictoria();
    });
  }

  if (BotonArriesgarPalabra) {
    BotonArriesgarPalabra.addEventListener('click', function () {
      LimpiarMensaje();
      var EntradaPalabra = document.getElementById('entradaPalabra');
      var PalabraArriesgada = (EntradaPalabra.value || '').toLowerCase();
      if (PalabraArriesgada === '') return;

      if (PalabraArriesgada === PalabraSecreta) {
        FinalizarPartida(true);
      } else {
        CantidadIntentos++;
        Intentos.textContent = CantidadIntentos;
        MostrarMensaje('Respuesta incorrecta. Fin de la partida.');
        FinalizarPartida(false);
      }
    });
  }

  //Funciones
  function DibujarPalabra() {
    var Texto = '';
    for (var i = 0; i < PalabraSecreta.length; i++) {
      Texto += (EstaDescubierta(i) ? PalabraSecreta[i] : '_') + ' ';
    }
    PalabraReal.textContent = Texto.trim();
  }

  function EstaDescubierta(indice) {
    return LetrasDescubiertas[indice] === true;
  }

  function DibujarLetrasFallidas() {
    var Fallidas = [];
    for (var i = 0; i < LetrasUsadas.length; i++) {
      var c = LetrasUsadas[i];
      if (!EstaEnPalabra(c)) {
        Fallidas.push(c);
      }
    }
    LetrasFallidas.textContent = Fallidas.join(' ');
  }

  function EstaEnPalabra(letra) {
    for (var i = 0; i < PalabraSecreta.length; i++) {
      if (PalabraSecreta[i] === letra) return true;
    }
    return false;
  }

  function LetraYaUsada(letra) {
    for (var i = 0; i < LetrasUsadas.length; i++) {
      if (LetrasUsadas[i] === letra) return true;
    }
    return false;
  }

  function ChequearVictoria() {
    for (var i = 0; i < LetrasDescubiertas.length; i++) {
      if (EstaDescubierta(i) === false) return;
      // sí aún falta descubrir letras debuelve
    }
    // si no termina
    FinalizarPartida(true);
  }

    function FinalizarPartida(Gano) {
      //función redirige a la pantalla de resultado com gano o perdio
      var Query = '?gano=' + (Gano ? 'true' : 'false') + '&intentos=' + CantidadIntentos;
      //Guarda 2 bariables, si gano/perdio y cuantos intentos hizo
      window.location.href = '/Home/Resultado' + Query;
      //Redirige y le suma las 2 bariables
    }

  function MostrarMensaje(texto) { if (Mensaje) Mensaje.textContent = texto; }
  function LimpiarMensaje() { if (Mensaje) Mensaje.textContent = ''; }
});
