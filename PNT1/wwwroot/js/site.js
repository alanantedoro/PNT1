// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function carritoCheck() {

    let size = document.getElementsByTagName("tr")

    let len = size.length;

    if (len == 1) {
        alert("El carrito esta vacio");
        return false;
    }

}