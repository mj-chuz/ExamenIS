var precioTotal = 0;
var productosComprados = "";
var contador = 0;
var primeraVez = true;

function agregarArticulo(nombre, precio) {
    var nuevoProducto = document.createElement("li");
    nuevoProducto.className = "nombre" + contador;
    nuevoProducto.style = "margin-bottom:30px;";
    var nombreArticulo = document.createTextNode(nombre + " ₡" + precio);
    nuevoProducto.appendChild(nombreArticulo);
    document.getElementById("listaArticulos").appendChild(nuevoProducto);
    obtenerArticulos(nombre, precio);
    
    contador = parseFloat(contador) + parseFloat(1);
    if (document.getElementById("pizza-personalizada") != null && primeraVez === true) {
        var pizzaPersonalizada = document.getElementById("pizza-personalizada").textContent;
        var precioPizza = pizzaPersonalizada.split('₡');
        precioTotal = parseFloat(precioTotal) + parseFloat(precioPizza[1]);
        primeraVez = false;
        console.log(pizzaPersonalizada);
        console.log(precioPizza);
    }
    calcularTotal(precio);
}


function calcularTotal(precio) {
    precioTotal = parseFloat(precioTotal) + parseFloat(precio);
    console.log(precioTotal);
    document.getElementById("total-pagar").innerHTML = "Subtotal: " + precioTotal;
}

function obtenerArticulos(nombre, precio) {
    productosComprados = nombre + " ₡" + precio + "," + productosComprados;
    console.log(productosComprados);
    return productosComprados;
}

function obtenerProductos() {
    if (document.getElementById("pizza-personalizada") != null) {
        var pizzaPersonalizada = document.getElementById("pizza-personalizada").textContent;
        productosComprados = productosComprados +","+ pizzaPersonalizada;
    }
    
    document.getElementById("productosComprados").value = productosComprados;
    document.getElementById("subtotalPrecio").value = precioTotal;
    console.log(document.getElementById("productosComprados").value);
}