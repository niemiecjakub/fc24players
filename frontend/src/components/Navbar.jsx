import {useNavigate} from "react-router-dom";
import {Button} from "./Button";
import {SearchBar} from "./SearchBar";
import {FlexContainer} from "./FlexContainer";

export const Navbar = () => {
    const navigate = useNavigate()
    const nagivateHomePage = () => {
        navigate("/")
    }
    const nagivatePlayersPage = () => {
        navigate("/players")
    }
    
    return(
        <div className="bg-green-600 h-12 flex items-center justify-between px-4">
            <img onClick={nagivateHomePage} className="h-5 cursor-pointer" alt="fc24logo" src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/EA_Sports_FC_24_logo.svg/1280px-EA_Sports_FC_24_logo.svg.png" />
            <SearchBar />
            <FlexContainer>
                <Button content="players" onClick={nagivatePlayersPage}/>
            </FlexContainer>
        </div>
    )
}