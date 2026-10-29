$(() => {
    $("input").on("input", function () {
        ensureFormValidity();
    })

    $("#car-type").on('change', function () {
        ensureFormValidity();

        const selectedCarType = $("#car-type").val();
        if (selectedCarType === "-1") {
            return;
        }

        if (selectedCarType === "2") {
            $("#has-leather-seats").prop("checked", true);
            $("#has-leather-seats").prop("disabled", true);
            $("form").append("<input type='hidden' id='chk-hidden' value='true' name='hasleatherseats' />");
        }
        else {
            $("#has-leather-seats").prop("disabled", false);
            $("#chk-hidden").remove();
        }
    });
})

function ensureFormValidity() {
    const make = $("#make").val().trim();
    const model = $("#model").val().trim();
    const yearValue = $("#year").val().trim();
    const priceValue = $("#price").val().trim();
    const carType = $("#car-type").val();

    // const validStrings = make.length > 0 && model.length > 0 && carType !== "-1" && yearValue.length > 0 && priceValue.length > 0;
    // const validYear = yearValue !== "" && Number.isInteger(parseInt(yearValue));
    // const validPrice = priceValue !== "" && !isNaN(priceValue) && parseFloat(priceValue) > 0;
    // const isFormValid = validStrings && validYear && validPrice;

    const isFormValid = make.length > 0 && model.length > 0 && carType !== "-1" && yearValue.length > 3 && yearValue.length < 5 && priceValue.length > 0;

    $("#add-car-button").prop("disabled", !isFormValid);
}