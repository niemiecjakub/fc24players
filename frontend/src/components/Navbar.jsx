import {useNavigate} from "react-router-dom";
import {Button} from "./Button";
import {SearchBar} from "./SearchBar";
import {FlexContainer} from "./FlexContainer";
 
export const Navbar = () => {
    const navigate = useNavigate()
    return(
        <div className="bg-fc24-100 h-12 flex items-center justify-between px-4 border-b-2 border-b-fc24-400 sticky top-0 z-40">
            <img onClick={() => navigate("/")} className="h-5 cursor-pointer" alt="fc24logo" src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/EA_Sports_FC_24_logo.svg/1280px-EA_Sports_FC_24_logo.svg.png" />
            <SearchBar />
            <FlexContainer>
                <Button content="api" onClick={() =>  navigate("/api")}/>
                <Button content="clubs" onClick={() =>  navigate("/clubs")}/>
                <Button content="players" onClick={() =>  navigate("/players")}/>
                <Button content="cards" onClick={() =>  navigate("/cards")}/>
            </FlexContainer>
        </div>
    )
}