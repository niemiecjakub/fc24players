import ReactCountryFlag from "react-country-flag";

export const playerColumns = [
    {
        id: 'Name',
        name: 'PLAYER',
        selector: row => row.name,
        sortable: true,
    },
    {
        id: 'Nationality',
        name: 'NATIONALITY',
        selector: row => row.nationality,
        sortable: true,
        center: true,
        cell: row => <ReactCountryFlag countryCode={row.nationalityCode} svg
                                       style={{
                                           width: '3em',
                                           height: '3em',
                                       }}
        />
    },
];