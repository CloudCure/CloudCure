import { UserProfile } from "./UserProfile";
export interface EmployeeInformation {
    
    UserProfile : UserProfile
    WorkEmail: string | undefined
    Specialization: string
    StartDate: string | Date
    RoomNumber: string
    EducationDegree: string
    user?: UserProfile
}