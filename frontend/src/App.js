import './App.css';
import {Outlet} from "react-router-dom";
import {ContentContainer} from "./components/ContentContainer";
import {Navbar} from "./components/Navbar";

function App() {

  return (
    <div className="App">
        <Navbar />
        <ContentContainer>
            <Outlet />
        </ContentContainer>
    </div>
  );
}

export default App;
