import { Assessment } from "./Assessment";
import { Patient } from "./Patient";
import { Vitals } from "./Vitals";

export interface Diagnosis
{
    id: number
    patientId?: number
    vitals?: Vitals
    assessment?: Assessment
    doctorDiagnosis?: string
    recommendedTreatment?: string
    isFinalized: boolean
    encounterDate: Date
}