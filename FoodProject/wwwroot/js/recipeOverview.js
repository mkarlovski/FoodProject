

function RecipeLike(recipeId) {
    axios.post('https://localhost:44319/RecipeLikes/Like', {
        recipeId: recipeId
    })
        .then(function () {
            //var removeLikeBtn = document.getElementById("btnAddLike");

            //if (!removeLikeBtn.classList.contains("displayNone")) {
            //    DecreaseEngagementCount("dislikeCountContainer");
            //    SwitchDisplay("btnAddDislike", "btnRemoveDislike");
            //}


            SwitchDisplay("btnRemoveLike", "btnAddLike");
        })
        .catch(function (error) {
            console.log(error)
        });
}



function RemoveRecipeLike(recipeId) {
    axios.post('https://localhost:44319/RecipeLikes/RemoveLike', {
        recipeId: recipeId
    })
        .then(function () {
           
            SwitchDisplay("btnAddLike", "btnRemoveLike");
        })
        .catch(function (error) {
            console.log(error)
        });
}


function SwitchDisplay(showElement, hideElement) {
    var showEl = document.getElementById(showElement);
    var hideEl = document.getElementById(hideElement);

    showEl.classList.remove("displayNone");
    hideEl.classList.add("displayNone");
}
