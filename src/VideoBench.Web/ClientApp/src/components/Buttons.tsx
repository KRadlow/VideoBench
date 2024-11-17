import { styled } from '@mui/system';
import { styles } from '../styles/styles';
import { Button } from '@mui/material';


const CustomButton = styled(Button)({
  textTransform: 'none',
  color: styles.PrimaryColor.color,
  backgroundColor: 'transparent',
  fontFamily: 'inherit',
  borderColor: styles.PrimaryColor.color,
  '&:hover': {
    backgroundColor: styles.PrimaryColor.color,
    color: styles.SecondaryColor.color
  }
});

const CustomIconButton = styled(Button)({
  backgroundColor: styles.PrimaryColor.color,
  color: 'black',
  height: '50px',
  marginLeft: '10px',
  '&:hover': {
    backgroundColor: styles.PrimaryColor.color,
  },
  textTransform: 'none',
});


export {
  CustomIconButton,
  CustomButton
}