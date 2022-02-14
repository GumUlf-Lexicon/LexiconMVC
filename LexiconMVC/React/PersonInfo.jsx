import React, { useState, useEffect } from 'react';
import axios from 'axios';

function PersonInfo(props) {

	const [isNoPersonFound, setIsNoPersonFound] = useState(false);
	const [personInfo, setPersonInfo] = useState(false);

	useEffect(() => {
		let mounted = true;

		const getPersonInfo = async () => {
			axios.defaults.headers.post['Content-Type'] = 'application/json';
			axios.defaults.baseURL = `${location.origin}/`;
			try {
				const person = await axios.post('Person/PostGetPersonById', props.personId);
				if (mounted) {
					setPersonInfo(person.data);
					console.log(person.data);
				}
			} catch (error) {
				if (error.response.status == 404) {
					setIsNoPersonFound(true);
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


	if (isNoPersonFound) {
		return (
			<div>
				Person not found!
			</div>
		);

	} else if (personInfo) {
		return (
			<div>
				Name: {personInfo.name} <br />
				Phone number: {personInfo.phoneNumber}<br />
				Location: {personInfo.cityName}, {personInfo.countryName} <br />
				Languages:
				{
					personInfo.languages.map((lang, index) => {
						return <span key={index}> {(index ? ', ' : '') + lang.name}</span>
					})
				} <br />

			</div>);

	} else {

		return (
			<div className="text-center">
				<div className="spinner-border"></div>
			</div>
		)
	}
}

export default PersonInfo;