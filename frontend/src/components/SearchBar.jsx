import {Button} from "./Button";
import {FlexContainer} from "./FlexContainer";
import {useState} from "react";
import {useNavigate} from "react-router-dom";

export const SearchBar = () => {
    const [searchInput, setSearchInput] = useState()
    const navigate = useNavigate();
    const searchCard = () => {
        navigate(`card/${searchInput}`)
        setSearchInput("")
    }

    const handleChange = (e) => {
        e.preventDefault();
        setSearchInput(e.target.value);
    };
    
    return (
        <FlexContainer className="flex">
            <input
                type="text"
                placeholder="Card id..."
                onChange={handleChange}
                value={searchInput}
            />
            <button className="bg-amber-50" onClick={searchCard}>Search</button>
        </FlexContainer>
    )
}