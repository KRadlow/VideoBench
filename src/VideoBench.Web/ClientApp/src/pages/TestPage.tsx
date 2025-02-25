import { useEffect, useState } from "react";
import Loader from "../components/Loader";
import { Box, Checkbox, FormControlLabel, FormGroup } from "@mui/material";
import { useLocation } from "react-router-dom";
import { getTest, postSurvey } from "../services/VideoTestService";
import { Category } from "../models/Category";
import { styles } from "../styles/styles";
import { CustomButton } from "../components/Buttons";
import { isMobile } from 'react-device-detect';
import { Survey } from "../models/Survey";
import UndoIcon from '@mui/icons-material/Undo';
import { CustomTextField } from "../components/TextField";

const navigate = (path: string) => {
  window.location.href = `${path}`
}

const TestPage = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const testId = queryParams.get('code');

  const [finished, setFinished] = useState(false);
  const [found, setFound] = useState(false);
  const [loading, setLoading] = useState(true);
  const [username, setUserName] = useState<string>("");
  const [categories, setCategories] = useState<Category[]>([]);
  const [selectedCategories, setSelectedCategories] = useState<string[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await getTest(testId!);
        setFound(true);
        setCategories(response.categories)

        let currentDate = new Date();
        let endTestDate = new Date(response.endTime);
        if (endTestDate < currentDate) {
          setFinished(true);
        }

      } catch (error: any) {
        //console.log(error);
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, []);


  const handleStartClick = async () => {
    setLoading(true);
    try {
      let device: number;
      if (isMobile)
        device = 1
      else
        device = 0

      if (username && selectedCategories.length !== 0) {
        const payload: Survey = {
          username: username,
          deviceType: device,
          categories: getSelectedCategories(),
        };
        const response = await postSurvey(testId!, payload);
        navigate(`/survey?surveyId=${encodeURIComponent(response.id)}`);
      }
    } catch (error) {
      //console.error(error);
    } finally {
      setLoading(false);
    }
  };

  const handleCategoryChange = (categoryId: string) => {
    setSelectedCategories((prevSelectedCategories) =>
      prevSelectedCategories.includes(categoryId)
        ? prevSelectedCategories.filter((id) => id !== categoryId)
        : [...prevSelectedCategories, categoryId]
    );
  };

  const getSelectedCategories = (): Category[] => {
    return categories.filter((category) => selectedCategories.includes(category.id));
  };


  if (loading) {
    return (<Loader />)
  }

  if (!found) {
    return (
      <Box alignItems="center">
        <h5>Test not found</h5>
        <CustomButton variant='outlined' onClick={() => navigate('/')}>
          <UndoIcon />
          <span>Back</span>
        </CustomButton>
      </Box>
    )
  }

  if (finished) {
    return (
      <Box alignItems="center">
        <h5>The test has ended</h5>
        <CustomButton variant='outlined' onClick={() => navigate('/')}>
          <UndoIcon />
          <span>Back</span>
        </CustomButton>
      </Box>
    )
  }

  return (
    <Box alignItems="center">
      <h5>Enter name:</h5>
      <CustomTextField
        variant="outlined"
        placeholder='Username'
        autoComplete='off'
        autoCorrect='off'
        value={username}
        onChange={(e) => setUserName(e.target.value)}
      />

      <h5>Select categories:</h5>
      <FormGroup>
        {categories.map((category) => (
          <FormControlLabel
            key={category.name}
            control={
              <Checkbox
                sx={{
                  color: styles.PrimaryColor.color,
                  '&.Mui-checked': {
                    color: styles.PrimaryColor.color,
                  },
                }}
                checked={selectedCategories.includes(category.id)}
                onChange={() => handleCategoryChange(category.id)}
              />
            }
            label={category.name}
          />
        ))}
      </FormGroup>
      <br />

      <CustomButton
        fullWidth
        variant='outlined'
        onClick={handleStartClick}
      >
        Start
      </CustomButton>

    </Box>
  );
};

export default TestPage;