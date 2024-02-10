function validateForm() {
    var uName = document.getElementById("uName").value;
    var fName = document.getElementById("fName").value;
    var lName = document.getElementById("lName").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    // Regular expressions for validation
    var usernameRegex = /^[a-zA-Z0-9_]+$/;
    var nameRegex = /^[a-zA-Z]+$/;
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;


    // Validation for username
    if (!uName.match(usernameRegex)) {
        alert("Please enter a valid username. It should contain only letters, numbers, or underscores.");
        return false;
    }

    // Validation for first name
    if (!fName.match(nameRegex)) {
        alert("Please enter a valid first name. It should contain only letters.");
        return false;
    }

    // Validation for last name
    if (!lName.match(nameRegex)) {
        alert("Please enter a valid last name. It should contain only letters.");
        return false;
    }

    // Validation for email
    if (!email.match(emailRegex)) {
        alert("Please enter a valid email address.");
        return false;
    }

    // Validation for password
    if (password.length < 8) {
        alert("Please enter a valid password. It should be at least 8 characters long.");
        return false;
    }

    return true; // Form is valid
}
