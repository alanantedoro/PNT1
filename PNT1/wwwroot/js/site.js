// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function validacionCatalogo() {

    let item = document.getElementsByTagName("input");
    let selecccion = [];

    for (i = 0; i < item.length; i++) {
        if (item[i].checked) {
            selecccion.push(item[i].id);
        }
        return seleccion;
    }
}