document.addEventListener("DOMContentLoaded", function () {
    const navbarToggle = document.getElementById("navbarToggle");
    const navList = document.getElementById("navList");

    navbarToggle.addEventListener("click", function () {
        navList.classList.toggle("show");
    });
});