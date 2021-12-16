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
    UserProfile:         UserProfile;
    PatientName?:         string;
    PatientPhone?:        string;
    PatientAddress?:      string;
    DateOfBirth?:        Date;
    Conditions?:         Condition[];
    Allergies?:          Allergy[];
    Surgeries?:          Surgery[];
    CurrentMedications?: Medication[];
    VitalHistory?:       Vitals[];
    Assessments?:        Assessment[];
}
