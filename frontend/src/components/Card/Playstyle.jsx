export const Playstyle = ({playstyle, asset, plus}) => {
    const url = plus ? `https://cdn.futwiz.com/assets/img/fc24/playstyles/${asset}-plus.png` : `https://cdn.futwiz.com/assets/img/fc24/playstyles/${asset}.png`;
    return (
        <div className="flex flex-col mx-1 items-center bg-green-600 p-1 rounded-lg">
        <img
            className="h-16 w-16"
            alt="playstyle"
            src={`${url}`}/>
            <span className="text-white font-bold uppercase">{playstyle}</span>
        </div>
    )
}