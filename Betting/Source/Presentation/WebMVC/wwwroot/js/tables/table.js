function HightLightGrid(grdId) {
    var sId = "table#" + grdId + " tr";
    $(sId).css({ "border": "solid 1px #A6C9E2", "border-collapse": "collapse" });
    $(sId).has("td").mouseover(function () {
        $(sId).has("td").css({ "cursor": "pointer" });
    });
    $(sId).has("td").click(function () {
        $(sId).has("td").css({ "background": "#ffffff" });
        $(this).css({ "background": "#FBEC88" });
    });

}