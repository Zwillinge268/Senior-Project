/*下拉漸入*/
function fadeInElements(className) {
    const elements = document.querySelectorAll(className);
    const windowHeight = window.innerHeight;

    function checkPosition() {
        for (let i = 0; i < elements.length; i++) {
            const position = elements[i].getBoundingClientRect().top;

            if (position < windowHeight - 135) {
                elements[i].style.opacity = 1;
                elements[i].style.transform = 'translateY(0)';
            }
        }
    }

    window.addEventListener('scroll', checkPosition);
    checkPosition();
}
fadeInElements('.fade-in');

/*Video1 Ajax*/
$(function () {
    $('button[id^="catchUrl"]').click(function () {
        let btnId = $(this).attr('id');
        let selectID = $('#' + btnId).val();
        $.ajax({
            url: "/IMVR/GetUrl",
            type: "POST",
            data: { select: selectID },
            success: function (Url) {
                $("#youtube").html(Url);
            }
        });
        $('html, body').animate({
            scrollTop: $('body').height() - $(window).height()
        }, 500);
    });
});

/*Video2 Ajax*/
$(function () {
    $("#list3").change(function () {
        let selectID = $(this).val();
        $.ajax({
            url: "/IMVR/GetUrl",
            type: "POST",
            data: { select: selectID },
            success: function (Url) {
                $("#youtube").html(Url);
            }
        });
    });
});

/*Selection Request*/
$('#s1').on('click', selection);
$('#s2').on('change', selection);

function selection() {
    let e = $(this).attr('id');
    if (e == "s1") {
        let id = $('#list').val();
        window.location.assign("../IMVR/Video1?ID=" + id);
    }
    else if (e == "s2") {
        let id = $(this).val();
        window.location.assign("../IMVR/Video2?ID=" + id);
    }
}

//// 選取所有有子選單的下拉式選單
//$('.dropdown-submenu').hover(function () {
//    $(this).find('.dropdown-menu').addClass('show');
//}, function () {
//    $(this).find('.dropdown-menu').removeClass('show');
//});

//// 點擊頁面其他地方時隱藏子選單
//$('body').on('click', function (e) {
//    $('.dropdown-menu').removeClass('show');
//});