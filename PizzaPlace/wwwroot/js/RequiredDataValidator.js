function validateForm() {
    var requiredData = document.querySelectorAll('[required]');
    var result = true;
    for (var i = 0; i < requiredData.length; i++) {
        var elementValue = requiredData[i].value;
        var elementName = requiredData[i].getAttribute("name");
        if (elementValue == null || elementValue.trim().length == 0) {
            alert("Empty spaces are data. Fill all required fields with actual characters.");
            result = false;
            break;
        }
    }
    return result;
}