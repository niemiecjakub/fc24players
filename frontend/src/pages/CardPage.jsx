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
import {toRadarChartData} from "../utils/chart";
import {StatsChart} from "../components/Card/StatsChart";
import {CardAltposList} from "../components/Card/CardAltposList";
import {baseUrl} from "../services/api";

export const CardPage = () => {
    const [card, setCard] = useState()
    const [isLoading, setIsLoading] = useState(false)
    const {id} = useParams()

    useEffect(() => {
        const getCard = async () => {
            setIsLoading(true)
            const response = await fetch(`${baseUrl}/Card/${id}`)
            if (response.ok) {
                const cards = await response.json()
                setCard(cards)
            }
            setIsLoading(false)
        }

        getCard()
    }, [useLocation().pathname])
    
    return (
            <FlexContainer>
                {isLoading ? (<Loader />) : (
                    <>
                        {card ? (
                                <div className="flex flex-col bg-fc24-200 rounded-lg px-4 py-2">
                                    <CardTitle card={card} />
                                    <div className="flex">
                                        <div className="flex flex-col">
                                            <CardImage id={id} className="h-96"/>
                                            <CardAltposList positions={card.altPos}/>
                                        </div>
                                        <div className="flex flex-col h-full p-2">
                                            <CardDetails card={card}/>
                                            <Divider width={100}/>
                                            <CardStats card={card}/>
                                            <CardPlaystyles playstyles={card.playstyle} playstylesPlus={card.playstylePlus}/>
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