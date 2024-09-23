// Модальное окно для меню
document.getElementById('menu-modal').style.display = 'none'; // Скрыть модальное окно по умолчанию
document.querySelector('.menu-icon').addEventListener('click', function() {
    document.getElementById('menu-modal').style.display = 'block';
});
document.getElementById('close-modal').addEventListener('click', function() {
    document.getElementById('menu-modal').style.display = 'none';
});
window.addEventListener('click', function(event) {
    const modal = document.getElementById('menu-modal');
    if (event.target === modal) {
        modal.style.display = 'none';
    }
});

// Модальное окно для дополнительных действий
document.getElementById('more-options-modal').style.display = 'none'; // Скрыть модальное окно по умолчанию
document.getElementById('more-options-button').addEventListener('click', function() {
    document.getElementById('more-options-modal').style.display = 'block';
});
document.getElementById('close-more-options-modal').addEventListener('click', function() {
    document.getElementById('more-options-modal').style.display = 'none';
});
window.addEventListener('click', function(event) {
    const modal = document.getElementById('more-options-modal');
    if (event.target === modal) {
        modal.style.display = 'none';
    }
});

// Обработчики для кнопок в модальном окне дополнительных действий
document.getElementById('clear-list-button').addEventListener('click', function() {
    // Логика для очистки списка
    console.log("Список очищен");
});
document.getElementById('close-without-payment-button').addEventListener('click', function() {
    // Логика для закрытия без оплаты
    console.log("Закрыто без оплаты");
});
document.getElementById('guest-left-button').addEventListener('click', function() {
    // Логика для случая, когда гость ушел
    console.log("Гость ушел");
});
