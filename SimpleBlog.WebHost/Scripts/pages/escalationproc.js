var impactLevels = new Array();
impactLevels[0] = "Low impact, this issue should be addressed within 24 hours but is low cause for concern."
impactLevels[1] = "Medium impact, this issue should be addressed when possible."
impactLevels[2] = "Medium-High impact, this issue should be addressed quickly."
impactLevels[3] = "High impact, this issue should be addressed immediately."
impactLevels[4] = "Critial impact, this issue should be addressed immediately and 90k should be issued."

$("#impactSlider").slider({
    range: "min",
    value: 2,
    min: 1,
    max: 5,
    step: 1,
    slide: function (event, ui) {
        $("#impactAmount").text(ui.value);
        $("#impactDetails").text(impactLevels[ui.value - 1]);
        $("#Impact").text(ui.value);
    }
});

$("#Impact").text($("#impactSlider").slider("value"));
$("#impactAmount").text($("#impactSlider").slider("value"));
$("#impactDetails").text(impactLevels[$("#impactSlider").slider("value") - 1]);