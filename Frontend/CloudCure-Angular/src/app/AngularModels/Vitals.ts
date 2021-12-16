export interface Vitals
{
    VitalsId?:       number;
    PatientId:       number;
    Systolic:        number;
    Diastolic:       number;
    OxygenSat:       number;
    HeartRate:       number;
    Temperature:     number;
    RespiratoryRate: number;
    Height:          number;
    Weight:          number;
    EncounterDate?:  Date;
}