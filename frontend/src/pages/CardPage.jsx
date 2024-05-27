import {FlexContainer} from "../components/FlexContainer";
import {useEffect, useState} from "react";
import {Card} from "../components/Card/Card";
import {useLocation, useParams} from "react-router-dom";
import {StatsChart} from "../components/Card/StatsChart";
import {toRadarChartData} from "../utils/Chart";


const API_ENDPOINT = "https://localhost:7298/api/Card/";

export const CardPage = () => {
    const [card, setCard] = useState()
    const [isLoading, setIsLoading] = useState(false)
    const {id} = useParams()

    useEffect(() => {
        const getCard = async () => {
            setIsLoading(true)
            const response = await fetch(API_ENDPOINT + id)
            if (response.ok) {
                const cards = await response.json()
                setCard(cards)
            } else {
                setCard("")
            }
            setIsLoading(false)
        }

        getCard()
    }, [useLocation().pathname])

    return (
        <div>
            <h2 className="text-xl font-bold">Card page</h2>
            <FlexContainer>
                {isLoading ? (<h1>loading</h1>) : (
                    <>
                        {card ? <>
                            <Card data={card}/>
                            <StatsChart data={toRadarChartData(card)}/>
                            </>: <h1>No data</h1>}
                    </>
                )}

            </FlexContainer>
        </div>
    )
}