clearUserMessages = true;


function getAllCities() {
	// Get citiess from server
	$.get("/City/GetCities", null, function (data) {
		// Display the list of cities
		$("#CityList").html(data);
	});

	// Only clear the UserMessages if not just set by another calling function
	if (clearUserMessages) {
		document.getElementById('userMessages').innerText = '';
	}
	clearUserMessages = true;
}


function getCityById() {
	//Get specific city from server
	var cityIdElement = document.getElementById('cityIdInput');
	$.post("/City/GetCityById", { cityId: cityIdElement.value }, function (data) {
		$("#CityList").html(data);
	});

	// Clear ID-box value and messages to the user
	cityIdElement.value = '';
	document.getElementById('userMessages').innerText = '';
}

function removeCityById() {
	// Remove a city from the list of cities
	// Used by forms et.c.
	var cityIdElement = document.getElementById('cityIdInput');
	var cityIdInput = cityIdElement.value;

	// Clear the ID-box
	cityIdElement.value = '';

	// Call general remove function
	removeCityByIdArg(cityIdInput);
}

function removeCityByIdArg(cityIdInput) {
	// Remove the city with the supplied ID
	$.post("/City/RemoveCityById", { cityId: cityIdInput }, function (data) {
		$("#CityList").html(data);
	})

		// It worked, tell the user
		.done(function () {
			document.getElementById('userMessages').innerText = "City is removed from the list!";

			// Don't clear the userMessages, just set above, 
			// when calling getAllCities()
			clearUserMessages = false;
		})

		// I did not work, tell the user.
		.fail(function () {
			document.getElementById('userMessages').innerText = "City could not be found and/or removed!";

			// Don't clear the userMessages, just set above,
			// when calling getAllCities()
			clearUserMessages = false;
		});


	// Update the list with cities
	getAllCities();

}