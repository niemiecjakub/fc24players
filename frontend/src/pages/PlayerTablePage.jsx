﻿import {useEffect, useMemo, useState} from "react";
import DataTable from 'react-data-table-component';
import {Filter} from "../components/Filter";
import {playerColumns} from "../utils/tables/playerColumns";
import {Loader} from "../components/Loader/Loader";
import {ExpandedPlayer} from "../components/ExpandedPlayer";
import {baseUrl} from "../services/api";
import {tableStyles} from "../utils/tables/tableStyles";

export const PlayerTablePage = () => {
    const [players, setPlayers] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [nameFilterText, setNameFilterText] = useState('');
    const [nationalityFilterText, setNationalityFilterText] = useState('');
    const [resetPaginationToggle, setResetPaginationToggle] = useState(true);

    useEffect(() => {
        const getPlayers = async () => {
            setIsLoading(true)
            const response = await fetch(`${baseUrl}/Player/all`)
            if (response.ok) {
                const players = await response.json()
                setPlayers(players)
            }
            setIsLoading(false)
        }

        getPlayers()
    }, []);

    const filteredPlayers = players.filter(item => {
        if (nameFilterText !== '' && nationalityFilterText !== '') {
            return (
                item.name.toLowerCase().includes(nameFilterText.toLowerCase()) &&
                item.nationality.toLowerCase().includes(nationalityFilterText.toLowerCase())
            );
        } else if (nameFilterText !== '') {
            return item.name && item.name.toLowerCase().includes(nameFilterText.toLowerCase());
        } else if (nationalityFilterText !== '') {
            return item.nationality && item.nationality.toLowerCase().includes(nationalityFilterText.toLowerCase());
        }
        return true; 
    });

    const handleNameClear = () => {
        if (nameFilterText) {
            setResetPaginationToggle(!resetPaginationToggle);
            setNameFilterText('');
        }
    };
    const handleNationalityClear = () => {
        if (nationalityFilterText) {
            setResetPaginationToggle(!resetPaginationToggle);
            setNationalityFilterText('');
        }
    };

    return (
        <div>
            <div className="m-5">
                <span className="text-5xl font-bold bg-fc24-accent">FC 24 PLAYERS</span>
            </div>
            <div className="flex">
                <Filter onFilter={e => setNameFilterText(e.target.value)} onClear={handleNameClear}
                        filterText={nameFilterText} placeholder="Filter by name" className="mr-4"/>
                <Filter onFilter={e => setNationalityFilterText(e.target.value)} onClear={handleNationalityClear}
                        filterText={nationalityFilterText} placeholder="Filter by nationality"/>
            </div>
            <DataTable
                columns={playerColumns}
                data={filteredPlayers}
                defaultSortFieldId={1}
                fixedHeader
                pagination
                paginationResetDefaultPage={resetPaginationToggle}
                expandableRows
                expandableRowsComponent={ExpandedPlayer}
                persistTableHead
                progressPending={isLoading}
                progressComponent={<Loader/>}
                customStyles={tableStyles}
            />
        </div>
    )
}
