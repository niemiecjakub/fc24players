﻿import {valueToColor} from "../../utils/valueToColor";

export const HeadlineStatBadge = ({value}) => {
    return (
        <div className="text-xl px-1.5 py-1 rounded-md font-bold" style={{backgroundColor: `${valueToColor(value)}`}}>
            {value ? value : "N/A"}
        </div>
    )
}