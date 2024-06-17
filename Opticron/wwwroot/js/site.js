// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// slickjs template
// $(document).ready(function(){
//     $('.your-class').slick({
//       setting-name: setting-value
//     });
//   });

$('.single-item').slick({
        dots: true,
        responsive: true,
});

$('.product-categories').slick({
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 3000
});