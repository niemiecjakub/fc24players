import {useEffect, useState} from "react";
import {Loader} from "./Loader/Loader";
import {CardDetails} from "./Card/CardDetails";
import {Divider} from "./Card/Divider";
import {CardStats} from "./Card/CardStats";
import {CardPlaystyles} from "./Card/CardPlaystyles";

const API_ENDPOINT = "https://localhost:7298/api/Card/";
export const ExpandedCard = ({data : {id}}) => {
    const [cardData, setCardData] = useState()
    const [isLoading, setIsLoading] = useState(false);
    
    useEffect(() => {
        const getCardData = async () => {
            setIsLoading(true)
            const response = await fetch(API_ENDPOINT + id)
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
                    <CardStats card={cardData}/>
                    <CardPlaystyles playstyles={cardData.playstyle} playstylesPlus={cardData.playstylePlus}/>
                </div>
            }
        </>
    )
}