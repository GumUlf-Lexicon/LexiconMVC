import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BottomButton from './BottomButton';

function PersonAdd(props) {

	const [noInfoReturned, setNoInfoReturned] = useState(false);
	const [personInfo, setPersonInfo] = useState(false);
	const [formValues, setFormValues] = useState({
		"personName": "",
		"phoneNumber": "",
		"cityId": 0,
		"languageIds": [],
	});

	// Get available languages and locations on mount
	useEffect(() => {
		let mounted = true;

		const getPersonInfo = async () => {
			axios.defaults.headers.post['Content-Type'] = 'application/json';
			axios.defaults.baseURL = `${location.origin}/`;
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

		return () => { mounted = false; };

	}, [])


	const handleSubmit = (event) => {
		console.log(event);
		event.preventDefault();

	}

	const handleChange = (event) => {
		const target = event.target;
		const value = target.type === 'checkbox' ? target.checked : target.value;
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


	if (noInfoReturned) {
		return (
			<div>
				Could not get location and language info!
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		);

	} else if (personInfo) {
		return (
			<div className="container-lg mt-3">

				<h2 className="text-center">Add person</h2>

				<form onSubmit={handleSubmit} className="my-3">
					<input name="personId" value={personInfo.personId} hidden readOnly />

					<div className="mb-3 mt-3">
						<label htmlFor="personName" className="form-label">Name: </label>
						<input name="personName" type="text" className="form-control" value={formValues.personName} onChange={handleChange} />
					</div>

					<div className="mb-3">
						<label htmlFor="phoneNumber" className="form-label">Phone number: </label>
						<input name="phoneNumber" type="tel" className="form-control" value={formValues.phoneNumber} onChange={handleChange} />
					</div>

					<div className="mb-3">
						<label htmlFor="cityId" className="form-label">City: </label>
						<select name="cityId" className="form-select" size="1" value={formValues.cityId} onChange={handleChange}>
							{personInfo.cities.map((city) => {
								return <option value={city.cityId} key={city.cityId}>{city.name}, {city.countryName}</option>
							})};
						</select>
					</div>

					<div className="mb-3">
						<label htmlFor="languageIds" className="form-label">Languages: </label>
						<select name="languageIds" className="form-select" size="5" multiple={true} value={formValues.languageIds} onChange={handleChange}>
							{personInfo.languages.map((language) => {
								return <option value={language.languageId} key={language.languageId}>{language.name}</option>
							})};
						</select>
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
			<div className="text-center">
				<div className="spinner-border"></div>
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		)
	}
}

export default PersonAdd;