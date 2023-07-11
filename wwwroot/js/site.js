function validateField(form, fieldSelector, urlHandler, messageError) {
  var field = form.find(fieldSelector);
  var data = field.val();
  var id = form.find("#Id").val();

  if (data == "") return false;
  
  var isValid = false;

  var ajaxRequest = $.ajax({
      url: urlHandler,
      type: 'POST',
      async: false,
      data: { data: data, id: id }
  });

  ajaxRequest.done(function(response) {
      isValid = true;
  });

  ajaxRequest.fail(function(error) {
      sendMessage(messageError);
  });

  return isValid;
}

function sendMessage(message, type) {
  Toastify({
      text: message,
      duration: 3000,
      gravity: "top",
      position: "top",
      close: true,
      backgroundColor: type ? type : "#ff8800",
      stopOnFocus: true,
      offset: {
          y: 100,
          x: 20,
      }
  }).showToast();
}

function back() {
  console.log("back");
  window.location.href = '/Customer/Index';
}

function removeMask(value) {
  return value.replace(/[^\d]+/g, '');
}
