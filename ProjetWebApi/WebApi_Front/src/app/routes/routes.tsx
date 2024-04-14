import { createBrowserRouter } from 'react-router-dom';
import { Home } from '../../pages/Home/Home';
import { Profil } from '../../pages/Home/SubPages/Profil';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
    children: [
      {
        path: 'Profil',
        element: <Profil />,
      },
      // {
      //   path: 'exercises',
      //   element: <Exercices />,
      // },
      // {
      //   path: 'planning',
      //   element: <Planning />,
      // },
      // {
      //   path: 'club',
      //   element: <Club />,
      // },
    ],
  },
]);
