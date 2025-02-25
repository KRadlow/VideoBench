import { Category } from "./Category";
import { Bitrate } from "./Bitrate";
import { UUID } from "crypto";

export interface VideoTest {
    id: UUID | null,
    startTime: string,
    endTime: string,
    qualityId: number,
    samplesNumber: number,
    bitrateValues: Bitrate[],
    categories: Category[]
}