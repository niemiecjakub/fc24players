import {useEffect, useState} from "react";
import DataTable from "react-data-table-component";
import {Loader} from "../components/Loader/Loader";
import {cardColumns} from "../utils/tables/cardColumns";
import {ExpandedCard} from "../components/ExpandedCard";

const API_ENDPOINT = "https://localhost:7298/api/Card/all";
export const CardTablePage = () => {
    const [cards, setCards] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        const getCards = async () => {
            setIsLoading(true)
            const response = await fetch(API_ENDPOINT)
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
            <h2 className="text-xl font-bold">Cards page</h2>
            <DataTable
                columns={cardColumns}
                data={cards}
                fixedHeader
                pagination
                progressPending={isLoading}
                progressComponent={<Loader />}
                striped
                expandableRows
                expandableRowsComponent={ExpandedCard}
            />
        </div>
    )
}