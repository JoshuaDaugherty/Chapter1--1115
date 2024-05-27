// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function clearForm() {
    document.getElementById("subtotal").value = "";
    document.getElementById("discountPercent").value = "";
    document.getElementById("discountAmount").value = "";
    document.getElementById("total").value = "";

    document.getElementById("subtotalError").innerHTML = "";
    document.getElementById("discountPercentError").innerHTML = "";
}