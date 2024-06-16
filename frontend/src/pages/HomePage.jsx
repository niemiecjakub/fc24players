import {FlexContainer} from "../components/FlexContainer";
import {Button} from "../components/Button";
import {CardImage} from "../components/Card/CardImage";
import {useEffect, useState} from "react";
import {baseUrl} from "../services/api";
import {Loader} from "../components/Loader/Loader";
import {InfiniteScroll} from "../components/InfiniteScroll";

export const HomePage = () => {
    // const [ids, setIds] = useState([])
    // const [isLoading, setIsLoading] = useState(false);
    //
    // useEffect(() => {
    //     const getCards = async () => {
    //         setIsLoading(true)
    //         const response = await fetch(`${baseUrl}/Card/ids?PageSize=50&IsNextPage=true`)
    //         if (response.ok) {
    //             const ids = await response.json()
    //             setIds(ids.data)
    //         }
    //         setIsLoading(false)
    //     }
    //
    //     getCards()
    // }, []);

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