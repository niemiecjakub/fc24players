import {FlexContainer} from "../components/FlexContainer";
import {Button} from "../components/Button";
import {InfiniteScroll} from "../components/InfiniteScroll";

export const HomePage = () => {
    
    return (
        <FlexContainer>
            <div className="flex flex-col">
                <Button content="Discover players"/>
                <Button content="Discover cards"/>
                <Button content="Discover clubs"/>
                <InfiniteScroll />
            </div>
        </FlexContainer>
    )
}