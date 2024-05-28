import {Star} from "./Star";

export const StarRating = ({rating}) => {
    return(
        <div className="flex items-center justify-center">
            <span className="pr-2">{rating}</span>
             <Star />
        </div>
    )
}