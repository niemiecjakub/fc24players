import {useEffect, useState} from "react";
import DataTable from "react-data-table-component";
import {Loader} from "../components/Loader/Loader";
import {cardColumns} from "../utils/tables/cardColumns";
import {ExpandedCard} from "../components/ExpandedCard";
import {baseUrl} from "../services/api";
import {tableStyles} from "../utils/tables/tableStyles";

export const CardTablePage = () => {
    const [cards, setCards] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

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

    return (
        <div>
            <div className="m-5">
                <span className="text-5xl font-bold bg-fc24-accent">FC 24 CARDS</span>
            </div>
            <DataTable
                columns={cardColumns}
                data={cards}
                fixedHeader
                pagination
                progressPending={isLoading}
                progressComponent={<Loader />}
                customStyles={tableStyles}
                expandableRows
                expandableRowsComponent={ExpandedCard}
                highlightOnHover
                persistTableHead={true}
            />
        </div>
    )
}