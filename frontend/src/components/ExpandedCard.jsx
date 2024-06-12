import {useEffect, useState} from "react";
import {Loader} from "./Loader/Loader";
import {CardDetails} from "./Card/CardDetails";
import {Divider} from "./Card/Divider";
import {CardStats} from "./Card/CardStats";
import {CardPlaystyles} from "./Card/CardPlaystyles";
import {baseUrl} from "../services/api";
import {CardImage} from "./Card/CardImage";

export const ExpandedCard = ({data : {id}}) => {
    const [cardData, setCardData] = useState()
    const [isLoading, setIsLoading] = useState(false);
    
    useEffect(() => {
        const getCardData = async () => {
            setIsLoading(true)
            const response = await fetch(`${baseUrl}/Card/${id}`)
            if (response.ok) {
                const cardData = await response.json()
                setCardData(cardData)
            }
            setIsLoading(false)
        }

        getCardData()
    }, [])
    
    return isLoading ? <Loader/> : (
        <>
            {cardData &&
                <div className="flex flex-col bg-fc24-200 rounded-lg h-full p-2 my-2">
                    <CardDetails card={cardData}/>
                    <Divider width={100}/>
                    <div className="flex w-full">
                        <CardImage id={id} className="h-64"/>
                        <CardStats card={cardData}/>
                    </div>
                    <CardPlaystyles playstyles={cardData.playstyle} playstylesPlus={cardData.playstylePlus}/>
                </div>
            }
        </>
    )
}