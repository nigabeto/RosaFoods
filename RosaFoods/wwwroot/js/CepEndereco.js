// Função para mudar a cor de fundo da label para verde claro quando o campo é preenchido
function mudarCorLabel(labelId) {
    var input = document.getElementById(labelId.replace('label', ''));
    var label = document.getElementById(labelId);
    if (input.value.trim() !== "") {
        label.style.backgroundColor = "lightgreen";
    } else {
        label.style.backgroundColor = "";
    }
}

// Função para exibir uma mensagem temporária no campo de CEP ao focar
function mostrarMensagemCep() {
    var labelCep = document.getElementById("labelCep");
    labelCep.innerHTML = "Insira o CEP para preenchimento do endereço";
    labelCep.style.color = "blue";

    setTimeout(function () {
        labelCep.innerHTML = ""; // Limpa a mensagem após 5 segundos
    }, 5000);
}

// Função para limpar o formulário de CEP
function limpa_formulario_cep() {
    document.getElementById('Endereco1').value = "";
    document.getElementById('Cidade').value = "";
    document.getElementById('Estado').value = "";
}

// Função callback do CEP
function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        document.getElementById('Endereco1').value = (conteudo.logradouro);
        document.getElementById('Cidade').value = (conteudo.localidade);
        document.getElementById('Estado').value = (conteudo.uf);
    } else {
        limpa_formulario_cep();
        alert("CEP não encontrado.");
    }
}

// Função para buscar o CEP
function pesquisacep(valor) {
    var cep = valor.replace(/\D/g, '');

    if (cep !== "") {
        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {
            document.getElementById('Endereco1').value = "...";
            document.getElementById('Cidade').value = "...";
            document.getElementById('Estado').value = "...";

            var script = document.createElement('script');
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';
            document.body.appendChild(script);
        } else {
            limpa_formulario_cep();
            alert("Formato de CEP inválido.");
        }
    } else {
        limpa_formulario_cep();
    }
}