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
        <div className="px-2 py-1 rounded-2xl bg-amber-50">
            <input
                type="text"
                placeholder="Card id..."
                onChange={handleChange}
                value={searchInput}
                className=""
            />
            <button onClick={searchCard}>Search</button>
        </div>
    )
}