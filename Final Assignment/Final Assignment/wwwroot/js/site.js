// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Function to animate the box when the button is clicked
function moveBox() {

    // Get the box element from the page
    let box = document.getElementById("box");

    // Starting position
    let position = 0;

    // Move the box repeatedly
    let animation = setInterval(function () {

        // Stop animation when box reaches 300px
        if (position >= 300) {
            clearInterval(animation);
        } else {

            // Move box one pixel at a time
            position++;

            // Update the box position
            box.style.left = position + "px";
        }
    }, 5);// Speed of animation
}