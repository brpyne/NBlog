var terms = ["90 Thousand:  1 Woodward 3rd Floor Network Bounce <span class='label label-inverse'>Informational <i class='icon-warning-sign'></i></span>",
    "90 Thousand:  Conversion Services <span class='label label-success'>Closure <i class='icon-ok'></i></span>",
    "90 Thousand:  In Process Call Router AKA QRouter <span class='label label-important'>Outage <i class='icon-flag'></i></span>"];

function rotateTerm() {
    
    var ct = $("#rotate").data("term") || 0;
    if (ct == 3) return;
    
    $("#rotate").data("term", ct == terms.length - 1 ? 0 : ct + 1).html(terms[ct])
      .fadeIn().delay(8000).fadeOut(500, rotateTerm);
    
}

$(function() {
    rotateTerm();
})