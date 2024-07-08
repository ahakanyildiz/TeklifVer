document.addEventListener('DOMContentLoaded', function () {
    // Hamburger menü işlemleri
    var hamburger = document.querySelector('.hamburger-menu');
    var navbarMenu = document.querySelector('.navbar-menu');

    hamburger.addEventListener('click', function () {
        this.classList.toggle('open');
        navbarMenu.classList.toggle('active');
    });

    // Slider işlemleri
    const slides = document.querySelectorAll('.slide');
    const prevBtn = document.querySelector('.prev-btn');
    const nextBtn = document.querySelector('.next-btn');

    let currentIndex = 0;

    function showSlide(index) {
        slides.forEach((slide, i) => {
            if (i === index) {
                slide.classList.add('active');
            } else {
                slide.classList.remove('active');
            }
        });
    }

    function nextSlide() {
        currentIndex++;
        if (currentIndex >= slides.length) {
            currentIndex = 0;
        }
        showSlide(currentIndex);
    }

    function prevSlide() {
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = slides.length - 1;
        }
        showSlide(currentIndex);
    }

    nextBtn.addEventListener('click', nextSlide);
    prevBtn.addEventListener('click', prevSlide);

    // Otomatik geçiş için
    setInterval(nextSlide, 5000); // 5 saniyede bir geçiş yapar, istediğiniz süreyi ayarlayabilirsiniz
});
