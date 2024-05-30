import {HeadlineStat} from "./HeadlineStat";
import {IndividualStat} from "./IndividualStat";

export const CardStats = ({
    card: {position, pac, pacStats, sho, shoStats, pas, pasStats, dri, driStats, def, defStats, phy, phyStats, div, han, kic, ref, spd, pos, gkStats}}
) => {
    console.log(gkStats)
    return (
        <div className="flex flex-col">
            {
                position === "GK" &&
                <div className="flex flex-wrap pb-5">
                    <HeadlineStat name="DIV" value={div}>
                        <IndividualStat name="GK. Diving" value={gkStats.gkDiving}/>
                    </HeadlineStat>
                    
                    <HeadlineStat name="HAN" value={han}>
                        <IndividualStat name="GK. Handling" value={gkStats.gkHandling}/>
                    </HeadlineStat>
                    <HeadlineStat name="KIC" value={kic}>
                        <IndividualStat name="GK. Kicking" value={gkStats.gkKicking}/>
                    </HeadlineStat>
                    <HeadlineStat name="REF" value={ref}>
                        <IndividualStat name="GK. Reflexes" value={gkStats.gkReflexes}/>
                    </HeadlineStat>
                    <HeadlineStat name="SPD" value={spd}>
                        <IndividualStat name="Acceleration" value={pacStats.acceleration}/>
                        <IndividualStat name="Sprint Speed" value={pacStats.sprintSpeed}/>
                    </HeadlineStat>
                    <HeadlineStat name="POS" value={pos}>
                        <IndividualStat name="GK. Positioning" value={gkStats.gkPos}/>
                    </HeadlineStat>
                </div>
            }
            <div className="flex flex-wrap">
                <HeadlineStat name="PAC" value={pac}>
                    <IndividualStat name="Acceleration" value={pacStats.acceleration}/>
                    <IndividualStat name="Sprint Speed" value={pacStats.sprintSpeed}/>
                </HeadlineStat>
                <HeadlineStat name="SHO" value={sho}>
                    <IndividualStat name="Positioning" value={shoStats.positioning}/>
                    <IndividualStat name="Finishing" value={shoStats.finishing}/>
                    <IndividualStat name="Shot Power" value={shoStats.shotPower}/>
                    <IndividualStat name="Long Shots" value={shoStats.longShots}/>
                    <IndividualStat name="Volleys" value={shoStats.volleys}/>
                    <IndividualStat name="Penalties" value={shoStats.penalties}/>
                </HeadlineStat>
                <HeadlineStat name="PAS" value={pas}>
                    <IndividualStat name="Vision" value={pasStats.vision}/>
                    <IndividualStat name="Crossing" value={pasStats.crossing}/>
                    <IndividualStat name="FK. Acc" value={pasStats.fkAcc}/>
                    <IndividualStat name="Short Pass" value={pasStats.shortPass}/>
                    <IndividualStat name="Long Pass" value={pasStats.longPass}/>
                    <IndividualStat name="Curve" value={pasStats.curve}/>
                </HeadlineStat>
                <HeadlineStat name="DRI" value={dri}>
                    <IndividualStat name="Agility" value={driStats.agility}/>
                    <IndividualStat name="Balance" value={driStats.balance}/>
                    <IndividualStat name="Reactions" value={driStats.reactions}/>
                    <IndividualStat name="Ball Control" value={driStats.ballControl}/>
                    <IndividualStat name="Dribbling" value={driStats.dribbling}/>
                    <IndividualStat name="Composure" value={driStats.composure}/>
                </HeadlineStat>
                <HeadlineStat name="DEF" value={def}>
                    <IndividualStat name="Interceptions" value={defStats.interceptions}/>
                    <IndividualStat name="Heading Acc." value={defStats.headingAcc}/>
                    <IndividualStat name="Def. Awareness" value={defStats.defAwareness}/>
                    <IndividualStat name="Stand Tackle" value={defStats.standTackle}/>
                    <IndividualStat name="Slide Tackle" value={defStats.slideTackle}/>
                </HeadlineStat>
                <HeadlineStat name="PHY" value={phy}>
                    <IndividualStat name="Jumping" value={phyStats.jumping}/>
                    <IndividualStat name="Stamina" value={phyStats.stamina}/>
                    <IndividualStat name="Strength" value={phyStats.strength}/>
                    <IndividualStat name="Aggression" value={phyStats.aggression}/>
                </HeadlineStat>
            </div>
        </div>
    )
}