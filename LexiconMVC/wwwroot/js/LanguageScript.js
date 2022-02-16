clearUserMessages = true;


function getAllLanguages() {
	// Get languagess from server
	$.get("/Language/GetLanguages", null, function (data) {
		// Display the list of languages
		$("#LanguageList").html(data);
	});

	// Only clear the UserMessages if not just set by another calling function
	if (clearUserMessages) {
		document.getElementById('userMessages').innerText = '';
	}
	clearUserMessages = true;
}


function getLanguageById() {
	//Get specific language from server
	var languageIdElement = document.getElementById('languageIdInput');
	$.post("/Language/GetLanguageById", { languageId: languageIdElement.value }, function (data) {
		$("#LanguageList").html(data);
	});

	// Clear ID-box value and messages to the user
	languageIdElement.value = '';
	document.getElementById('userMessages').innerText = '';
}

function removeLanguageById() {
	// Remove a language from the list of languages
	// Used by forms et.c.
	var languageIdElement = document.getElementById('languageIdInput');
	var languageIdInput = languageIdElement.value;

	// Clear the ID-box
	languageIdElement.value = '';

	// Call general remove function
	removeLanguageByIdArg(languageIdInput);
}

function removeLanguageByIdArg(languageIdInput) {
	// Remove the language with the supplied ID
	$.post("/Language/RemoveLanguageById", { languageId: languageIdInput }, function (data) {
		$("#LanguageList").html(data);
	})

		// It worked, tell the user
		.done(function () {
			document.getElementById('userMessages').innerText = "Language is removed from the list!";

			// Don't clear the userMessages, just set above, 
			// when calling getAllLanguages()
			clearUserMessages = false;
		})

		// I did not work, tell the user.
		.fail(function () {
			document.getElementById('userMessages').innerText = "Language could not be found and/or removed!";

			// Don't clear the userMessages, just set above,
			// when calling getAllLanguages()
			clearUserMessages = false;
		});


	// Update the list with languages
	getAllLanguages();

}