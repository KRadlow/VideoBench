import {AppBar, Box, Toolbar, Container} from '@mui/material';
import { UserMenu } from './UserMenu';
import { NavBarMenu } from './NavBarMenu';
import { styles } from '../../styles/styles'
import AuthService from '../../services/AuthService';


export const NavBar = () => {
  return (
    <AppBar
      position='fixed'
      sx={{ boxShadow: 0, bgcolor: 'transparent', backgroundImage: 'none', mt: 5 }}
    >
      <Container maxWidth='lg'>
        <Toolbar sx={{ justifyContent: 'space-between' }}>
          <Box sx={{ position: 'start' }}>
            <span style={styles.PrimaryColor}>Video</span>
            <span style={styles.SecondaryColor}>Bench</span>
          </Box>
          <Box >
            {AuthService.isLoggedIn() ? (
              <UserMenu />
            ) : (
              <NavBarMenu />
            )}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}

export default NavBar;