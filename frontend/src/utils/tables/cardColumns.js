export const cardColumns = [
    {
        id: 'Id',
        name: 'Id',
        selector: row => row.id,
        sortable: true,
    },
    {
        id: 'Name',
        name: 'Name',
        selector: row => row.player.name,
        sortable: true,
    },
    {
        id: 'Nationality',
        name: 'Nationality',
        selector: row => row.player.nationality,
        sortable: true,
    },
    {
        id: 'Club',
        name: 'Club',
        selector: row => row.club,
        sortable: true,
    },
    {
        id: 'Position',
        name: 'Position',
        selector: row => row.position,
        sortable: true,
    },
    {
        id: 'Overall',
        name: 'Overall',
        selector: row => row.overallRating,
        sortable: true,
    },
    {
        id: 'PAC',
        name: 'PAC',
        selector: row => row.pac,
        sortable: true,
    },
    {
        id: 'SHO',
        name: 'SHO',
        selector: row => row.sho,
        sortable: true,
    },
    {
        id: 'PAS',
        name: 'PAS',
        selector: row => row.pas,
        sortable: true,
    },
    {
        id: 'DRI',
        name: 'DRI',
        selector: row => row.dri,
        sortable: true,
    },
    {
        id: 'DEF',
        name: 'DEF',
        selector: row => row.def,
        sortable: true,
    },
    {
        id: 'PHY',
        name: 'PHY',
        selector: row => row.phy,
        sortable: true,
    },
];