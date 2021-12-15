import { UserProfile } from "./UserProfile";
export interface EmployeeInformation {
    UserProfileId?: number | undefined;
    WorkEmail: string | undefined
    Specialization: string
    StartDate: string | Date
    RoomNumber: string
    EducationDegree: string
    user?: UserProfile
}