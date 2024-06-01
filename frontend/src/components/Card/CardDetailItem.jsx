export const CardDetailItem = ({name, value}) => {
    return(
        <div className="flex flex-col text-white">
            <p className="text-2xl font-extrabold">{value}</p>
            <p className="text-md font-extralight">{name}</p>
        </div>
    )
}