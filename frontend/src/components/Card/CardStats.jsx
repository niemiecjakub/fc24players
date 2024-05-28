import {CardDetailsRow} from "./CardDetailsRow";
import {HeadLineStat} from "./HeadLineStat";
import {IndividualStat} from "./IndividualStat";

export const CardStats = ({data : {player, age, version, club, league, pac, sho, pas, dri, def, phy}}) => {
    return (
        <div className="flex">
            <div className="bg-gray-400 mr-4">
                <CardDetailsRow name="Name" value={player.name} />
                <CardDetailsRow name="Age" value={age} />
                <CardDetailsRow name="Version" value={version} />
                <CardDetailsRow name="Club" value={club} />
                <CardDetailsRow name="League" value={league} />
                <CardDetailsRow name="Nationality" value={player.nationality} />
            </div>
            <div className="flex">
                <HeadLineStat name="PAC" value={pac}>
                    <IndividualStat name="Acceleration" value={90} />
                    <IndividualStat name="Sprint Speed" value={90} />
                </HeadLineStat>
                <HeadLineStat name="SHO" value={sho}>
                    <IndividualStat name="Positioning" value={90} />
                    <IndividualStat name="Finishing" value={90} />
                    <IndividualStat name="Shot Power" value={90} />
                    <IndividualStat name="Long Shots" value={90} />
                    <IndividualStat name="Volleys" value={90} />
                    <IndividualStat name="Penalties" value={90} />
                </HeadLineStat>
                <HeadLineStat name="PAS" value={pas}>
                    <IndividualStat name="Vision" value={90} />
                    <IndividualStat name="Crossing" value={90} />
                    <IndividualStat name="FK. Acc" value={90} />
                    <IndividualStat name="Short Pass" value={90} />
                    <IndividualStat name="Long Pass" value={90} />
                    <IndividualStat name="Curve" value={90} />
                </HeadLineStat>
                <HeadLineStat name="DRI" value={dri}>
                    <IndividualStat name="Agility" value={90} />
                    <IndividualStat name="Balance" value={90} />
                    <IndividualStat name="Reactions" value={90} />
                    <IndividualStat name="Ball Control" value={90} />
                    <IndividualStat name="Dribbling" value={90} />
                    <IndividualStat name="Composure" value={90} />
                </HeadLineStat>
                <HeadLineStat name="DEF" value={def}>
                    <IndividualStat name="Interceptions" value={90} />
                    <IndividualStat name="Heading Acc." value={90} />
                    <IndividualStat name="Def. Awareness" value={90} />
                    <IndividualStat name="Stand Tackle" value={90} />
                    <IndividualStat name="Slide Tackle" value={90} />
                </HeadLineStat>
                <HeadLineStat name="PHY" value={phy}>
                    <IndividualStat name="Jumping" value={90} />
                    <IndividualStat name="Stamina" value={90} />
                    <IndividualStat name="Strength" value={90} />
                    <IndividualStat name="Aggression" value={90} />
                </HeadLineStat>
            </div>
        </div>
    )
}