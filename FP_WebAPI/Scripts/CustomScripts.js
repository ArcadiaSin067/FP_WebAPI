$(function () {
    //My favicon
    $("link[type='image/png']").attr("href", "/favicon.ico");

    //Title
    $("title").text("Biggy_Bank API");

    //no top text box
    $("input[name='baseUrl'], input[name='apiKey']").css("display", "none");

    //top application text
    $("#logo").html("&nbsp; &nbsp; &nbsp;Biggy_Bank");
    $('#logo').attr("href", "/Home/Index")

    //top button text
    $("#explore").text("Reload");
    //$('#explore').on("click", function (e) {
    //    e.preventDefault;
    //    $.post('~/Home/Index.cshtml');
    //});

    //custom api name
    $(this.getElementsByClassName("info_title")).text("DH_FPWebAPI");

    //awesome window effect
    $(this.getElementById("swagger-ui-container")).addClass("windowShade");

    //all dropdowns
    $(this.getElementsByName("accountType")).addClass("enumBox");
    $(this.getElementsByName("transactionType")).addClass("enumBox");
    $(this.getElementsByName("responseContentType")).addClass("contentType");
});
