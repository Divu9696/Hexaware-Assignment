// Handle Registration
document.getElementById("registrationForm").addEventListener("submit", function (e) {
  e.preventDefault(); // Prevent page reload

  const username = document.getElementById("regUsername").value;
  const password = document.getElementById("regPassword").value;
  const contact = document.getElementById("contact").value;

  // Check if user already exists
  if (localStorage.getItem(username)) {
    document.getElementById("message").innerText = "User already registered!";
  } else {
    // Store user details
    const userDetails = {
      password: password,
      contact: contact,
    };
    localStorage.setItem(username, JSON.stringify(userDetails));

    // Show success message and switch to login form
    document.getElementById("message").innerText = "Registration successful!";
    switchToLoginForm();
  }
});

// Handle Login
document.getElementById("loginForm").addEventListener("submit", function (e) {
  e.preventDefault(); // Prevent page reload

  const username = document.getElementById("loginUsername").value;
  const password = document.getElementById("loginPassword").value;

  // Retrieve user details
  const storedUser = localStorage.getItem(username);

  if (storedUser) {
    const userDetails = JSON.parse(storedUser);
    if (userDetails.password === password) {
      document.getElementById("message").innerText = "Login successful!";
    } else {
      document.getElementById("message").innerText = "Incorrect password!";
    }
  } else {
    document.getElementById("message").innerText = "User not found!";
  }
});

// Switch to Login Form after Registration
function switchToLoginForm() {
  document.getElementById("registrationContainer").style.display = "none";
  document.getElementById("loginContainer").style.display = "block";
}
