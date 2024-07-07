// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const activePage = window.location.pathname;
const navLinks = document.querySelectorAll('nav li').forEach(link => {
    if (link.href.includes(`${activePage}`)) {
        link.classList.add('active');
        console.log(link);
    }
})