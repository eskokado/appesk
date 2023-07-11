$(document).ready(function(){
  $("#btnDelete").on("click", function(){
      let CustomerId = $("#CustomerIdDelete").val();
      let UrlHandler="/Customer/Delete/"+CustomerId;
      $.ajax({
          url: UrlHandler, 
          type: 'POST',
          success: function() {
              window.location.href = '/Customer';
          }
      });
  });
});

var selectAllCheckbox = document.getElementById("selectAll");
var selectRowCheckboxes = document.getElementsByClassName("selectRow");

selectAllCheckbox.addEventListener("change", function () {
  var isChecked = selectAllCheckbox.checked;

  for (var i = 0; i < selectRowCheckboxes.length; i++) {
      selectRowCheckboxes[i].checked = isChecked;
  }
});

function expandFilterForm() {
  const filterFormDiv = document.getElementById("filterFormDiv");
  filterFormDiv.classList.add("show");
}

function hiddenFilterForm() {
  const filterFormDiv = document.getElementById("filterFormDiv");
  filterFormDiv.classList.remove("show");
}

function clearFilters() {
  $('#name').val('');
  $('#email').val('')
  $('#phone').val('')
  $('#registrationDate').val('')
  $('#isBlocked').val('')
  $.ajax({
      url: '/Customer/ClearFilters', 
      type: 'POST',
      success: function() {   
          location.href = '/Customer';
      },
      error: function (error) {
      }                
  });
}

function DisplayConfirmDeleteModal(CustomerId) {
  $("#CustomerIdDelete").val(CustomerId);
  $("#deleteModal").modal('show');
}
window.DisplayConfirmDeleteModal = DisplayConfirmDeleteModal;
