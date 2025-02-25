import React from 'react';
import { Box } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';
import { CustomIconButton } from '../components/Buttons';
import { CustomTextField } from '../components/TextField';

const navigate = (path: string) => {
  window.location.href = `${path}`
}

const HomePage = () => {
  const [searchValue, setSearchValue] = React.useState('');

  const handleSearch = () => {
    navigate(`/test?code=${encodeURIComponent(searchValue)}`);
  };

  return (
    <Box display="flex" alignItems="center">
      <CustomTextField
        variant="outlined"
        placeholder='Code'
        autoComplete='off'
        autoCorrect='off'
        value={searchValue}
        onChange={(e) => setSearchValue(e.target.value)}
      />
      <CustomIconButton variant="contained" onClick={handleSearch}>
        <SearchIcon />
      </CustomIconButton>
    </Box>
  );
};

export default HomePage;
