// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function submitPokemonForm() {

    const form = document.getElementById('pokemonForm');
    const formData = new FormData(form);

    fetch(form.action, {
        method: 'POST',
        body: formData,
        headers: {
            'RequestVerificationToken': document.getElementsByName('__RequestVerificationToken')[0].value
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.text();
        })
        .then(result => {
            alert("Succesfully added your pokemon to list! Try Loading pokemons again..")
        })
        .catch(error => {
            console.error('Error:', error);
            // Handle error, maybe display error message
        });
}