import {useState} from "react";
import {CardImageSkeleton} from "./CardImageSkeleton";

export const CardImage = ({id, className, onClick}) => {
    const [isLoading, setIsLoading] = useState(true)
    
    return (
        <>
            {isLoading && (
                <CardImageSkeleton className={`${className}`}/>
            )}
            <img className={`${className}`}
                 style={{ display: isLoading ? 'none' : 'block' }}
                 src={`https://cdn.futwiz.com/assets/img/fc24/social/cards/${id}.png`}
                 alt="card image"
                 onClick={onClick}
                 onLoad={() => setIsLoading(false)}
            />
        </>
    )
}