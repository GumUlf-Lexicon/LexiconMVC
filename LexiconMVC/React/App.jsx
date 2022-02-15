import React, { useState, useEffect } from 'react';
import PersonList from './PersonList';
import PersonInfo from './PersonInfo';
import PersonAdd from './PersonAdd';

function App(props) {

	const [personSubPage, setPersonSubPage] = useState();

	const showPersonInfo = (personId) => setPersonSubPage(<PersonInfo personId={personId} showPersonList={showPersonList} />);
	const addPerson = () => setPersonSubPage(<PersonAdd showPersonList={showPersonList} />);
	const showPersonList = () => setPersonSubPage(<PersonList showInfo={showPersonInfo} addPerson={addPerson} />);

	useEffect(() => { showPersonList() }, []);

	return (
		<div className="row">
			<div className="col-xl-2"></div>
			<div className="col-xl-8">
				<h1 className="text-center">Person Index</h1>
				{personSubPage}
			</div>
			<div className="col-xl-2"></div>
		</div>
	);
}

export default App;