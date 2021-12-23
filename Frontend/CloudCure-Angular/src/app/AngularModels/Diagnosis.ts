import { Assessment } from "./Assessment";
import { Patient } from "./Patient";
import { Vitals } from "./Vitals";

export interface Diagnosis
{
    id?: number
    EncounterDate?: Date
    Patient?: Patient
    vitals?: Vitals
    Assessment?: Assessment
    DoctorDiagnosis?: String
    RecommendedTreatment?: String
    IsFinalized?: Boolean

}