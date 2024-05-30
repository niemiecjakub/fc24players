import {FlexContainer} from "../components/FlexContainer";
import {useEffect, useState} from "react";
import {CardImage} from "../components/Card/CardImage";
import {useLocation, useParams} from "react-router-dom";
import {CardStats} from "../components/Card/CardStats";
import {Loader} from "../components/Loader/Loader";
import {CardTitle} from "../components/Card/CardTitle";
import {CardDetails} from "../components/Card/CardDetails";
import {Divider} from "../components/Card/Divider";
import {CardPlaystyles} from "../components/Card/CardPlaystyles";
import {Position} from "../components/Card/Position";

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
            }
            setIsLoading(false)
        }

        getCard()
    }, [useLocation().pathname])

    console.log(card)
    return (
            <FlexContainer>
                {isLoading ? (<Loader />) : (
                    <>
                        {card ? (
                                <div className="flex flex-col">
                                    <CardTitle card={card} />
                                    <div className="flex">
                                        <div className="flex flex-col">
                                            <CardImage id={id} className="h-96"/>
                                            <div className="flex-col">
                                                <span>Alt positions</span>
                                                <div className="flex justify-evenly">
                                                    <Position position="LM"/>
                                                    <Position position="CAM"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="flex flex-col h-full bg-gray-400 p-2 rounded-2xl">
                                            <CardDetails />
                                            <Divider width={100}/>
                                            <CardStats card={card}/>
                                            <CardPlaystyles />
                                        </div>
                                    </div>
                                    {/*<StatsChart data={toRadarChartData(card)}/>*/}
                                </div>
                            )
                            :
                            <h1>No data</h1>}
                    </>
                )}
            </FlexContainer>
    )
}