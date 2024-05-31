import {Playstyle} from "./Playstyle";

export const CardPlaystyles = ({card}) => {
    console.log(card.playstyle)
    console.log(card.playstylePlus)
    return (
        <div className="flex ">
            {
                card.playstylePlus.length > 0 && 
                <div className="flex-col pr-8">
                    Playstyles+
                    
                    <div className="flex">
                        {card.playstylePlus && card.playstylePlus.map((playstyle, i) => <Playstyle playstyle={playstyle.toLowerCase()} plus={true}/>)}
                    </div>
                </div>
            }
            {
                card.playstyle.length > 0 &&
                <div className="flex-col">
                    Playstyles
                    <div className="flex">
                        {card.playstyle.map((playstyle, i) => <Playstyle playstyle={playstyle.toLowerCase()} plus={false}/>)}
                    </div>
                </div>
            }
        </div>
    )
}