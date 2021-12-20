export interface Vitals
{
    VitalsId?:       number;
    PatientId:       number;
    Systolic:        number;
    Diastolic:       number;
    OxygenSat:       number;
    HeartRate:       number;
    Tempature:     number;
    RespiratoryRate: number;
    Height:          number;
    Weight:          number;
    EncounterDate?:  Date;
}