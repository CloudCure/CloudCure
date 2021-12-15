import { UserProfile } from "./UserProfile";
export interface EmployeeInformation {
    UserId?: number
    WorkEmail: string | undefined
    Specialization: string
    StartDate: string | Date
    RoomNumber: string
    EducationDegree: string
    user: UserProfile
}