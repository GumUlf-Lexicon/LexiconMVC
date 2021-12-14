

function getAllPersons(clearUserMessages = true) {
	// Get persons from server
	$.get("/Person/GetPersons", null, function (data) {
		// Display the list of persons
		$("#PersonList").html(data);
	});

	// Clear ID-box value
	document.getElementById('personIdInput').value = '';

	// Clear the UserMessages if requested to
	if (clearUserMessages) {
		document.getElementById('userMessages').innerText = '';
	}
}


function addLanguageToPersonById() {
	// Request adding language to person
	var personId = document.getElementById('personIdInput').value;
	var languageId = document.getElementById('languageIdInput').value;
	$.post("/Person/AddLanguageToPerson", { personId: personId, languageId: languageId }, function (data) {
		$("#PersonList").html(data);
	});

	// Clearing ID-box value
	document.getElementById('personIdInput').value = '';
}


function getPersonById() {
	//Get specific person from server
	var personIdElement = document.getElementById('personIdInput');
	$.post("/Person/GetPersonById", { personId: personIdElement.value }, function (data) {
		$("#PersonList").html(data);
	});

	// Clear ID-box value and messages to the user
	personIdElement.value = '';
	document.getElementById('userMessages').innerText = '';

	
}

function editPersonById() {
	var personIdInput = document.getElementById('personIdInput').value;
	window.location.href = '/Person/EditPerson?personId=' + personIdInput;
}

function removePersonById() {
	// Remove a person from the list of people
	// Used by forms et.c.
	var personIdElement = document.getElementById('personIdInput');
	var personIdInput = personIdElement.value;

	// Clear the ID-box
	personIdElement.value = '';

	// Call general remove function
	removePersonByIdArg(personIdInput);
}

function removePersonByIdArg(personIdInput) {
	// Remove the person with the supplied ID
	$.post("/Person/RemovePersonById", { personId: personIdInput }, function (data) {
		$("#PersonList").html(data);
	})

		// It worked, tell the user
		.done(function () {
			document.getElementById('userMessages').innerText = "Person is removed from the list!";

			// Update the list with persons
			getAllPersons(false);
		})

		// I did not work, tell the user.
		.fail(function () {
			document.getElementById('userMessages').innerText = "Person could not be found and/or removed!";

			// Update the list with persons
			getAllPersons(false);	

		});
	


}