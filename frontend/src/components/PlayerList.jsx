import {Box} from "./Box";

export const PlayerList = ({players}) => {
    {players.map(({id, name, nationality}, i) =>
        <Box title={name} key={i}>
            <p>{id}) {name} - {nationality}</p>
        </Box>)
    }
}