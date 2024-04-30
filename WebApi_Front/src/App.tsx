import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Dashboard from './pages/Dashboard';
import Contact from './pages/Contact';
import Subscription from './pages/Subscription';

function App() {
  return (
    <>
      <div className="App">
        <BrowserRouter>
          <Sidebar />
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="/subscription" element={<Subscription />} />
          </Routes>
        </BrowserRouter>
      </div>
    </>
  );
}

export default App;
