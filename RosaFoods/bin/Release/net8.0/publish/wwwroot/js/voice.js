
const voiceSearchButton = document.getElementById('voiceSearchButton');
const voiceSearchInput = document.getElementById('voiceSearch');
voiceSearchButton.addEventListener('click', () => {
    if ('webkitSpeechRecognition' in window) {
        const recognition = new webkitSpeechRecognition();
        recognition.lang = 'pt-BR';

        recognition.onresult = function(event) {
            console.log('Resultado de voz:', event.results[0][0].transcript); // Exibe o resultado no console
            voiceSearchInput.value = event.results[0][0].transcript;  // Preenche o campo de entrada
        };

        recognition.onerror = function(event) {
            console.error('Erro no reconhecimento de voz:', event.error); // Exibe qualquer erro
        };

        recognition.onend = function() {
            console.log('Reconhecimento de voz finalizado');
        };

        recognition.start();
    } else {
        alert('Este navegador não suporta entrada por voz.');
    }
});
