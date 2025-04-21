var timer;

/*function toggleNav()
{
    clearTimeout(timer);

    var button = document.getElementById("nav_button");
    button.classList.toggle("right");

    var navbar = document.getElementById("navbar");
    var main = document.getElementById("home_help");

    if (navbar.style.left == 0)
    {
        main.style.transition = "all 1s";
        navbar.style.transition = "left 1s";
        button.style.transition = "transform 1s, margin-left 1s";

        main.style.width = "100%";
        main.style.marginLeft = 0;
        button.style.marginLeft = 0;
        navbar.style.left = "-15vw";
    }
    else if (navbar.style.left == "-15vw")
    {
        main.style.transition = "all 1s";
        button.style.transition = "transform 1s, margin-left 1s";
        navbar.style.transition = "left 1s";

        main.style.width = "85%";
        main.style.marginLeft = "15%";
        button.style.marginLeft = "15vw";
        navbar.style.left = 0;
    }
    else
    { 
        main.style.transition = "all 1s";
        button.style.transition = "transform 1s, margin-left 1s";
        navbar.style.transition = "left 1s";

        main.style.width = "100%";
        main.style.marginLeft = 0;
        button.style.marginLeft = 0;
        navbar.style.left = "-15vw";
    }

    timer = setTimeout(removeTransition, 1000);
}

function removeTransition()
{
    var element = document.getElementById("home_help");
    element.style.transition = "";

    element = document.getElementById("nav_button");
    element.style.transition = "transform 1s ease-in";

    element = document.getElementById("navbar");
    element.style.transition = "";

    clearTimeout(timer);
}*/