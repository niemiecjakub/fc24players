import './App.css';
import {Outlet, useLocation} from "react-router-dom";
import {ContentContainer} from "./components/ContentContainer";
import {Navbar} from "./components/Navbar";

function App() {
    
  return (
    <div className="App min-h-screen">
        <Navbar />
        <ContentContainer>
            <Outlet />
        </ContentContainer>
    </div>
  );
}

export default App;
