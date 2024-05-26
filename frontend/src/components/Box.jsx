export const Box  = ({title, children}) => {
    return(
        <div className="bg-amber-300 m-4 w-48 min-h-48">
            <h2 className="font-bold">{title}</h2>
            {children}
        </div>
    )
}
