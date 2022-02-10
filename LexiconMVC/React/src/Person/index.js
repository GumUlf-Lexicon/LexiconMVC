import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';


const personData = {
	personList: [
		{ id: 1, name: "Anna Andersson", cityName: "Annasberg", countryName: "Annaland" },
		{ id: 2, name: "Berra Basun", cityName: "Bobby", countryName: "Bongoland" },
		{ id: 3, name: "Conny Curry", cityName: "Cincin", countryName: "Cladinry" },
	]
}

ReactDOM.render(
	<div className="row">
		<App personData={personData} />
	</div>,
	document.getElementById('content')
);