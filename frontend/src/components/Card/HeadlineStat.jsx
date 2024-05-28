import {valueToColor} from "../../utils/valueToColor";

export const HeadlineStat = ({name, value, children}) => {
    return (
        <div className="w-36 mx-4">
            <div className="flex justify-between items-center font-bold">
                <h1 className="text-2xl font-bold text-white">{name}</h1>
                <div className="text-xl p-1 rounded-md" style={{backgroundColor : `${valueToColor(value)}`}}>
                    {value ? value : "N/A"}
                </div>
            </div>
            {children}
        </div>
    )
}