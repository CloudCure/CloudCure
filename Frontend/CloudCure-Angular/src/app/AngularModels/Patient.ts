import { Allergy } from "./Allergy";
import { Assessment } from "./Assessment";
import { Condition } from "./Condition";
import { Medication } from "./Medication";
import { Surgery } from "./Surgery";
import { Vitals } from "./Vitals";
import { UserProfile } from "./UserProfile";
import { EmployeeInformation } from "./EmployeeInformation";
import { Diagnosis } from "./Diagnosis";

export interface Patient 
{
    id?:                 number;
    userProfile:         UserProfile;
    patientName?:         string;
    patientPhone?:        string;
    patientAddress?:      string;
    dateOfBirth?:        Date;
    conditions?:         Condition[];
    allergies?:          Allergy[];
    surgeries?:          Surgery[];
    currentMedications?: Medication[];
    doctor?: EmployeeInformation | undefined;
    diagnoses?: Diagnosis[];
}
