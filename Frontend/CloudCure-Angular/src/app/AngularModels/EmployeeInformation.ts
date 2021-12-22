import { UserProfile } from "./UserProfile";
export interface EmployeeInformation {
    id? : number | undefined;
    userProfile : UserProfile
    workEmail: string | undefined
    specialization: string
    startDate: string | Date
    roomNumber: string
    educationDegree: string
}