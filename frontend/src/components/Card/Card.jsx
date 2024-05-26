import {toRadarChartData} from "../../utils/Chart";
import {StatsChart} from "./StatsChart";
import {Box} from "../Box";
import {MainStat} from "./MainStat";

export const Card = ({data}) => {
    return (
        <>
            <Box>
                <div className="flex flex-col items-start">
                    <span>Name: {data.player.name}</span>
                    <span>Nationality: {data.player.nationality}</span>
                    <span>Position: {data.position}</span>
                    <span>Age: {data.age}</span>
                    <span>Version: {data.version}</span>
                    <span>Rating: {data.overallRating}</span>
                    <span>Price: {data.price} pln</span>
                    <span>Club: {data.club}</span>
                    <span>League: {data.league}</span>
                </div>
                <div className="flex justify-between pt-2">
                    <MainStat name="PAC" value={data.pac}/>
                    <MainStat name="SHO" value={data.sho}/>
                    <MainStat name="PAS" value={data.pas}/>
                    <MainStat name="DRI" value={data.dri}/>
                    <MainStat name="DEF" value={data.def}/>
                    <MainStat name="PHY" value={data.phy}/>
                </div>
            </Box>
            <StatsChart data={toRadarChartData(data)}/>
        </>
    )
}