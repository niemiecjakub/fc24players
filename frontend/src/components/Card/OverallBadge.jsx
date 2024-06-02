export const OverallBadge = ({value}) => {
    return (
        <div className="text-xl p-1 rounded-md font-bold bg-fc24-100 w-full">
            {value ? value : "N/A"}
        </div>
    )
}