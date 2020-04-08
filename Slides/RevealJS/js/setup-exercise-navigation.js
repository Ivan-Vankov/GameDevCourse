var sections = document.getElementsByClassName("slides")[0].children;
for (let i = 1; i < sections.length - 1; ++i) {
    sections[i].setAttribute("data-state", "hide-exercise-navigation-arrows");
}

sections[0].setAttribute("data-state", "show-left-exercise-navigation-arrow");
sections[sections.length - 1].setAttribute("data-state", "show-right-exercise-navigation-arrow");