
function getAllPersons() {

	$.get("/PeopleAjax/GetPersons", null, function (data) {
		$("#PersonList").html(data);
	});

	document.getElementById('personIdInput').value = '';
	document.getElementById('userMessages').innerText = '';
}


function getPersonById() {
	var personIdElement = document.getElementById('personIdInput');
	$.post("/PeopleAjax/GetPersonById", { personId: personIdElement.value }, function (data) {
		$("#PersonList").html(data);
	});

	personIdElement.value = '';
	document.getElementById('userMessages').innerText = '';
}

function removePersonById() {
	var personIdElement = document.getElementById('personIdInput');
	personIdElement.value = '';
	removePersonById(personIdElement.value);


}

function removePersonById(personIdInput) {
	$.post("/PeopleAjax/RemovePersonById", { personId: personIdInput }, function (data) {
		$("#PersonList").html(data);
	})

		.done(function () {
			document.getElementById('userMessages').innerText = "Person is removed from the list!";
		})

		.fail(function () {
			document.getElementById('userMessages').innerText = "Person could not be found and/or removed!";
		});

	$.get("/PeopleAjax/GetPersons", null, function (data) {
		$("#PersonList").html(data);
	});

}