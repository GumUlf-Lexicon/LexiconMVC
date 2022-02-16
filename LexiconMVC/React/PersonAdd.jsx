import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BottomButton from './BottomButton';

function PersonAdd(props) {

	axios.defaults.headers.post['Content-Type'] = 'application/json';
	axios.defaults.baseURL = `${location.origin}/`;

	// Keep track of if we still are mounted or not, needed for
	// checking to not set state after async axios call if unmounted.
	let mounted = true;
	useEffect(() => {
		mounted = true;
		return (() => mounted = false);
	}, [])

	const [noInfoReturned, setNoInfoReturned] = useState(false);
	const [personInfo, setPersonInfo] = useState(false);
	const [formValues, setFormValues] = useState({
		personName: "",
		phoneNumber: "",
		cityId: -1,
		languageIds: [],
	});
	const [validationStatus, setValidationStatus] = useState({
		personName: "",
		phoneNumber: "",
		cityId: "",
		languageIds: "",
		validating: false,
	});
	const [isValidating, setIsValidating] = useState(false);
	const [isNewPersonAdded, setIsNewPersonAdded] = useState(false);

	// Get available languages and locations on mount
	useEffect(() => {
		const getPersonInfo = async () => {
			try {
				const person = await axios.get('Person/AddPerson');

				if (mounted) {
					setPersonInfo(person.data);
				}
			} catch (error) {
				if (error.response.status == 404) {
					setNoInfoReturned(true);
					return;
				}
				else {
					console.error(error);
				}
			}
		}
		getPersonInfo();
	}, [])


	const handleSubmit = async (event) => {

		event.preventDefault();

		// Activate the validation messages in case there are invalid values
		setIsValidating(true);

		const currentValues = formValues;
		const allValuesValid = validateInputs(currentValues);

		if (!allValuesValid) {
			// Do not allow submit of new person
			return;
		}

		// Values are OK, let's add the new person

		const newPerson = {
			name: formValues.personName,
			phoneNumber: formValues.phoneNumber,
			cityId: parseInt(formValues.cityId),
			languageIds: formValues.languageIds.map(id => {
				if (id == "") return;
				return parseInt(id);
			}),
		}

		try {
			await axios.post('Person/AddPerson', newPerson);

			if (mounted) {
				// Everything went well. Do cleanup
				setFormValues({
					"personName": "",
					"phoneNumber": "",
					"cityId": -1,
					"languageIds": [],
				});

				setValidationStatus({
					"personName": "",
					"phoneNumber": "",
					"cityId": "",
					"languageIds": "",
				});

				setIsValidating(false);

				setIsNewPersonAdded(true);
			}

		} catch (error) {
			console.error("Adding person error", error);
		}
	}

	// Handle values for active control of form
	const handleChange = (event) => {

		const target = event.target;
		const value = target.value;
		const name = target.name;

		// Multiple select values are stored differently 
		if (target.type !== 'select-multiple') {
			setFormValues(values => ({ ...values, [name]: value }));
		}
		else {
			setFormValues(values => (
				{
					...values,
					[name]: Array.from(target.selectedOptions, (option) => option.value)
				}));
		}
	}

	// Do validation, if wanted
	useEffect(() => {

		if (isValidating) {
			validateInputs(formValues);
		}
		else {
			setValidationStatus({
				"personName": "",
				"phoneNumber": "",
				"cityId": "",
				"languageIds": "",
			});
		}

	}, [formValues, isValidating])

	// Check that all values in the form are valid
	const validateInputs = (valuesToValidate) => {


		const validateName = (personName) => {

			// At least 3 and at most 128 characters
			const pattern = /.{3,128}/;
			const isValid = pattern.test(personName);

			setValidationStatus(values => {
				return { ...values, personName: (isValid ? 'is-valid' : 'is-invalid') }
			});

			return isValid;
		};

		const validatePhoneNumber = (phoneNumber) => {
			// At least 3 and at most 32 digits and other characters valid in phone numbers
			const pattern = /^[0-9 \-\+\(\)]{3,32}$/;
			const isValid = pattern.test(phoneNumber);

			setValidationStatus(values => {
				return { ...values, phoneNumber: (isValid ? 'is-valid' : 'is-invalid') }
			});

			return isValid;
		};

		const validateCityId = (cityId) => {
			// Needs to be a number over 0. (More advanced would be to 
			// check against the values in the city list)
			const parsedCityId = parseInt(cityId);
			const isValid = (!isNaN(parsedCityId) && parsedCityId > 0);

			setValidationStatus(values => {
				return { ...values, cityId: (isValid ? 'is-valid' : 'is-invalid') };
			});

			return isValid;
		};

		const validateLanguageIds = (languageIds) => {

			let isValid = true;

			// An empty array is a valid state.

			if (languageIds.lenght >= 0) {
				languageIds.map((langId) => {
					const parsedLangId = parseInt(langId);
					if (isNaN(parsedLangId) || parsedLangId <= 0) {
						isValid = false;
					}
				});
			}

			setValidationStatus(values => {
				return { ...values, languageIds: (isValid ? 'is-valid' : 'is-invalid') }
			});

			return isValid;
		};

		let allValid = true;
		allValid &= validateName(valuesToValidate.personName);
		allValid &= validatePhoneNumber(valuesToValidate.phoneNumber);
		allValid &= validateCityId(valuesToValidate.cityId);
		allValid &= validateLanguageIds(valuesToValidate.languageIds);

		return allValid;
	}



	/*     RENDERING BELOW    */
	if (isNewPersonAdded) {
		return (
			<div className="text-center container-lg mt-3">
				<h2>Add person</h2>
				<h3>New person is added!</h3>
				<BottomButton handleOnClick={() => setIsNewPersonAdded(false)} textValue="Add another person" />
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		);
	}

	if (noInfoReturned) {
		return (
			<div className="text-center container-lg mt-3">
				<h2>Add person</h2>
				<h3>Could not get location and language info!</h3>
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		);

	} else if (personInfo) {
		return (
			<div className="container-lg mt-3">

				<h2 className="text-center">Add person</h2>

				<form onSubmit={handleSubmit} className="my-3" noValidate>
					<input name="personId" value={personInfo.personId} hidden readOnly />

					<div className="form-group mb-3 mt-3">
						<label htmlFor="personName" className="form-label">Name: </label>
						<input name="personName" type="text"
							className={`form-control ${validationStatus.personName}`}
							value={formValues.personName}
							onChange={handleChange} required />
						<div className="valid-feedback">OK!</div>
						<div className="invalid-feedback">You need to enter a valid name</div>
					</div>

					<div className="form-group mb-3">
						<label htmlFor="phoneNumber" className="form-label">Phone number: </label>
						<input name="phoneNumber" type="tel"
							className={`form-control ${validationStatus.phoneNumber}`}
							value={formValues.phoneNumber} onChange={handleChange} />
						<div className="valid-feedback">OK!</div>
						<div className="invalid-feedback">You need to enter a valid phone number</div>
					</div>

					<div className="form-group mb-3">
						<label htmlFor="cityId" className="form-label">City: </label>
						<select name="cityId" size="1"
							className={`form-select ${validationStatus.cityId}`}
							value={formValues.cityId} onChange={handleChange}>
							<option value="-1" key="-1" disabled hidden>Select city</option>
							{personInfo.cities.map((city) => {
								return <option value={city.cityId} key={city.cityId}>{city.name}, {city.countryName}</option>
							})};
						</select>
						<div className="valid-feedback">OK!</div>
						<div className="invalid-feedback">You need to select a city</div>
					</div>

					<div className="form-group mb-3">
						<label htmlFor="languageIds" className="form-label">Languages: </label>
						<select name="languageIds" size="5" multiple={true}
							className={`form-select ${validationStatus.languageIds}`}
							value={formValues.languageIds} onChange={handleChange}>
							{personInfo.languages.map((language) => {
								return <option value={language.languageId} key={language.languageId}>{language.name}</option>
							})};
						</select>
						<div className="valid-feedback">OK!</div>
						<div className="invalid-feedback">You need make a valid language selection!</div>
					</div>

					<div className="d-grid">
						<button type="submit" className="btn btn-success">Create Person</button>
					</div>

				</form>
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		);

	} else {

		return (
			<div className="text-center container-lg mt-3">
				<div className="spinner-border"></div>
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		)
	}
}

export default PersonAdd;