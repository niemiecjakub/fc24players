﻿import {PositionBadge} from "./PositionBadge";

export const CardAltposList = ({positions}) => {
    if (positions.length > 0) {
        return (
            <div className="flex-col">
                <p className="font-bold text-white text-xl">Alt positions</p>
                <div className="flex justify-evenly mt-2">
                    {positions.map((position, i) => <PositionBadge position={position} className="bg-fc24-black px-4 py-1 text-xl"/>)}
                </div>
            </div>
        )
    }
}