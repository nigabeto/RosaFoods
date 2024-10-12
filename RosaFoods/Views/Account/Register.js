// Função para alternar a exibição de um popup de campo obrigatório
function togglePopup(input, label) {
    input.addEventListener("focus", () => {
        label.classList.add("required-popup");
    });

    input.addEventListener("blur", () => {
        label.classList.remove("required-popup");
    });
}
// Função para estilizar um input correto
function estilizarInputCorreto(input, helper) {
    input.classList.remove("error");
    input.classList.add("correct");
    helper.classList.remove("visible");
}
// Função para estilizar um input incorreto
function estilizarInputIncorreto(input, helper) {
    input.classList.remove("correct");
    input.classList.add("error");
    helper.classList.add("visible");
}
// Validar o username
let usernameInput = document.getElementById("UserName");
let usernameLabel = document.querySelector('label[for="UserName"]');
let usernameHelper = document.createElement("span");
usernameHelper.classList.add("text-danger");
usernameLabel.after(usernameHelper);

togglePopup(usernameInput, usernameLabel);

usernameInput.addEventListener("change", function (e) {
    let valor = e.target.value;

    if (valor.length >= 3) {
        console.log("input válido");
        estilizarInputCorreto(usernameInput, usernameHelper);
        usernameHelper.innerText = "";
    } else {
        console.log("Username deve possuir 3 ou mais caractéres");
        estilizarInputIncorreto(usernameInput, usernameHelper);
        usernameHelper.innerText = "Username deve possuir 3 ou mais caractéres";
    }
});
// Validar a senha
let senhaInput = document.getElementById("Password");
let senhaLabel = document.querySelector('label[for="Password"]');
let senhaHelper = document.createElement("span");
senhaHelper.classList.add("text-danger");
senhaLabel.after(senhaHelper);

togglePopup(senhaInput, senhaLabel);

senhaInput.addEventListener("blur", (e) => {
    let valor = e.target.value;

    if (valor === "") {
        senhaHelper.innerText = "O campo senha não pode estar vazio!!!";
        estilizarInputIncorreto(senhaInput, senhaHelper);
    } else {
        console.log("valor correto");
        estilizarInputCorreto(senhaInput, senhaHelper);
        senhaHelper.innerText = "";
    }
});
