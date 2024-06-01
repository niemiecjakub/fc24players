import {CardDetailItem} from "./CardDetailItem";
import {StarRating} from "./StarRating";

export const CardDetails = ({card : {skillMoves, weakFoot, attWr, defWr, foot, height, acceleRate, age}}) => {
    return(
        <div className="flex w-full justify-around">  
            <CardDetailItem name="Age" value={age}/>
            <CardDetailItem name="Height" value={`${height} cm`}/>
            <CardDetailItem name="Pref Foot" value={foot}/>
            <CardDetailItem name="Skill Moves" value={<StarRating rating={skillMoves} />}/>
            <CardDetailItem name="Weak Foot" value={<StarRating rating={weakFoot} />}/>
            <CardDetailItem name="Att/Def WR" value={`${attWr}/${defWr}`}/>
            <CardDetailItem name="Accelerate" value={acceleRate}/>
        </div>

    )
}