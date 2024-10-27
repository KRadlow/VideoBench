import React from 'react';
import { AccountCircle } from '@mui/icons-material';
import { Box, Divider, Drawer, IconButton, Menu, MenuItem } from '@mui/material';
import { styles } from '../../styles/styles'
import AuthService from '../../services/AuthService';
import { CustomButton } from '../Buttons';


export const UserMenu = () => {
  const [menuOpen, setMenuOpen] = React.useState<null | HTMLElement>(null);

  const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
    setMenuOpen(event.currentTarget);
  };

  const handleClose = () => {
    setMenuOpen(null);
  };

  const [open, setOpen] = React.useState(false);

  const toggleDrawer = (newOpen: boolean) => () => {
    setOpen(newOpen);
  };

  return (
    <Box>
      <Box sx={{ display: { xs: 'none', md: 'flex' }, gap: 1, alignItems: 'center' }}>
        {AuthService.getUserName()}
        <IconButton
          size='large'
          aria-label='account of current user'
          aria-controls='menu-user'
          aria-haspopup='true'
          onClick={handleMenu}
          color='inherit'
        >
          <AccountCircle />
        </IconButton>
        <Menu
          id='menu-user'
          anchorEl={menuOpen}
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'right',
          }}
          keepMounted
          transformOrigin={{
            vertical: 'top',
            horizontal: 'right',
          }}
          PaperProps={{
            sx: {
              backgroundColor: styles.BackgroundColor.color,
              borderColor: styles.PrimaryColor,
              border: '1px solid ',
            }
          }}
          open={Boolean(menuOpen)}
          onClose={handleClose}
        >
          <MenuItem sx={{ mb: 2 }}>
            <CustomButton fullWidth variant='outlined'>
              Profile
            </CustomButton>
          </MenuItem>
          <MenuItem sx={{ mb: 2 }}>
            <CustomButton fullWidth variant='outlined'>
              My account
            </CustomButton>
          </MenuItem>
          <Divider variant='middle' sx={{ backgroundColor: styles.PrimaryColor.color }} />
          <MenuItem sx={{ mt: 2 }}>
            <CustomButton fullWidth variant='outlined' onClick={() => { AuthService.logout() }}>
              Logout
            </CustomButton>
          </MenuItem>
        </Menu>
      </Box>

      <Box sx={{ display: { sm: 'flex', md: 'none' } }}>
        <IconButton
          size='large'
          aria-label='account of current user'
          aria-controls='menu-user'
          aria-haspopup='true'
          onClick={toggleDrawer(true)}
          color='inherit'
        >
          <AccountCircle />
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
              <CustomButton fullWidth variant='outlined'>
                Profile
              </CustomButton>
            </MenuItem>
            <MenuItem sx={{ mb: 2 }}>
              <CustomButton fullWidth variant='outlined'>
                My account
              </CustomButton>
            </MenuItem>
            <Divider variant='middle' sx={{ backgroundColor: styles.PrimaryColor.color }} />
            <MenuItem sx={{ mt: 2 }}>
              <CustomButton fullWidth variant='outlined' onClick={() => { AuthService.logout() }}>
                Logout
              </CustomButton>
            </MenuItem>
          </Box>
        </Drawer>
      </Box>
    </Box>
  );
}