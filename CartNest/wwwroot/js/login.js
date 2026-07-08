document.getElementById("btnLogin")
    .addEventListener("click", async function () {

        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;

        const response = await fetch("/api/AuthApi/Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                username: username,
                password: password
            })
        });

        if (response.ok) {
            window.location.href = "/Admin/Dashboard/Index";
        }
        else {
            document.getElementById("message").innerHTML =
                "Invalid Username or Password";
        }
    });