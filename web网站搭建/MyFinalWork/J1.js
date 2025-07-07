//图片轮播
window.onload = function () {
    var boximg = document.querySelectorAll('.box-img');
    var currentIndex = 0; // 当前显示的图片索引  
    var dots = document.querySelectorAll('.box-dot li'); // 获取小圆点  

    // 显示当前图片  
    function showCurrentImage() {
        boximg.forEach((img, index) => {
            img.style.opacity = index === currentIndex ? 1 : 0;
        });
        // 更新小圆点状态  
        dots.forEach(dot => dot.classList.remove('active'));
        dots[currentIndex].classList.add('active');
    }

    // 切换到下一张图片  
    function nextImage() {
        currentIndex = (currentIndex + 1) % boximg.length;
        showCurrentImage();
    }

    // 切换到上一张图片  
    function prevImage() {
        currentIndex = (currentIndex - 1 + boximg.length) % boximg.length;
        showCurrentImage();
    }

    // 自动播放  
    setInterval(nextImage, 3000);

    // 绑定左右箭头点击事件  
    var boxleft = document.querySelector('.box-left');
    var boxright = document.querySelector('.box-right');

    boxleft.addEventListener('click', prevImage);
    boxright.addEventListener('click', nextImage);

    // 绑定小圆点点击事件  
    dots.forEach((dot, index) => {
        dot.addEventListener('click', function () {
            currentIndex = index;
            showCurrentImage();
        });
    });

};  

