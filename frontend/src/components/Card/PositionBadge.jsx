export const PositionBadge = ({position, className}) => {
    return (
        <div className={`text-white rounded-lg bg-black font-bold ${className}`}>
            {position}
        </div>
    )
}