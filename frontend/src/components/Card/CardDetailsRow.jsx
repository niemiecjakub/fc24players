export const CardDetailsRow = ({name, value}) => {
    return(
        <div className="flex justify-between px-2 text-md">
            <div>{name}</div>
            <p>{value}</p>
        </div>
    )
}