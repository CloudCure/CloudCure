import { Assessment } from "./Assessment";
import { Patient } from "./Patient";
import { Vitals } from "./Vitals";

export interface Diagnosis
{
    id?: number;
    assessment: Assessment
    patient: Patient
    doctorDiagnosis: string
    isFinalized: boolean
    recommendedTreatment: string
    vitals: Vitals

}