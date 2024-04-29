import './App.css';
import NavbarTuto from './components/NavbarTuto';
import { Route, Routes } from 'react-router-dom';
import { About, Contact, Services, Home } from './pages';

function App() {
  return (
    <>
      <div className="App">
        <NavbarTuto />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/contact" element={<Contact />} />
          <Route path="/services" element={<Services />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
