import { Category } from "./Category"

export interface Survey {
    username: string
    deviceType: number
    categories: Category[]
}