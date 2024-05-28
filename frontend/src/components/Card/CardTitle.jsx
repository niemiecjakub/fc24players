export const CardTitle = ({card}) => {
    return (
        <>
            <div className="flex divide-x-2 divide-black my-3 items-center">
                <h1 className="font-extrabold text-3xl">{card.player.name}</h1>
                <p className="text-xl p-2 m-2">{card.version}</p>
                <div className="text-xl p-2 flex items-center">
                    <p className="pr-2">{card.price} </p>
                    <img className="h-6" alt="coin" src="https://cdn.futwiz.com/assets/img/fc24/fut-coin-single.png" />
                </div>
            </div>
        <div className="flex">
            <p>{card.player.nationality}</p>
            <p>{card.club}</p>
            <p>{card.league}</p>
        </div>
        </>
)
}