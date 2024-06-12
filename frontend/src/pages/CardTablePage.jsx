import {useEffect, useState} from "react";
import DataTable from "react-data-table-component";
import {Loader} from "../components/Loader/Loader";
import {cardColumns} from "../utils/tables/cardColumns";
import {ExpandedCard} from "../components/ExpandedCard";
import {baseUrl} from "../services/api";
import {tableStyles} from "../utils/tables/tableStyles";
import {Filter} from "../components/Filter";

export const CardTablePage = () => {
    const [cards, setCards] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [nameFilterText, setNameFilterText] = useState('');
    const [nationalityFilterText, setNationalityFilterText] = useState('');
    const [resetPaginationToggle, setResetPaginationToggle] = useState(true);
    
    useEffect(() => {
        const getCards = async () => {
            setIsLoading(true)
            const response = await fetch(`${baseUrl}/Card/all`)
            if (response.ok) {
                const cards = await response.json()
                setCards(cards)
            }
            setIsLoading(false)
        }

        getCards()
    }, []);

    const filteredCards = cards.filter(item => {
        if (nameFilterText !== '' && nationalityFilterText !== '') {
            return (
                item.player.name.toLowerCase().includes(nameFilterText.toLowerCase()) &&
                item.player.nationality.toLowerCase().includes(nationalityFilterText.toLowerCase())
            );
        } else if (nameFilterText !== '') {
            return item.player.name && item.player.name.toLowerCase().includes(nameFilterText.toLowerCase());
        } else if (nationalityFilterText !== '') {
            return item.player.nationality && item.player.nationality.toLowerCase().includes(nationalityFilterText.toLowerCase());
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
                <span className="text-5xl font-bold bg-fc24-accent">FC 24 CARDS</span>
            </div>
            <div className="flex">
                <Filter onFilter={e => setNameFilterText(e.target.value)} onClear={handleNameClear}
                        filterText={nameFilterText} placeholder="Filter by name" className="mr-4"/>
                <Filter onFilter={e => setNationalityFilterText(e.target.value)} onClear={handleNationalityClear}
                        filterText={nationalityFilterText} placeholder="Filter by nationality"/>
            </div>
            <DataTable
                columns={cardColumns}
                data={filteredCards}
                fixedHeader
                pagination
                progressPending={isLoading}
                progressComponent={<Loader/>}
                customStyles={tableStyles}
                expandableRows
                expandableRowsComponent={ExpandedCard}
                highlightOnHover
                persistTableHead={true}
            />
        </div>
    )
}