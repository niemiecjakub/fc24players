﻿import {createBrowserRouter} from "react-router-dom";
import {HomePage} from "../pages/HomePage";
import {CardPage} from "../pages/CardPage";
import {PlayerTablePage} from "../pages/PlayerTablePage";
import {CardTablePage} from "../pages/CardTablePage";
import {ClubTablePage} from "../pages/ClubTablePage";
import App from "../App";
import {ApiPage} from "../pages/apiPage";

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
            {
                path: "clubs",
                element: <ClubTablePage />,
            },
            {
                path: "api",
                element: <ApiPage />
            }
        ],
    },
]);