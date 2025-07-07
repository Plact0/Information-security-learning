document.addEventListener('DOMContentLoaded', function () {
    const currentUrl = window.location.href;
    const homePageUrl = "http://yourdomain.com/home.html";
    const isCurrentPage = currentUrl === homePageUrl;

    if (isCurrentPage) {
        const homepageLinkElement = document.querySelector('.homepage-link');
        if (homepageLinkElement) {
            homepageLinkElement.classList.add('homepage-link');
        }
    }
});