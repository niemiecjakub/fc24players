import {ClubLogo} from "../../components/ClubLogo";

export const clubColumns = [
    {
        id: 'Name',
        name: 'CLUB',
        selector: row => row.name,
        sortable: true,
        // cell: row => <div className="font-bold text-white">{row.player.name}</div>
    },
    {
        id: 'Club',
        name: 'LOGO',
        selector: row => row.name,
        sortable: true,
        cell: row => <ClubLogo name={row.name} />,
    },
];

