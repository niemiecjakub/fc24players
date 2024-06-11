export const clubColumns = [
    {
        id: 'Name',
        name: 'PLAYER',
        selector: row => row.name,
        sortable: true,
        // cell: row => <div className="font-bold text-white">{row.player.name}</div>
    },
    {
        id: 'Club',
        name: 'CLUB',
        selector: row => row.name,
        sortable: true,
        cell: row => <img src={`/logos/${row.name}.svg`} className="h-16 w-16"/>,
    },
];

