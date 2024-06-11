import {useEffect, useMemo, useState} from "react";
import {useLocation } from "react-router-dom";
import {baseUrl} from "../services/api";
import {Loader} from "../components/Loader/Loader";
import DataTable from "react-data-table-component";
import {tableStyles} from "../utils/tables/tableStyles";
import {clubColumns} from "../utils/tables/clubColumns";
import {Filter} from "../components/Filter";
import {playerColumns} from "../utils/tables/playerColumns";
import {ExpandedPlayer} from "../components/ExpandedPlayer";


export const ClubTablePage = () => {
    const [clubs, setClubs] = useState([])
    const [isLoading, setIsLoading] = useState(false)

    useEffect(() => {
        const getClubs = async () => {
            setIsLoading(true)
            const response = await fetch(`${baseUrl}/Club/all/`)
            if (response.ok) {
                const clubs = await response.json()
                setClubs(clubs)
            }
            console.log(clubs)
            setIsLoading(false)
        }

        getClubs()
    }, [useLocation().pathname])


    const [clubFilterText, setClubFilterText] = useState('');
    const [resetPaginationToggle, setResetPaginationToggle] = useState(true);


    const filteredClubs = clubs.filter(item => {
        if (clubFilterText !== '') {
            return item.name && item.name.toLowerCase().includes(clubFilterText.toLowerCase());
        }
        return true;
    });

    const subHeaderComponentMemo = useMemo(() => {
        const handleClubClear = () => {
            if (clubFilterText) {
                setResetPaginationToggle(!resetPaginationToggle);
                setClubFilterText('');
            }
        };

        return (
            <div className="flex">
                <Filter onFilter={e => setClubFilterText(e.target.value)} onClear={handleClubClear} filterText={clubFilterText} placeholder="Filter by name" className="mx-4"/>
            </div>
        );
    }, [clubFilterText, resetPaginationToggle]);
    
    return (
        <div>
            <div className="m-5">
                <span className="text-5xl font-bold bg-fc24-accent">FC 24 CLUBS</span>
            </div>
            <DataTable
                columns={clubColumns}
                data={filteredClubs}
                defaultSortFieldId={1}
                fixedHeader
                pagination
                paginationResetDefaultPage={resetPaginationToggle}
                subHeader
                subHeaderComponent={subHeaderComponentMemo}
                persistTableHead
                progressPending={isLoading}
                progressComponent={<Loader />}
                customStyles={tableStyles}
            />
        </div>
    )
}