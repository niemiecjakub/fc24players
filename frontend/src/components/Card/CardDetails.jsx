import {CardDetailItem} from "./CardDetailItem";
import {StarRating} from "./StarRating";

export const CardDetails = () => {
    return(
        <div className="flex w-full justify-around">  
            <CardDetailItem name="Skill Moves" value={<StarRating rating={4} />}/>
            <CardDetailItem name="Weak Foot" value={<StarRating rating={4} />}/>
            <CardDetailItem name="Att/Def WR" value="H/M"/>
            <CardDetailItem name="Pref Foot" value="Right"/>
            <CardDetailItem name="Height" value="180 cm"/>
            <CardDetailItem name="Accelerate" value="Explosive"/>
        </div>

    )
}