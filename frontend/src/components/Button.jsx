export const Button = ({content, onClick}) => {
    return(
        <button className="bg-fc24-accent uppercase mx-2 h-8 min-w-24 font-bold" onClick={onClick}>
            {content}
        </button>
    )
}