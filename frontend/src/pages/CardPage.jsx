import {Button} from "../components/Button";
import {FlexContainer} from "../components/FlexContainer";
import {PlayerList} from "../components/PlayerList";

export const CardPage = () => {
    return (
        <div>
            <h2 className="text-xl font-bold">Player page</h2>
            <Button content="next page"/>
            <Button content="prev page"/>
            <FlexContainer>
                <h1>Card List</h1>
            </FlexContainer>
        </div>
    )
}