import Contact from './pages/Contact';
import Dashboard from './pages/Dashboard';
import Subscription from './pages/Subscription';
import DashboardIcon from '@mui/icons-material/Dashboard';
import AccountBoxIcon from '@mui/icons-material/AccountBox';
import SubscriptionsIcon from '@mui/icons-material/Subscriptions';

export default function () {
  const dataSidebar = [
    {
      id: 0,
      label: 'Dashboard',
      img: <DashboardIcon />,
      component: <Dashboard />,
      path: '/',
    },
    {
      id: 1,
      label: 'Contact',
      img: <AccountBoxIcon />,
      component: <Contact />,
      path: '/contact',
    },
    {
      id: 2,
      label: 'Subscription',
      img: <SubscriptionsIcon />,
      component: <Subscription />,
      path: '/subscription',
    },
  ];
  return dataSidebar;
}
//export default dataSidebar;
