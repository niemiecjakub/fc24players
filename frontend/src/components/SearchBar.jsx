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
        <div className="pl-4  bg-fc24-black border-fc24-400 border-2  text-white">
            <input
                type="text"
                placeholder="Card id..."
                onChange={handleChange}
                value={searchInput} 
                className="bg-fc24-black "
            >
            </input>
            <button className="bg-fc24-100 p-1  hover:bg-fc24-accent" onClick={searchCard}>Search</button>
        </div>
    )
}