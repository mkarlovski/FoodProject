function CreateRecipe() {
    
    var ingredients = [];

    var title = document.getElementById("recipeTitle").value;
    var description = document.getElementById("recipeDescription").value;
    var ingredientList = document.getElementsByClassName("recipeIngredientClass");
    for (i = 0; i < ingredientList.length; i++) {
        var ingredientValue = document.getElementById("recipeIngredient[" + i + "]").value;
        ingredients.push(ingredientValue);
    }


    axios.post('https://localhost:44319/Recipe/CreateTest', {
        
        title: title,
        description: description,
        ingredients: ingredients
    })
        .then(function (response) {
            console.log(response.data);

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
    newList.style.listStyleType = "none";

    var input = document.createElement("input");
    input.setAttribute("asp-for", "Ingredients[" + ingredientCount + "]");
    input.setAttribute("type", "text"); 
    input.setAttribute("placeholder", "Enter Ingredient");
    input.classList.add("recipeIngredientClass");
    input.id = "recipeIngredient["+ingredientCount+"]";

    list.appendChild(newList);
    newList.appendChild(input);

}
//<ol id="CreateRecipe">
//    <li class="addIngredientList" id="Ingredient1">
//        <input asp-for="Ingredients[0]" id="recipeIngredient[0]" class="recipeIngredientClass" type="text" placeholder="Add Ingredient">
//        </li>
//    </ol>