document.addEventListener("DOMContentLoaded", function () {
    // Selecionar o formulário e os campos
    const form = document.querySelector("form");
    const userNameInput = document.getElementById("UserName");
    const passwordInput = document.getElementById("Password");

    // Função para validar os campos
    function validateInputs() {
        let isValid = true;

        // Validar o campo UserName
        if (userNameInput.value.length < 3) {
            alert("O campo 'UserName' deve ter pelo menos 3 caracteres.");
            isValid = false;
        }

        // Validar o campo Password
        if (passwordInput.value.length < 3) {
            alert("O campo 'Password' deve ter pelo menos 3 caracteres.");
            isValid = false;
        }

        return isValid;
    }

    // Adicionar um listener ao evento submit do formulário
    form.addEventListener("submit", function (event) {
        if (!validateInputs()) {
            // Se os campos não forem válidos, impedir o envio do formulário
            event.preventDefault();
        }
    });
});