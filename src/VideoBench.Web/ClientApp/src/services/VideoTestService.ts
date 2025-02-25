import { VideoTest } from "../models/VideoTest";
import HttpService from "./HttpService";
import { Survey } from "../models/Survey";
import { SurveyResponse } from "../models/SurveyResponse"
import { Category } from "../models/Category";

const apiClient = HttpService.getClient();

const GET_TEST_ADDRESS = '/api/videotest';
const POST_SURVEY_ADDRESS = 'api/videotest'
const CATEGORY_ADDRESS = '/api/category'
const SURVEY_ADDRESS = '/api/videotest/survey'

export const getTest = async (testId: string): Promise<VideoTest> => {
  try {
    const response = await apiClient.get(`${GET_TEST_ADDRESS}/${testId}`);
    if (response.status !== 200) {
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}

export const postTest = async (test: VideoTest): Promise<VideoTest> => {
  try {
    const response = await apiClient.post(`${GET_TEST_ADDRESS}`, test);
    if (response.status !== 200) {
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}

export const getCategories = async (): Promise<Category[]> => {
  try {
    const response = await apiClient.get(`${CATEGORY_ADDRESS}`);
    if (response.status !== 200) {
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}

export const postCategory = async (categoryName: string): Promise<Category> => {
  const url = `${CATEGORY_ADDRESS}?categoryName=${encodeURIComponent(categoryName)}`
  try {
    const response = await apiClient.post(url);
    if (response.status !== 200) {
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}

export const postSurvey = async (testId: string, survey: Survey): Promise<SurveyResponse> => {
  try {
    const response = await apiClient.post(`${POST_SURVEY_ADDRESS}/${testId}/survey`, survey);

    if (response.status !== 200) {

      console.log(response.status)
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}

export const getVideo = async (surveyId: string): Promise<string> => {
  const url = `${SURVEY_ADDRESS}/${surveyId}`
  try {
    const response = await apiClient.get(url);
    if (response.status !== 200) {
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}

export const rateVideo = async (surveyId: string, score: number): Promise<string> => {
  const url = `${SURVEY_ADDRESS}/${surveyId}?score=${score}`
  try {
    const response = await apiClient.post(url);
    if (response.status !== 200) {
      throw new Error(response.status.toString());
    }

    return response.data;
  } catch (error) {
    //console.log(error)
    throw error
  }
}