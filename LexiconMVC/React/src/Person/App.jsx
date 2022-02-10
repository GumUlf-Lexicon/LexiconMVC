import React from 'react';
import PersonList from './PersonList';

function App(props) {
	return (
		<div>
			<h1 className="text-center">Person Index</h1>
			<div id="persons">
				<PersonList personData={props.personData} />
			</div>
		</div>
	)
}

export default App;