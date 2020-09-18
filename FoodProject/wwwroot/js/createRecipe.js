function CreateRecipe() {
    
    var ingredients = [];

    var title = document.getElementById("recipeTitle").value;
    var description = document.getElementById("recipeDescription").value;
    var ingredientList = document.getElementsByClassName("recipeIngredientClass");
    for (i = 0; i < ingredientList.length; i++) {
        var ingredientValue = document.getElementById("recipeIngredient[" + i + "]").value;
        if (ingredientValue != null) {
            ingredients.push(ingredientValue);
        }
        
    }
    var preparation = document.getElementById("recipePreparation").value;
    
    debugger;
    axios.post('https://localhost:44319/Recipe/CreateTest', {
        
        title: title,
        description: description,
        ingredients: ingredients,
        preparation: preparation,
        

    })
    
        .then(function (response) {
            console.log(response.data);
            window.location.href = '/recipe/overview';
            
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
