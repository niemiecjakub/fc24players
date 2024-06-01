import {StatValueBar} from "./StatValueBar";
import {valueToColor} from "../../utils/valueToColor";

export const IndividualStat = ({name, value}) => {
    return (
        <div className="flex flex-col pt-2">
            <div className="flex justify-between ">
                <h1 className="text-sm text-white font-extralight">{name}</h1>
                <div className="text-sm text-white font-bold">
                    {value ? value : "N/A"}
                </div>
            </div>
            <StatValueBar value={value ? value : 0} color={valueToColor(value)}/>
        </div>
    )
}