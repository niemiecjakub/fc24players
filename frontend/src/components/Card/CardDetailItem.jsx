export const CardDetailItem = ({name, value}) => {
    return(
        <div className="flex flex-col">
            <p className="text-2xl font-bold">{value}</p>
            <p className="text-md">{name}</p>
        </div>
    )
}