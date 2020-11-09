storageService = {
    existsInLocalStorage: function (recipeId, storageKey) {

        var existingStorage = localStorage.getItem(storageKey); // vo local storage se cuva kako string i so parse pravime objekt
        var exists = false;
        if (existingStorage != null) {
            var parsed = JSON.parse(existingStorage)
            exists = parsed.indexOf(recipeId) !== -1;
        }
        return exists;
    },
    addToLocalStorage: function (recipeId, storageKey) {
        var storageData = []; //prazen array

        //get items from local storage
        var existingStorage = localStorage.getItem(storageKey); // vaka gi zema kako string

        if (existingStorage != null) {
            storageData = JSON.parse(existingStorage); //pretvori vo objekt ili array
        }

        if (storageData.indexOf(recipeId) == -1) {
            storageData.push(recipeId);
        }
        var serialized = JSON.stringify(storageData);

        localStorage.setItem(storageKey, serialized) //cartItems=key po ova ke barame vo localStorage

    },
    removeFromLocalStorage: function (recipeId, storageKey) {
        var existingStorage = localStorage.getItem(storageKey);
        if (existingStorage != null) {
            var storage = JSON.parse(existingStorage);
            storage = storage.filter(x => {
                return x != recipeId;
            })
            localStorage.setItem(storageKey, JSON.stringify(storage));
        }
    },
    getFromLocalStorage: function (storageKey) {
        return JSON.parse(localStorage.getItem(storageKey))
    },
    clearStorage: function (storageKey) {
        localStorage.removeItem(storageKey);

    }
}