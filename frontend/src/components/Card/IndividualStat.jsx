import {StatValueBar} from "./StatValueBar";

export const IndividualStat = ({name, value}) => {
    return (
        <div className="flex flex-col pt-1">
            <div className="flex justify-between ">
                <h1 className="text-lg text-white">{name}</h1>
                <div className="text-lg text-white">
                    {value}
                </div>
            </div>
            <StatValueBar value={value}/>
        </div>
    )
}