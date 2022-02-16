clearUserMessages = true;


function getAllCountries() {
	// Get countriess from server
	$.get("/Country/GetCountries", null, function (data) {
		// Display the list of countries
		$("#CountryList").html(data);
	});

	// Only clear the UserMessages if not just set by another calling function
	if (clearUserMessages) {
		document.getElementById('userMessages').innerText = '';
	}
	clearUserMessages = true;
}


function getCountryById() {
	//Get specific country from server
	var countryIdElement = document.getElementById('countryIdInput');
	$.post("/Country/GetCountryById", { countryId: countryIdElement.value }, function (data) {
		$("#CountryList").html(data);
	});

	// Clear ID-box value and messages to the user
	countryIdElement.value = '';
	document.getElementById('userMessages').innerText = '';
}

function removeCountryById() {
	// Remove a country from the list of countries
	// Used by forms et.c.
	var countryIdElement = document.getElementById('countryIdInput');
	var countryIdInput = countryIdElement.value;

	// Clear the ID-box
	countryIdElement.value = '';

	// Call general remove function
	removeCountryByIdArg(countryIdInput);
}

function removeCountryByIdArg(countryIdInput) {
	// Remove the country with the supplied ID
	$.post("/Country/RemoveCountryById", { countryId: countryIdInput }, function (data) {
		$("#CountryList").html(data);
	})

		// It worked, tell the user
		.done(function () {
			document.getElementById('userMessages').innerText = "Country is removed from the list!";

			// Don't clear the userMessages, just set above, 
			// when calling getAllCountries()
			clearUserMessages = false;
		})

		// I did not work, tell the user.
		.fail(function () {
			document.getElementById('userMessages').innerText = "Country could not be found and/or removed!";

			// Don't clear the userMessages, just set above,
			// when calling getAllCountries()
			clearUserMessages = false;
		});


	// Update the list with countries
	getAllCountries();

}