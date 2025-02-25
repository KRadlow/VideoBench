import { styled } from "@mui/material/styles";
import { styles } from "../styles/styles";
import { MobileDateTimePicker } from '@mui/x-date-pickers/MobileDateTimePicker';

const CustomDatePicker = styled(MobileDateTimePicker)({
    "& .MuiInputBase-root": {
        color: styles.PrimaryColor.color,
    },
    '& .MuiInputLabel-root': {
        color: styles.PrimaryColor.color,
    },
    '& .MuiInputLabel-root.Mui-focused': {
        color: styles.PrimaryColor.color,
    },
    "& .MuiOutlinedInput-root": {
        "& fieldset": {
            borderColor: styles.PrimaryColor.color,
        },
        "&:hover fieldset": {
            borderColor: styles.PrimaryColor.color,
        },
        "&.Mui-focused fieldset": {
            borderColor: styles.PrimaryColor.color,
        },
        "& .MuiSvgIcon-root": {
            color: styles.PrimaryColor.color,
        },
    },
});

export default CustomDatePicker;