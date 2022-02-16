import React, { useState, useEffect } from 'react';
import PersonList from './PersonList';
import PersonInfo from './PersonInfo';
import PersonAdd from './PersonAdd';

function App(props) {

	const [personSubPage, setPersonSubPage] = useState();

	const showPersonInfo = (personId) =>
		setPersonSubPage(<PersonInfo personId={personId} showPersonList={showPersonList} handleDeleteClick={handleDeleteClick} />);

	const addPerson = () =>
		setPersonSubPage(<PersonAdd showPersonList={showPersonList} />);

	const showPersonList = () =>
		setPersonSubPage(<PersonList showPersonInfo={showPersonInfo} addPerson={addPerson} handleDeleteClick={handleDeleteClick} />);

	const handleDeleteClick = async (event, personId) => {
		event.preventDefault();
		axios.defaults.headers.post['Content-Type'] = 'application/json';
		axios.defaults.baseURL = `${location.origin}/`;
		try {
			await axios.post('Person/RemovePersonById', personId);
			showPersonList();
		}
		catch (error) {
			console.error("Error deleting user!", error)
		}
	}

	useEffect(() => { showPersonList() }, []);

	return (
		<div className="row">
			<div className="col-xl-2 col-lg-1"></div>
			<div className="col-xl-8 col-lg-10">
				<h1 className="text-center">Person Index</h1>
				{personSubPage}
			</div>
			<div className="col-xl-2 col-lg-1"></div>
		</div>
	);
}

export default App;