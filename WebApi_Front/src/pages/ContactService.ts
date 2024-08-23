import axios from 'axios';

export interface User {
  id: number;
  email: string;
}

export const getAllUsers = async (): Promise<User[]> => {
  try {
    const response = await axios.get<User[]>(
      'https://localhost:7298/api/User/GetAllUsers',
    );
    console.log('API response:', response.data);
    return response.data;
  } catch (error) {
    console.error('There was an error fetching the users!', error);
    throw error;
  }
};
