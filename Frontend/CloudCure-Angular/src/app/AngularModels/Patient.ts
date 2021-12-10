import { Allgergy } from "./Allergy";
import { Assessment } from "./Assessment";
import { Condition } from "./Condition";
import { Medication } from "./Medication";
import { Surgery } from "./Surgery";
import { Vitals } from "./Vitals";

export interface Patient 
{
    PatientId?:          number;
    Conditions?:         Condition[];
    Allergies?:          Allgergy[];
    Surgeries?:          Surgery[];
    CurrentMedications?: Medication[];
    VitalHistory?:       Vitals[];
    Assessments?:        Assessment[];
}
