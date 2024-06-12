import ReactCountryFlag from "react-country-flag";

export const CardTitle = ({card}) => {
    return (
        <>
            <div className="flex divide-x-2 divide-fc24-accent my-3 items-center text-white">
                <h1 className="font-extrabold text-3xl">{card.player.name}</h1>
                <p className="text-xl p-2 m-2">{card.version}</p>
                <div className="text-xl p-2 flex items-center">
                    <p className="pr-2">{card.price} </p>
                    <img className="h-6" alt="coin" src="https://cdn.futwiz.com/assets/img/fc24/fut-coin-single.png" />
                </div>
            </div>
        <div className="flex text-white">
            <ReactCountryFlag countryCode={card.player.nationalityCode} svg
                              style={{
                                  width: '3em',
                                  height: '3em',
                              }}
            />
            <img src={`/logos/${card.club}.svg`} className="w-12 h-12"  alt="club logo"/>
            <p>{card.league}</p>
        </div>
        </>
)
}