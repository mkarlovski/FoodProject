function ValidateComment() {
    var comment = document.getElementById("comment").value;

    if (comment == null || comment == " ") {
        alert("Please enter comment");
        return false;
    }
    else {
        return true;
    }
}