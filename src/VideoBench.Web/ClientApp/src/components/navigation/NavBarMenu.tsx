import React from 'react';
import { Box, Button, Drawer, IconButton, MenuItem } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { styles } from '../../styles/styles'


interface StyledButtonProps {
  type: 'outlined' | 'contained';
  content: string;
}

const StyledButton: React.FC<StyledButtonProps> = ({ type, content }) => {
  return (
    <Button variant={type}
      fullWidth
      style={{
        textTransform: 'none',
        backgroundColor: 'transparent',
        fontFamily: 'inherit',
        borderColor: styles.PrimaryColor.color
      }}
    >
      <span style={styles.PrimaryColor}>{content}</span>
    </Button>
  );
}

export const NavBarMenu = () => {
  const [open, setOpen] = React.useState(false);

  const toggleDrawer = (newOpen: boolean) => () => {
    setOpen(newOpen);
  };

  return (
    <Box>
      <Box
        sx={{
          display: { xs: 'none', md: 'flex' },
          gap: 1,
          alignItems: 'center',
        }}
      >
        <Box>
          <StyledButton type='contained' content='Sign In' />
        </Box>
        <Box>
          <StyledButton type='outlined' content='Sign Up' />
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
              <StyledButton type='outlined' content='Sign In' />
            </MenuItem>
            <MenuItem>
              <StyledButton type='outlined' content='Sign Up' />
            </MenuItem>
          </Box>
        </Drawer>
      </Box>
    </Box>
  );
}