function EditRecipe()
{
    var ingredients = [];

    var id = document.getElementById("recipeId").value;
    var title = document.getElementById("recipeTitle").value;
    var description = document.getElementById("recipeDescription").value;
    var ingredientList = document.getElementsByClassName("recipeIngredientClass");
    var preparation = document.getElementById("recipePreparation").value;

    for (i = 0; i < ingredientList.length; i++) {
        var ingredientValue = document.getElementById("recipeIngredient[" + i + "]").value;
        if (ingredientValue != null) {
            ingredients.push(ingredientValue);
        }

    }
   

    axios.post('https://localhost:44319/Recipe/EditRecipeTest', {
        id:id,
        title: title,
        description: description,
        ingredients: ingredients,
        preparation: preparation,
    })
        .then(function (response) {
            console.log(response.data);
            window.location.href = '/recipe/manageRecipes';
        })
        .catch(function (error) {
            console.log(error.response);
        });

}

function AddIngredient() {

    var list = document.getElementById("CreateRecipe");
    var ingredientCount = document.getElementsByClassName("addIngredientList").length;

    var newList = document.createElement("li");
    newList.classList.add("addIngredientList");


    var input = document.createElement("input");
    input.setAttribute("asp-for", "Ingredients[" + ingredientCount + "]");
    input.setAttribute("type", "text");
    input.setAttribute("placeholder", "Enter Ingredient");
    input.classList.add("recipeIngredientClass");
    input.id = "recipeIngredient[" + ingredientCount + "]";
    input.style.border = "none";

    list.appendChild(newList);
    newList.appendChild(input);

}