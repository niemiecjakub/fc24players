export const Divider = ({width, color}) => {
    return (
        <div className="h-1 w-full bg-neutral-200 dark:bg-neutral-600 my-2">
            <div className="h-1 " style={{width: `${width}%`, backgroundColor: `${color}`}}></div>
        </div>
    )
}