import {useNavigate} from "react-router-dom";
import {Button} from "./Button";

export const Navbar = () => {
    const navigate = useNavigate()
    const nagivateHomePage = () => {
        navigate("/")
    }
    const nagivatePlayersPage = () => {
        navigate("/players")
    }

    const nagivateCardsPage = () => {
        navigate("/cards")
    }
    
    return(
        <div className="bg-gray-500 h-12 flex items-center justify-between px-4">
            <h1 onClick={nagivateHomePage}>FC24 PLAYERS</h1>
            <div>
                <Button content="players" onClick={nagivatePlayersPage}/>
                <Button content="cards" onClick={nagivateCardsPage}/>
            </div>
        </div>
    )
}