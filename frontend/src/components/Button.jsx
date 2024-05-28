export const Button = ({content, onClick}) => {
    return(
        <button className="bg-black text-white mx-2 h-8 min-w-32" onClick={onClick}>
            {content}
        </button>
    )
}