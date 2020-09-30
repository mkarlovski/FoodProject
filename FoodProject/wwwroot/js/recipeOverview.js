

function RecipeLike(recipeId) {
    
    axios.post('/RecipeLikes/like', {
        recipeId: recipeId
    })
        .then(function (response) {
            
            //SwitchDisplay("btnRemoveLike", "btnAddLike");
            window.location.href = '/recipe/overview';
        })
        .catch(function (error) {
            
        });
}



function RemoveRecipeLike(recipeId) {
    axios.post('https://localhost:44319/RecipeLikes/removeLike', {
        recipeId: recipeId
    })
        .then(function (response) {
            
            SwitchDisplay("btnAddLike", "btnRemoveLike");

        })
        .catch(function (error) {
          
        });
}


function SwitchDisplay(showElement, hideElement) {
    var showEl = document.getElementById(showElement);
    var hideEl = document.getElementById(hideElement);

    showEl.classList.remove("displayNone");
    hideEl.classList.add("displayNone");
}
