import { BrowserRouter, Route, Routes } from 'react-router-dom';
import NavBar from '../components/navigation/NavBar';
import ProtectedRoute from '../components/ProtectedRoute';
import HomePage from './HomePage';
import UserPage from './UserPage';
import TestPage from './TestPage';
import CreateTestPage from './CreateTestPage';
import styled from '@emotion/styled';


const AppContainer = styled.div`
  display: flex;
`;

const Layout = () => {
  return (
    <AppContainer>
      <NavBar />
      <BrowserRouter>
        <Routes>

          {/* Public route */}
          <Route path='/' element={<HomePage />} />
          <Route path='test' element={<TestPage />} />

          {/* Protected route */}
          <Route path='user' element={<ProtectedRoute />}>
            <Route path='' element={<UserPage />} />
          </Route>
          <Route path='new' element={<ProtectedRoute />}>
            <Route path='' element={<CreateTestPage />} />
          </Route>

        </Routes>
      </BrowserRouter>
    </AppContainer>
  );
};

export default Layout;