var precioTotal = 0;
var productosComprados = [];

function agregarArticulo(nombre, precio) {
    var nuevoProducto = document.createElement("li");
    nuevoProducto.style = "margin-bottom:30px;";
    var nombreArticulo = document.createTextNode(nombre + " ₡" + precio);
    nuevoProducto.appendChild(nombreArticulo);
    document.getElementById("listaArticulos").appendChild(nuevoProducto);
    obtenerArticulos(nombre);
    calcularTotal(precio);
    console.log(nombre);

}

function calcularTotal(precio) {
    precioTotal = parseFloat(precioTotal) + parseFloat(precio);
    console.log(precioTotal);
    document.getElementById("total-pagar").innerHTML = "Subtotal: " + precioTotal;
}

function obtenerArticulos(nombre) {
    productosComprados.push(nombre);
    console.log(productosComprados);
    return productosComprados;
}