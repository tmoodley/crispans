$(document).ready(function(){
    $('.slideshow-vision').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3,
        showDots: false,
        arrows: false, 
        centerPadding: "0px",
        responsive: [
            {
              breakpoint: 768,
              settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: true,
                arrows: true,
                showArrows: true,
                prevArrow: '<button type="button" class="slick-prev"><i class="fa fa-chevron-left"></i></button>',
                nextArrow: '<button type="button" class="slick-next"><i class="fa fa-chevron-right"></i></button>' 
              }
            }
        ]
    });

    $('.slideshow-testimonial').slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        showDots: false,
        arrows: false
    });

    AOS.init();

    var rellax = new Rellax('.rellax', {
      speed: -2,
      center: false,
      wrapper: null,
      round: true,
      vertical: true,
      horizontal: false
    });
  });
  
  $(function(){
    var hash = window.location.hash;
    hash && $('#list-tab a[href="' + hash + '"]').tab('show');
  
    $('#account-dropdown a').click(function (e) {
      setTimeout(function(){
        location.reload();
      }, 100);
    });
  });

 