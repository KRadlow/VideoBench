import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Loader from "../components/Loader";
import { getVideo, rateVideo } from "../services/VideoTestService";
import { Box } from "@mui/material";
import { CustomButton } from "../components/Buttons";
import ArrowRightIcon from '@mui/icons-material/ArrowRight';
import ArrowLeftIcon from '@mui/icons-material/ArrowLeft';
import UndoIcon from '@mui/icons-material/Undo';
import { styles } from "../styles/styles";

const navigate = (path: string) => {
  window.location.href = `${path}`
}

const SurveyPage = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const surveyId = queryParams.get('surveyId');

  const [loading, setLoading] = useState(true);
  const [finished, setFinished] = useState(false);
  const [showRate, setShowRate] = useState(false);
  const [link, setLink] = useState<string>('');
  const [rate, setRate] = useState<number>(0);
  const [retry, setRetry] = useState(false);

  useEffect(() => {
    const fetchVideo = async () => {
      try {
        const response = await getVideo(surveyId!);
        setLink(response);

      } catch (error: any) {
        //console.log(error);
        setFinished(true);
      } finally {
        setLoading(false);
      }
    };
    fetchVideo();
  }, [retry]);

  const handleRateVideo = async () => {
    try {
      if (surveyId != null) {
        const response = await rateVideo(surveyId, rate);
      }
      setRetry(!retry);
      setShowRate(false);
      setRate(0);
    } catch (error) {
      //console.error(error);
    }
  };

  if (loading) {
    return (<Loader />)
  }

  if (finished) {
    return (
      <Box alignItems="center">
        <h5>Thank you</h5>
        <h6>The test has ended</h6>
        <CustomButton variant='outlined' onClick={() => navigate('/')}>
          <UndoIcon />
          <span>Back</span>
        </CustomButton>
      </Box>
    )
  }

  return (
    <Box display="flex" alignItems="center">
      {!showRate ? (
        <Box>
          <Box >
            <video controls autoPlay src={link} width='65%' ></video>
          </Box>
          <Box>
            <CustomButton onClick={() => setShowRate(true)} sx={{ marginTop: '10px' }}>
              Next
              <ArrowRightIcon />
            </CustomButton>
          </Box>
        </Box>
      ) : (
        <Box>
          <Box sx={{ marginBottom: 2 }}>
            Rate Video Quality:
          </Box>
          <br />
          <Box sx={{ marginBottom: 2 }}>
            <CustomButton
              variant='outlined'
              fullWidth
              sx={{
                color: rate === 5 ? styles.SecondaryColor.color : 'blue',
                backgroundColor: rate === 5 ? styles.PrimaryColor.color : 'transparent'
              }}
              onClick={() => setRate(5)}
            >
              Excellent
            </CustomButton>
          </Box>
          <Box sx={{ marginBottom: 2 }}>
            <CustomButton
              variant='outlined'
              fullWidth
              sx={{
                color: rate === 4 ? styles.SecondaryColor.color : 'green',
                backgroundColor: rate === 4 ? styles.PrimaryColor.color : 'transparent'
              }}
              onClick={() => setRate(4)}
            >
              Good
            </CustomButton>
          </Box>
          <Box sx={{ marginBottom: 2 }}>
            <CustomButton
              variant='outlined'
              fullWidth
              sx={{
                color: rate === 3 ? styles.SecondaryColor.color : 'yellow',
                backgroundColor: rate === 3 ? styles.PrimaryColor.color : 'transparent'
              }}
              onClick={() => setRate(3)}
            >
              Fair
            </CustomButton>
          </Box>
          <Box sx={{ marginBottom: 2 }}>
            <CustomButton
              variant='outlined'
              fullWidth
              sx={{
                color: rate === 2 ? styles.SecondaryColor.color : 'orange',
                backgroundColor: rate === 2 ? styles.PrimaryColor.color : 'transparent'
              }}
              onClick={() => setRate(2)}
            >
              Poor
            </CustomButton>
          </Box>
          <Box sx={{ marginBottom: 2 }}>
            <CustomButton
              variant='outlined'
              fullWidth
              sx={{
                color: rate === 1 ? styles.SecondaryColor.color : 'red',
                backgroundColor: rate === 1 ? styles.PrimaryColor.color : 'transparent'
              }}
              onClick={() => setRate(1)}
            >
              Bad
            </CustomButton>
          </Box>
          <br />
          <Box justifyContent='center'>
            <CustomButton onClick={() => setShowRate(false)} sx={{ justifyContent: 'center', alignItems: 'center' }}>
              <ArrowLeftIcon />
              Back
            </CustomButton>
            <CustomButton onClick={handleRateVideo} sx={{ justifyContent: 'center', alignItems: 'center' }}>
              Next
              <ArrowRightIcon />
            </CustomButton>
          </Box>
        </Box>
      )}
    </Box>
  );
};

export default SurveyPage;