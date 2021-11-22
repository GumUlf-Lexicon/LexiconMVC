function getAllPersons() {
	$.get("/People/AjaxGetPersons", null, function (data) {
		$("#PersonList").html(data);
	});
}