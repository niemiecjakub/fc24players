export const StatValueBar = ({value}) => {
    return (
        <div className="h-1 w-full bg-neutral-200 dark:bg-neutral-600">
            <div className="h-1 bg-green-500" style={{width: `${value}%`}}></div>
        </div>
        )
}