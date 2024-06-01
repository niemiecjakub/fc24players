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
        <div className="px-4 py-2 rounded-full bg-fc24-black border-fc24-400 border-2 hover:bg-fc24-100 text-white">
            <input
                type="text"
                placeholder="Card id..."
                onChange={handleChange}
                value={searchInput}
                className="bg-fc24-black hover:bg-fc24-100"
            >
            </input>
            <button className="bg-fc24-100 p-1 rounded-full hover:bg-fc24-accent" onClick={searchCard}>Search</button>
        </div>
    )
}