import styled from "@emotion/styled";
import { TextField } from "@mui/material";
import { styles } from "../styles/styles";

const CustomTextField = styled(TextField)({
  '& .MuiInputBase-root': {
    color: 'black',
    backgroundColor: 'white',
    borderRadius: '4px',
    height: '50px',
    textTransform: 'none',
  },
  '& .MuiInputLabel-root.Mui-focused': {
    color: styles.PrimaryColor.color,
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
  }
});

const CustomDarkTextField = styled(TextField)({
  '& .MuiInputBase-root': {
    color: styles.PrimaryColor.color,
    backgroundColor: styles.BackgroundColor.color,
    borderRadius: '4px',
    height: '50px',
    textTransform: 'none',
  },
  '& .MuiInputLabel-root.Mui-focused': {
    color: styles.PrimaryColor.color,
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
  }
});

const CustomNumberField = styled(TextField)({
  '& .MuiInputLabel-root': {
    color: styles.PrimaryColor.color,
  },
  '& .MuiInputBase-root': {
    color: styles.PrimaryColor.color,
    borderRadius: '4px',
    height: '50px',
    textTransform: 'none',
  },
  '& .MuiInputLabel-root.Mui-focused': {
    color: styles.PrimaryColor.color,
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
  }
});

export {CustomTextField, CustomDarkTextField, CustomNumberField};