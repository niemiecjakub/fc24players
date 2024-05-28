import {FlexContainer} from "../components/FlexContainer";
import {useEffect, useState} from "react";
import {CardImage} from "../components/Card/CardImage";
import {useLocation, useParams} from "react-router-dom";
import {StatsChart} from "../components/Card/StatsChart";
import {toRadarChartData} from "../utils/Chart";
import {CardStats} from "../components/Card/CardStats";
import {Loader} from "../components/Loader/Loader";


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

    console.log(card)
    return (
        <div>
            <h2 className="text-xl font-bold">Card page</h2>
            <FlexContainer>
                {isLoading ? (<Loader />) : (
                    <>
                        {card ? (
                                <div className="flex flex-col">
                                    <div className="flex divide-x-2 divide-black my-3 items-center">
                                        <h1 className="font-bold text-2xl">{card.player.name}</h1>
                                        <p className="text-xl p-2 m-2">{card.version}</p>
                                        <p className="text-xl p-2">{card.price} $</p>
                                    </div>
                                    <div className="flex">
                                        <CardImage id={id} className="h-96"/>
                                        <CardStats data={card}/>
                                    </div>
                                        <StatsChart data={toRadarChartData(card)}/>
                                </div>
                            )
                            :
                            <h1>No data</h1>}
                    </>
                )}

            </FlexContainer>
        </div>
    )
}