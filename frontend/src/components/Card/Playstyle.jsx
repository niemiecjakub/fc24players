export const Playstyle = ({playstyle, plus}) => {
    const url = plus ? `https://cdn.futwiz.com/assets/img/fc24/playstyles/${playstyle}-plus.png` : `https://cdn.futwiz.com/assets/img/fc24/playstyles/${playstyle}.png`;
    return (
        <div className="flex flex-col">
        <img
            className="h-20"
            alt="playstyle"
            src={`${url}`}/>
            <span>{playstyle}</span>
        </div>
    )
}