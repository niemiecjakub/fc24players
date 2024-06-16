import {baseUrl} from "../services/api";
import {Loader} from "./Loader/Loader";
import {CardImage} from "./Card/CardImage";
import {useCallback, useEffect, useState} from "react";

export const InfiniteScroll = () => {
    const [items, setItems] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [cursor, setCursor] = useState(1);
    const pageSize = 50;

    const fetchData = useCallback(async () => {
        if (isLoading) {
            return
        }
        setIsLoading(true);
        const response = await fetch(`${baseUrl}/Card/ids?PageSize=${pageSize}&Cursor=${cursor}&IsNextPage=true`)
        if (response.ok) {
            const ids = await response.json()
            console.log(ids.data)
            setItems(prevItems => [...prevItems, ...ids.data]);
            console.log("fetching next")
            setCursor(ids.nextId);
        }
        setIsLoading(false)
    }, [cursor, isLoading]);

    useEffect(() => {
        const getData = async () => {
            setIsLoading(true)
            const response = await fetch(`${baseUrl}/Card/ids?PageSize=${pageSize}&IsNextPage=true`)
            if (response.ok) {
                const ids = await response.json()
                setItems(ids.data)
            }
            setIsLoading(false)
        };

        getData();
    }, []);
  
    useEffect(() => {
        const handleScroll = () => {
            const {scrollTop, clientHeight, scrollHeight} = document.documentElement;
            if (scrollTop + clientHeight >= scrollHeight - 20) {
                fetchData();
            }
        };
        window.addEventListener("scroll", handleScroll);
        return () => {
            window.removeEventListener("scroll", handleScroll);
        };
    }, [fetchData]);

    // return <h1 className="text-white">XD</h1>
    return isLoading ? <Loader/> :
        (
            <div className="flex flex-wrap">
                {items.map((id, i) => <CardImage id={id} className="h-64"/>)}
            </div>
        );
}