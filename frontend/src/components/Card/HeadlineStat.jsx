import {HeadlineStatBadge} from "./HeadlineStatBadge";

export const HeadlineStat = ({name, value, children}) => {
    return (
        <div className="w-36 mx-4">
            <div className="flex justify-between items-center font-bold">
                <h1 className="text-2xl font-bold text-white">{name}</h1>
                <HeadlineStatBadge value={value} />
            </div>
            {children}
        </div>
    )
}