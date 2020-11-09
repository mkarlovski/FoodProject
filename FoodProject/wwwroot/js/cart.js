//get from local storage
function initCart() {
    var cartItems = storageService.getFromLocalStorage("cartItems");

    //axios get for each id
    for (let i = 0; i < cartItems.length; i++) {
        axios.get(`https://localhost:44319/api/books/${cartItems[i]}`) //bidejki e array vaka gi zemame site podatoci od api
            .then(function (response) {
                console.log(response.data);
                createCartItem(response.data)

            })
            .catch(function (error) {
                console.log(error);
            });

    }
}

function createCartItem(book) {

    var cartContainer = document.getElementById("card-container");

    var card = document.createElement("div");
    card.classList.add("bookCard");

    var cardTitle = document.createElement("h4");
    cardTitle.innerHTML = `Title: ${book.title} - Author:${book.author}`;

    var cardPrice = document.createElement("h4");
    cardPrice.innerHTML = `Price: ${book.price}`;

    var cardBtn = document.createElement("button");
    cardBtn.classList.add("btn");
    cardBtn.classList.add("btn-primary");
    cardBtn.innerHTML = "Remove from cart";;
    cardBtn.onclick = function (e) {
        removeFromCart(e, book.id)
    };

    card.appendChild(cardTitle);
    card.appendChild(cardPrice);
    card.appendChild(cardBtn);

    cartContainer.appendChild(card);
}


function removeFromCart(event, bookId) {
    storageService.removeFromLocalStorage(bookId, "cartItems");
    event.target.parentElement.remove(); //so ova go briseme Parent div-ot
}


function orderBooks() {
    //get all input
    var name = document.getElementById("customerName").value; //so ova gi zemame vrednostite od polinja na form
    var email = document.getElementById("customerEmail").value;
    var address = document.getElementById("customerAddress").value;
    var phone = document.getElementById("customerPhone").value;

    //get bookIds from Local Storage
    var storageData = storageService.getFromLocalStorage("cartItems");

    //send to api
    if (storageData.length > 1) {
        axios.post('https://localhost:44319/api/orders', {
            name: name,
            email: email,
            phone: phone,
            address: address,
            bookIds: storageData
        })
            .then(function (response) {
                console.log(response.data);
                alert(`Thanks for ordering: Your order code is: ${response.data}`)
                storageService.clearStorage("cartItems");
                location.href = "./index.html";

            })
            .catch(function (error) {
               
            });
    }
}

initCart();


