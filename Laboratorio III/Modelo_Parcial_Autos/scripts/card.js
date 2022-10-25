function crearTarjeta(card_titulo, card_desc, card_valor, card_cantPuertas, card_km, card_potencia){
    const $mainCard = createElementCustom("section", ["card"], "", {});
    $mainCard.appendChild(createElementCustom("h3", ["card-title"], card_titulo, {}));
    $mainCard.appendChild(createElementCustom("p", ["description"], card_desc, {}));
    $mainCard.appendChild(createElementCustom("p", ["valor"], `$${card_valor}`, {}));
    $mainCard.appendChild(cardElementos(card_cantPuertas, card_km, card_potencia));
    $mainCard.appendChild(createElementCustom("button", ["btn-vehiculo"], "Ver vehículo", {}));
    return $mainCard;
}

function cardElementos(cant_puertas, cant_km, cant_potencia){
    const $cardElementos = createElementCustom("div", ["elementos"], )
    $cardElementos.appendChild(newElemento("puertas", "puerta", cant_puertas));
    $cardElementos.appendChild(newElemento("kilometraje", "km", cant_km));
    $cardElementos.appendChild(newElemento("potencia", "potencia", cant_potencia));
    return $cardElementos;
}

function newElemento(nombre_clase, tipo, cantidad){
    const $element = createElementCustom("div", [nombre_clase], "", {});
    switch(tipo){
        case "puerta":
            $element.appendChild(createElementCustom("img", [], "", {"src":"./images/puerta_auto.png", "width":"50px", "alt":"puertas"}));
            $element.appendChild(createElementCustom("p", [], cantidad, {}));
            break;
        case "km":
            $element.appendChild(createElementCustom("img", [], "", {"src":"./images/velocimetro.png", "width":"50px", "alt":"kilometros"}));
            $element.appendChild(createElementCustom("p", [], cantidad, {}));
            break;
        case "potencia":
            $element.appendChild(createElementCustom("img", [], "", {"src":"./images/potencia.png", "width":"50px", "alt":"potencia"}));
            $element.appendChild(createElementCustom("p", [], cantidad, {}));
            break;
    }
    return $element;
}

function createElementCustom(tipoElemento, clases, contenidoTexto, atributos){
    const newElement = document.createElement(tipoElemento);
    if (Array.isArray(clases) && clases.length > 0){
        newElement.classList.add(...clases);
    }
    if (contenidoTexto != null && contenidoTexto != undefined && contenidoTexto.length > 0){
        newElement.textContent = contenidoTexto;
    }
    if (typeof(atributos) == "object"){
        Object.keys(atributos).forEach((atributo) => {
            newElement.setAttribute(atributo, atributos[atributo]);
        })
    }
    return newElement;
}

export { crearTarjeta };