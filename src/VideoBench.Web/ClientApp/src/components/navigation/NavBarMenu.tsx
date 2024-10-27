import React from 'react';
import { Box, Drawer, IconButton, MenuItem } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { styles } from '../../styles/styles';
import AuthService from '../../services/AuthService';
import { CustomButton } from '../Buttons';


export const NavBarMenu = () => {
  const [open, setOpen] = React.useState(false);

  const toggleDrawer = (newOpen: boolean) => () => {
    setOpen(newOpen);
  };

  return (
    <Box>
      <Box sx={{ display: { xs: 'none', md: 'flex' }, gap: 1, alignItems: 'center' }} >
        <Box>
          <CustomButton fullWidth variant='outlined' onClick={() => { AuthService.login() }}>
            Sign In
          </CustomButton>
        </Box>
        <Box>
          <CustomButton fullWidth variant='outlined' onClick={() => { AuthService.register() }}>
            Sign Up
          </CustomButton>
        </Box>
      </Box>

      <Box sx={{ display: { sm: 'flex', md: 'none' } }}>
        <IconButton aria-label='Menu button' onClick={toggleDrawer(true)}>
          <MenuIcon style={{ color: styles.PrimaryColor.color }} />
        </IconButton>
        <Drawer
          anchor='right'
          open={open}
          PaperProps={{
            sx: {
              backgroundColor: styles.BackgroundColor.color
            }
          }}
          onClose={toggleDrawer(false)}
        >
          <Box sx={{ mt: 5, p: 2, backgroundColor: styles.BackgroundColor }}>
            <MenuItem sx={{ mb: 2 }}>
              <CustomButton fullWidth variant='outlined' onClick={() => { AuthService.login() }}>
                Sign In
              </CustomButton>
            </MenuItem>
            <MenuItem>
              <CustomButton fullWidth variant='outlined' onClick={() => { AuthService.register() }}>
                Sign Up
              </CustomButton>
            </MenuItem>
          </Box>
        </Drawer>
      </Box>
    </Box>
  );
}