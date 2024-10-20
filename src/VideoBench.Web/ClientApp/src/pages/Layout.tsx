import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { HomePage } from './HomePage';
import { UserPage } from './UserPage';
import { NavBar } from '../components/navigation/NavBar';
import styled from '@emotion/styled';


const AppContainer = styled.div`
  display: flex;
`;

export const Layout = () => {
  return (
    <AppContainer>
      <NavBar />
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='user' element={<UserPage />} />
        </Routes>
      </BrowserRouter>
    </AppContainer>
  );
};