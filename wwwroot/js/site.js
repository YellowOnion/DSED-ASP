// Write your Javascript code.
$('body').on('click', '[data-edit]', function (){
    var dis = $(this);
    var theParent = $(this).parent().parent();
    var deleter = theParent.find('[data-delete]');
    var firstName = theParent.find('[data-firstname]');
    var lastName = theParent.find('[data-lastname]');
    var addressName = theParent.find('[data-address]');
    var phone = theParent.find('[data-phone]');

    switch (dis.text()) {
        case "edit":
        dis.text("check");
        deleter.prop("disabled", true);
        firstName.html("<input value=\"" +firstName.text()+ "\" class=\"mdl-textfield__input\" type=\"text\" for=\"Customer.FirstName\" id=\"firstName\"/><label class=\"mdl-textfield__label\" for=\"firstName\">First Name</label>");
            break;
                    
        case "check":
        dis.text("edit");
        firstName.contents().unwrap();
        deleter.prop("disabled", false);
            break;
    
        default:
            break;
    }

    console.log(deleter);
})