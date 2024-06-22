import {FlexContainer} from "../components/FlexContainer";

export const ApiPage = () => {
    return (
        <div>
            <div className="m-5">
                <span className="text-5xl font-bold bg-fc24-accent">API ROUTES</span>
            </div>
            <div className="flex bg-fc24-100 text-white ">
                <div className="bg-blue-400 font-bold px-2 py-1 text-lg">
                    GET
                </div>
                <div className="bg-blue-400 font-bold px-2 py-1 text-lg">
                    /api/Player/all
                </div>
                <div className="bg-blue-400 font-bold px-2 py-1 text-lg">
                    returns all players
                </div>
            </div>
            <div className="flex bg-fc24-100 text-white ">
                Parameters
            </div>
            <div className="flex bg-fc24-100 text-white ">
                Response
            </div>
        </div>
    )
}
