export interface UserProfile {

    firstName : string
    lastName : string
    dateOfBirth: string | Date
    phoneNumber : string 
    address : string
    emergencyName: string
    emergencyContactPhone: string 
    roleId : number
    id? : number
}