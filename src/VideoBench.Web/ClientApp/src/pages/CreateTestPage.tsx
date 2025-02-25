import { useEffect, useState } from "react";
import { Category } from "../models/Category";
import { Bitrate } from "../models/Bitrate";
import { Box, Button, Checkbox, Dialog, DialogActions, DialogContent, DialogTitle, Divider, FormControlLabel, IconButton } from "@mui/material";
import { CustomDarkTextField, CustomNumberField, CustomTextField } from "../components/TextField";
import { styles } from "../styles/styles";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import CustomDatePicker from "../components/DatePicker";
import { CustomButton } from "../components/Buttons";
import AddIcon from '@mui/icons-material/Add';
import ClearIcon from '@mui/icons-material/Clear';
import CheckIcon from '@mui/icons-material/Check';
import { getCategories, postCategory, postTest } from "../services/VideoTestService";
import Loader from "../components/Loader";
import { Dayjs } from "dayjs";
import { VideoTest } from "../models/VideoTest";

const CreateTestPage = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [selectedCategories, setSelectedCategories] = useState<Set<string>>(new Set());
  const [startTime, setStartTime] = useState<Dayjs | null>(null);
  const [endTime, setEndTime] = useState<Dayjs | null>(null);
  const [samplesNumber, setSamplesNumber] = useState<number>(0);
  const [qualityId, setQualityId] = useState<number>(1);
  const [bitrateValues, setBitrateValues] = useState<Bitrate[]>([{ value: 0 }]); // Początkowa wartość bitrate
  const [loading, setLoading] = useState(true);
  const [isCategoryDialogOpen, setCategoryDialogOpen] = useState(false);
  const [newCategory, setNewCategory] = useState('');


  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await getCategories();
        setCategories(response);
      } catch (error) {
        //console.error(error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleCategoryChange = (categoryId: string) => {
    setSelectedCategories((prevSelected) => {
      const newSelected = new Set(prevSelected);
      if (newSelected.has(categoryId)) {
        newSelected.delete(categoryId);
      } else {
        newSelected.add(categoryId);
      }
      return newSelected;
    });
  };

  const handleAddCategory = async (categoryName: string) => {
    try {
      const response = await postCategory(categoryName);
      setCategories((prev) => [...prev, response]);
      setNewCategory('');
    } catch (error) {
      //console.error(error);
    }
  };

  const handleAddBitrate = () => {
    setBitrateValues((prevValues) => [...prevValues, { value: 0 }]);
  };

  const handleRemoveBitrate = () => {
    setBitrateValues((prevValues) => {
      if (prevValues.length > 1) {
        return prevValues.slice(0, -1);
      }
      return prevValues;
    });
  };

  const handleBitrateChange = (index: number, value: number) => {
    const updatedBitrates = [...bitrateValues];
    updatedBitrates[index].value = value;
    setBitrateValues(updatedBitrates);
  };

  const handleDialogClose = () => {
    setCategoryDialogOpen(false);
    console.log(selectedCategories)
  };

  const handleConfirm = async () => {
    if (startTime != null && endTime != null && samplesNumber != null) {
      const selected: Category[] = Array.from(selectedCategories).map(id => ({
        id: id,
        name: ''
      }))
      const videoTest: VideoTest = {
        id: null,
        startTime: startTime.format('YYYY-MM-DDTHH:mm:ss'),
        endTime: endTime.format('YYYY-MM-DDTHH:mm:ss'),
        qualityId: qualityId,
        samplesNumber: samplesNumber,
        bitrateValues: bitrateValues,
        categories: selected
      }

      const response = await postTest(videoTest);
    }
  };

  if (loading) {
    return (<Loader />)
  }

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Box alignItems='center' display='block'>
        <h5>Create new test</h5>
        <Box textAlign='left' fontSize={'20px'}>

          <CustomDatePicker label='Start Date' value={startTime} onChange={setStartTime} sx={{ marginBottom: 2 }} />
          <br />

          <CustomDatePicker label='End Date' value={endTime} onChange={setEndTime} sx={{ marginBottom: 2 }} />
          <br />

          <CustomDarkTextField defaultValue='Select Categories' onClick={() => setCategoryDialogOpen(true)} sx={{ marginBottom: 2 }} InputProps={{ readOnly: true }} />
          <br />

          <CustomNumberField
            label='Samples Number'
            type="number"
            sx={{ marginBottom: 2 }}
          >
            value={samplesNumber}
          </CustomNumberField>

          <Divider sx={{ marginBottom: 2, borderColor: styles.PrimaryColor.color }} />

          {bitrateValues.map((bitrate, index) => (
            <Box key={index} >
              <CustomNumberField
                label='Bitrate Value'
                type="number"
                onChange={(e) => handleBitrateChange(index, Number(e.target.value))}
                sx={{ marginBottom: 2 }}
              >
                {bitrate.value !== 0 ? bitrate.value : ''}
              </CustomNumberField>
            </Box>
          ))}

          <Box display='flex' justifyContent='center' sx={{ marginBottom: 2 }}>
            <CustomButton onClick={handleAddBitrate}>
              Add
              <AddIcon color='success' />
            </CustomButton>
            <CustomButton onClick={handleRemoveBitrate}>
              Remove
              <ClearIcon color='error' />
            </CustomButton>
          </Box>
          <br />

          <CustomButton fullWidth variant='outlined' onClick={handleConfirm}>
            Confirm
            <CheckIcon />
          </CustomButton>

        </Box>
      </Box>

      <Dialog open={isCategoryDialogOpen} onClose={handleDialogClose}>
        <DialogTitle>Select Categories</DialogTitle>
        <DialogContent>
          <Box display="flex" flexDirection="column">
            {categories.map((category) => (
              <FormControlLabel
                key={category.id}
                control={
                  <Checkbox
                    sx={{
                      color: styles.PrimaryColor.color,
                      '&.Mui-checked': {
                        color: styles.PrimaryColor.color,
                      },
                    }}
                    checked={selectedCategories.has(category.id)}
                    onChange={() => handleCategoryChange(category.id)}
                  />
                }
                label={category.name}
              />
            ))}
          </Box>
          <br />
          <Box display="flex" >
            <CustomTextField
              label="Add New Category"
              value={newCategory}
              onChange={(e) => setNewCategory(e.target.value)}
            />
            <IconButton onClick={() => handleAddCategory(newCategory)} color="success" aria-label="add category">
              <AddIcon />
            </IconButton>
          </Box>

        </DialogContent>
        <DialogActions>
          <Button onClick={handleDialogClose} sx={{ color: styles.PrimaryColor.color }}>
            Done
            <CheckIcon />
          </Button>
        </DialogActions>
      </Dialog>
    </LocalizationProvider>
  );
};

export default CreateTestPage;