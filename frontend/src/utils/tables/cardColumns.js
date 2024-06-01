import {HeadlineStatBadge} from "../../components/Card/HeadlineStatBadge";
import {PositionBadge} from "../../components/Card/PositionBadge";

export const cardColumns = [
    {
        id: 'Id',
        name: 'ID',
        selector: row => row.id,
        sortable: true,
    },
    {
        id: 'Name',
        name: 'PLAYER',
        selector: row => row.player.name,
        sortable: true,
        // cell: row => <div className="font-bold text-white">{row.player.name}</div>
    },
    {
        id: 'Nationality',
        name: 'NATIONALITY',
        selector: row => row.player.nationality,
        sortable: true,
    },
    {
        id: 'Club',
        name: 'CLUB',
        selector: row => row.club,
        sortable: true,
    },
    {
        id: 'Position',
        name: 'POSITION',
        selector: row => row.position,
        sortable: true,
        cell: row => <PositionBadge position={row.position}/>
    },
    {
        id: 'Overall',
        name: 'OVERALL',
        selector: row => row.overallRating,
        sortable: true,
    },
    {
        id: 'PAC',
        name: 'PAC',
        selector: row => row.pac,
        sortable: true,
        cell: row => <HeadlineStatBadge value={row.pac}/>
    },
    {
        id: 'SHO',
        name: 'SHO',
        selector: row => row.sho,
        sortable: true,
        cell: row => <HeadlineStatBadge value={row.sho}/>,
    },
    {
        id: 'PAS',
        name: 'PAS',
        selector: row => row.pas,
        sortable: true,
        cell: row => <HeadlineStatBadge value={row.pas}/>
    },
    {
        id: 'DRI',
        name: 'DRI',
        selector: row => row.dri,
        sortable: true,
        cell: row => <HeadlineStatBadge value={row.dri}/>
    },
    {
        id: 'DEF',
        name: 'DEF',
        selector: row => row.def,
        sortable: true,
        cell: row => <HeadlineStatBadge value={row.def}/>
    },
    {
        id: 'PHY',
        name: 'PHY',
        selector: row => row.phy,
        sortable: true,
        cell: row => <HeadlineStatBadge value={row.phy}/>
    },
];

export const cardTableStyles = {
    table:{
        style:{
            color: "#FFFFFF"
        }
    },
    headRow:{
        style:{
            backgroundColor: "#282928",
            color:"#10f469",
            width: '100%',
        }
    },
    rows:{
        style:{
            backgroundColor: "#000000",
            color:"#FFFFFF"
        },
        highlightOnHoverStyle:{
            backgroundColor: "#282928",
            color:"#FFFFFF"
        },
    },
    expanderRow:{
        style:{
            backgroundColor: "#000000",
        }
    },
    expanderButton:{
        style:{
            color:"#FFFFFF"
        }
    },
    progress:{
        style:{
            backgroundColor: "#000000",
        }
    }
};

