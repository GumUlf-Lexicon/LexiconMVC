import React, { useState, useEffect } from 'react';
import PersonList from './PersonList';
import PersonInfo from './PersonInfo';
import PersonAdd from './PersonAdd';

function App(props) {

	const [personSubPage, setPersonSubPage] = useState();

	const showPersonInfo = (personId) => setPersonSubPage(<PersonInfo key={personId} personId={personId} />);
	const editPersonInfo = (personId) => setPersonSubPage(<PersonAdd key={personId} personId={personId} />);
	const showPersonList = () => setPersonSubPage(<PersonList showInfo={showPersonInfo} editInfo={editPersonInfo} />);

	useEffect(() => { showPersonList() }, []);

	return (
		<React.Fragment>
			<h1 className="text-center">Person Index</h1>
			{personSubPage}
			<div className="d-grid">
				<input type="button" className="btn btn-info" onClick={(e) => { e.preventDefault(); editPersonInfo(13) }} value="??????" />
			</div>
		</React.Fragment>
	)
}

export default App;