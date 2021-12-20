import { Allergy } from "./Allergy";
import { Assessment } from "./Assessment";
import { Condition } from "./Condition";
import { Medication } from "./Medication";
import { Surgery } from "./Surgery";
import { Vitals } from "./Vitals";
import { UserProfile } from "./UserProfile";

export interface Patient 
{
    PatientId?:          number;
    userProfile:         UserProfile;
    PatientName?:         string;
    PatientPhone?:        string;
    PatientAddress?:      string;
    DateOfBirth?:        Date;
    conditions?:         Condition;
    allergies?:          Allergy[];
    surgeries?:          Surgery[];
    currentMedications?: Medication[];
    vitalHistory?:       Vitals[];
    assessments?:        Assessment[];
}
