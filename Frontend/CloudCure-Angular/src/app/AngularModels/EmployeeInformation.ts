import { UserProfile } from "./UserProfile";
export interface EmployeeInformation {
    id? : number | undefined;
    userProfile : UserProfile
    workEmail: string | undefined
    specialization: string
    startDate: string | Date |undefined
    roomNumber: string
    educationDegree: string
}