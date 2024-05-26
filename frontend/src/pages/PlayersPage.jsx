import {useEffect, useState} from "react";
import {useNavigate, useParams} from "react-router-dom";
import {Box} from "../components/Box";
import {Button} from "../components/Button";

const API_ENDPOINT = "https://localhost:7298/api/Player/all?PageSize=48&PageNumber=";

export const PlayersPage = () => {
    const [players, setPlayers] = useState([]);
    const {page} = useParams()
    const navigate = useNavigate()
    const currentPage = page ? parseInt(page) : 1;

    useEffect(() => {
        const getPlayers = async () => {
            const response = await fetch(API_ENDPOINT + currentPage)
            if (response.ok) {
                const players = await response.json()
                setPlayers(players)
            }
        }

        getPlayers()
    }, [page]);

    const handleNextPage = () => {
        navigate(`/players/${currentPage + 1}`);
    }

    const handlePreviousPage = () => {
        if (currentPage > 1) {
            navigate(`/players/${currentPage - 1}`);
        }
    }

    return (
        <div>
            <h2 className="text-xl font-bold">Player page</h2>
            {players.length > 0 && <Button content="next page" onClick={handleNextPage}/>}
            <Button content="prev page" onClick={handlePreviousPage}/>
            <div className="flex flex-wrap items-center justify-center">
                {players.map(({id, name, nationality}, i) =>
                    <Box title={name} key={i}>
                        <p>{id}) {name} - {nationality}</p>
                    </Box>)
                }
            </div>
        </div>
    )
}
