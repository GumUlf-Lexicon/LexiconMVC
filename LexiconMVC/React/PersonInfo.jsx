import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BottomButton from './BottomButton';

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




	/*      RENDERING BELOW      */

	if (isNoPersonFound) {
		return (
			<div>
				Person not found!
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>
		);

	} else if (personInfo) {
		return (
			<React.Fragment>
				<div className="text-center row justify-content-center">
					<div className="card border border-5 border-light bg-gradient rounded-3 bg-secondary w-50 ">
							<h3 className="card-header bg-dark bg-gradient shadow-lg">{personInfo.name}</h3>
						<div className="card-body">
							<dl>
								<dt>Phone number:</dt>
								<dd>{personInfo.phoneNumber}</dd>
								<dt> Location:</dt>
								<dd>{personInfo.cityName}, {personInfo.countryName} </dd>
								<dt>Languages:</dt>
								<dd>	{
									personInfo.languages.map((lang, index) => {
										return <span key={index}> {(index ? ', ' : '') + lang.name}</span>
									})
								} </dd>
							</dl>

						</div>
						<div className="card-footer">
							<input type="button" className="btn btn-danger fw-bold"
								onClick={(event) => { props.handleDeleteClick(event, personInfo.personId) }} value="Delete" />
						</div>
					</div>
				</div>
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</React.Fragment>);

	} else {

		return (
			<div className="text-center">
				<div className="spinner-border"></div>
				<BottomButton handleOnClick={props.showPersonList} textValue="Show person list" />
			</div>

		)
	}
}

export default PersonInfo;