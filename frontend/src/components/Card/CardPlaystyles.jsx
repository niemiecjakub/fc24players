import {Playstyle} from "./Playstyle";

const toAssetName = (value) => {
    if (value == "Whipped Pass") {
        return "whippedcrosser";
    }
    return  value.replaceAll(' ', '').toLowerCase();
}
export const CardPlaystyles = ({playstyles, playstylesPlus}) => {
    return (
        <div className="flex mt-2">
            {
                playstylesPlus.length > 0 && 
                <div className="flex-col pr-8">
                    <span className="font-bold text-white text-xl">Playstyles+</span>
                    <div className="flex">
                        {playstylesPlus && playstylesPlus.map((playstyle, i) => <Playstyle playstyle={playstyle} asset={toAssetName(playstyle)} plus={true}/>)}
                    </div>
                </div>
            }
            {
                playstyles.length > 0 &&
                <div className="flex-col">
                    <span className="font-bold text-white text-xl">Playstyles</span>
                    <div className="flex">
                        {playstyles.map((playstyle, i) => <Playstyle playstyle={playstyle} asset={toAssetName(playstyle)}
                                                                         plus={false}/>)}
                    </div>
                </div>
            }
        </div>
    )
}