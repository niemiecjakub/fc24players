import {Playstyle} from "./Playstyle";

export const CardPlaystyles = () => {
    return (
        <div className="flex ">
            <div className="flex-col pr-8">
                Playstyles+
                <div className="flex">
                    <Playstyle playstyle="intercept" plus={true} />
                    <Playstyle playstyle="intercept" plus={true} />
                </div>
            </div>
            <div className="flex-col">
                Playstyles
                <div className="flex">
                    <Playstyle playstyle="intercept" plus={false} />
                    <Playstyle playstyle="intercept" plus={false} />
                </div>
            </div>
        </div>
    )
}