document.addEventListener(function () {
    const dropbtn = document.querySelector(".dropbtn");
    const dropdown = document.querySelector(".dropdown-content");

    dropbtn.addEventListener("click", function (e) {
        e.stopPropagation(); // så klik udenfor kan fange det senere
        dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
    });

    window.addEventListener("click", function () {
        dropdown.style.display = "none";
    });
});
