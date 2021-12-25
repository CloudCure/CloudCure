export interface UserProfile {
    id? : number
    firstName : string
    lastName : string
    dateOfBirth: string | Date
    phoneNumber : string 
    address : string
    emergencyName: string
    emergencyContactPhone: string 
    roleId : number
}
