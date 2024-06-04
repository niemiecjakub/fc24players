import {HeadlineStatBadge} from "../../components/Card/HeadlineStatBadge";
import {PositionBadge} from "../../components/Card/PositionBadge";
import {OverallBadge} from "../../components/Card/OverallBadge";
import ReactCountryFlag from "react-country-flag";

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
        center: true,
        cell: row => <ReactCountryFlag countryCode={row.player.nationalityCode} svg
            style={{
                width: '3em',
                height: '3em',
            }}
        />
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
        center: true,
        cell: row => <PositionBadge position={row.position}/>
    },
    {
        id: 'Overall',
        name: 'OVERALL',
        selector: row => row.overallRating,
        sortable: true,
        center: true,
        cell: row => <OverallBadge value={row.overallRating}/>,
    },
    {
        id: 'PAC',
        name: 'PAC',
        selector: row => row.pac,
        sortable: true,
        center: true,
        cell: row => <HeadlineStatBadge value={row.pac}/>,
    },
    {
        id: 'SHO',
        name: 'SHO',
        selector: row => row.sho,
        sortable: true,
        center: true,
        cell: row => <HeadlineStatBadge value={row.sho}/>,
    },
    {
        id: 'PAS',
        name: 'PAS',
        selector: row => row.pas,
        sortable: true,
        center: true,
        cell: row => <HeadlineStatBadge value={row.pas}/>,
    },
    {
        id: 'DRI',
        name: 'DRI',
        selector: row => row.dri,
        sortable: true,
        center: true,
        cell: row => <HeadlineStatBadge value={row.dri}/>
    },
    {
        id: 'DEF',
        name: 'DEF',
        selector: row => row.def,
        sortable: true,
        center: true,
        cell: row => <HeadlineStatBadge value={row.def}/>
    },
    {
        id: 'PHY',
        name: 'PHY',
        selector: row => row.phy,
        sortable: true,
        center: true,
        cell: row => <HeadlineStatBadge value={row.phy}/>
    },
];

export const cardTableStyles = {
    table:{
        style:{
            color: "#FFFFFF",
            overflowX: 'hidden',
            overflowY: 'hidden'
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
    },
    pagination:{
        style:{
            backgroundColor: "#000000",
            color: "#6f6f6a"
        },
        pageButtonsStyle: {
            fill: "#10f469",
        },
    }
};

