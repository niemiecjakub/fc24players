import {useEffect, useState} from "react";
import {Loader} from "./Loader/Loader";
import {CardImage} from "./Card/CardImage";
import {useNavigate} from "react-router-dom";

const API_ENDPOINT = "https://localhost:7298/api/Player/";
export const ExpandedPlayer = ({data: {id}}) => {
    const [playerData, setPlayerData] = useState()
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        const getPlayerData = async () => {
            setIsLoading(true)
            const response = await fetch(API_ENDPOINT + id)
            if (response.ok) {
                const playerData = await response.json()
                setPlayerData(playerData)
                console.log(playerData)
            }
            setIsLoading(false)
        }

        getPlayerData()
    }, [])

    const handleCardNavigate = (cardId) => {
        navigate(`/card/${cardId}`);
    }
    return isLoading ? <Loader/> : (
        <>
            {playerData && 
                <div className="flex">
                    {playerData.cards.map(card => 
                        <div className="cursor-pointer mx-4" onClick={() => handleCardNavigate(card.id)} >
                            <CardImage id={card.id} className="h-48"/>
                        </div>
                        )}
                </div>
            }
        </>
    )
} 