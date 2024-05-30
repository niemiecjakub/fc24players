import {createBrowserRouter} from "react-router-dom";
import {HomePage} from "../pages/HomePage";
import {CardPage} from "../pages/CardPage";
import {PlayerTablePage} from "../pages/PlayerTablePage";
import {CardTablePage} from "../pages/CardTablePage";
import App from "../App";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { 
                path: "players", 
                element: <PlayerTablePage />,
            },
            {
                path: "cards",
                element: <CardTablePage />,
            },
            {
                path: "card/:id",
                element: <CardPage />,
            },
        ],
    },
]);