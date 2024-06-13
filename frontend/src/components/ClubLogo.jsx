export const ClubLogo = ({name ,className}) => {
    return <img src={`/logos/${name}.svg`} className={`${className} h-16 w-16`} alt={`${name}`}/>
}