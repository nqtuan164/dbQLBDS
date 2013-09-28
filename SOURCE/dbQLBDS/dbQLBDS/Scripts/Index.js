///<reference path="jquery-1.10.2.js" />



$("document").ready(function () {
    
    $(".btnDangNhap").hover(function () {
        
        $(".login-container").fadeIn("fast");

        $(this).mouseleave(function () {
            $(".login-container").fadeOut("fast");
        });
        return false;
    });


    
});


