export const Box  = ({title, className, children}) => {
    return(
        <div className={`w-48 min-h-48 ${className}`}>
            <h2 className="font-bold">{title}</h2>
            {children}
        </div>
    )
}
