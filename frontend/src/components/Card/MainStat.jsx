export const MainStat = ({name, value}) => {
    return (
        <div className="flex flex-col px-1">
            <span className="text-sm">{name}</span>
            <span className="text-lg font-bold">{value}</span>
        </div>
    )
}