import { Box, TextField } from '@mui/material';
import { styled } from '@mui/system';
import { styles } from '../styles/styles';
import AuthService from '../services/AuthService';
import SearchIcon from '@mui/icons-material/Search';
import AddIcon from '@mui/icons-material/Add';
import { CustomIconButton } from '../components/Buttons';


const SearchTextField = styled(TextField)({
  '& .MuiInputBase-root': {
    color: 'black',
    backgroundColor: 'white',
    borderRadius: '4px',
    height: '50px',
    textTransform: 'none',
  },
  '& .MuiOutlinedInput-root': {
    '& fieldset': {
      borderColor: styles.PrimaryColor.color,
    },
    '&:hover fieldset': {
      borderColor: styles.PrimaryColor.color,
    },
    '&.Mui-focused fieldset': {
      borderColor: styles.PrimaryColor.color,
    },
  },
});


const HomePage = () => {
  return (
    <Box display="flex" alignItems="center">
      <SearchTextField variant="outlined" placeholder='Code' />
      <CustomIconButton variant="contained" >
        <SearchIcon />
      </CustomIconButton>
      {AuthService.isLoggedIn() && (
        <CustomIconButton variant="contained" >
          <AddIcon />
        </CustomIconButton>
      )}
    </Box>
  );
};

export default HomePage;
