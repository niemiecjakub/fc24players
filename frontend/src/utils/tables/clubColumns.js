import {ClubLogo} from "../../components/ClubLogo";

export const clubColumns = [
    {
        id: 'name',
        name: 'CLUB',
        selector: row => row.name,
        sortable: true,
        // cell: row => <div className="font-bold text-white">{row.player.name}</div>
    },
    {
        id: 'logo',
        name: 'LOGO',
        selector: row => row.name,
        sortable: true,
        cell: row => <ClubLogo name={row.name} />,
    },
    {
        id: 'manager',
        name: 'MANAGER',
        selector: row => row.manager,
    },
    {
        id: 'stadium',
        name: 'STADIUM',
        selector: row => row.stadium,
    },
    {
        id: 'location',
        name: 'LOCATION',
        selector: row => row.location,
    },
    {
        id: 'founded',
        name: 'FOUNDED',
        selector: row => row.yearFounded,
        sortable: true,
    },
];

