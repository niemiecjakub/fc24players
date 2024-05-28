export const CardImage = ({id, className}) => {
    return (
        <img className={`${className}`} 
             src={`https://cdn.futwiz.com/assets/img/fc24/social/cards/${id}.png`}
             alt="card image"
        />
    )
}