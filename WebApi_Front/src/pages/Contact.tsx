import { Box, Container } from '@mui/material';
import { getAllUsers, User } from './ContactService';
import { useEffect, useState } from 'react';

export default function Contact() {
  const [users, setUsers] = useState<User[]>([]);

  useEffect(() => {
    const fetchUsers = async () => {
      const usersData = await getAllUsers();
      setUsers(usersData);
    };

    fetchUsers();
  }, []);

  return (
    <Box sx={{ display: 'flex', marginTop: '100px' }}>
      <Container fixed>
        <h1>Contacttttttttttttttttttttttt</h1>
        <ul>
          {users.map((user) => (
            <li key={user.id}>
              <strong>ID:</strong> {user.id}, <strong>Email:</strong>{' '}
              {user.email}
            </li>
          ))}
        </ul>
      </Container>
    </Box>
  );
}
