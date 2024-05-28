export const StatValueBar = ({value, color}) => {
    return (
        <div className="h-2 w-full bg-neutral-200 dark:bg-neutral-600 rounded-2xl">
            <div className="h-2 rounded-2xl" style={{width: `${value}%`, backgroundColor : `${color}`}}></div>
        </div>
        )
}