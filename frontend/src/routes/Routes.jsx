import {createBrowserRouter} from "react-router-dom";
import {HomePage} from "../pages/HomePage";
import {CardPage} from "../pages/CardPage";
import {PlayersPage} from "../pages/PlayersPage";
import App from "../App";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { 
                path: "players/:page?", 
                element: <PlayersPage />,
            },
            {
                path: "cards/:page?",
                element: <CardPage />,
            },
        ],
    },
]);