var precioTotal = 0;
var productosComprados = "";
var contador = 0;
function agregarArticulo(nombre, precio) {
    var nuevoProducto = document.createElement("li");
    nuevoProducto.className = "nombre" + contador;
   
    nuevoProducto.style = "margin-bottom:30px;";
    var botonEliminar = document.createElement("button");
    botonEliminar.id = "botonEliminar" + contador;
    botonEliminar.innerHTML = "X"
    botonEliminar.style = "background-color: #F24B4B; border:none; color: white; margin-left:20px;";
    
    var nombreArticulo = document.createTextNode(nombre + " ₡" + precio);
    nuevoProducto.appendChild(nombreArticulo);
    nuevoProducto.appendChild(botonEliminar);
    document.getElementById("listaArticulos").appendChild(nuevoProducto);
    
    obtenerArticulos(nombre, precio);
    calcularTotal(precio);
    document.getElementById("botonEliminar" + contador).addEventListener("click", eliminarArticulo("nombre" + contador));
   
    contador = parseFloat(contador) + parseFloat(1);
}

function eliminarArticulo(nombreClase) {
    console.log(nombreClase);
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

function articulos() {
    return productosComprados;
}

function obtenerProductos() {
    document.getElementById("productosComprador").value = productosComprados;
    document.getElementById("subtotalPrecio").value = precioTotal;
    console.log(document.getElementById("productosComprador").value);
}