import { Category } from "./Category"

export interface SurveyResponse {
    id: string
    username: string
    deviceType: number
    categories: Category[]
}