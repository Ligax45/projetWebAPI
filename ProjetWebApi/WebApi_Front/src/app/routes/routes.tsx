import { createBrowserRouter } from 'react-router-dom';
import Home from '../../pages/Home';
import Dashboard from '../../pages/Dashboard';
import App from '../App';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
  },
  {
    path: '/home',
    element: <Home />,
  },
  {
    path: '/dashboard',
    element: <Dashboard />,
  },
]);
