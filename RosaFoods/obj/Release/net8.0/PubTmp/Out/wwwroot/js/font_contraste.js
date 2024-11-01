const body = document.body;
const increaseFont = document.getElementById('increaseFont');
const decreaseFont = document.getElementById('decreaseFont');
const highContrast = document.getElementById('highContrast');

let fontSize = 16;
let highContrastActive = false;

increaseFont.addEventListener('click', () => {
    fontSize += 2;
    body.style.fontSize = fontSize + 'px';
});

decreaseFont.addEventListener('click', () => {
    if (fontSize > 12) {
        fontSize -= 2;
        body.style.fontSize = fontSize + 'px';
    }
});

highContrast.addEventListener('click', () => {
    highContrastActive = !highContrastActive;
    if (highContrastActive) {
        body.classList.add('high-contrast');
    } else {
        body.classList.remove('high-contrast');
    }
});