export interface Vitals
{
    VitalsId?:       number;
    id?:                any;
    PatientId:       number;
    systolic:        number;
    diastolic:       number;
    oxygenSat:       number;
    heartRate:       number;
    temperature:     number;
    respiratoryRate: number;
    height:          number;
    weight:          number;
    encounterDate?:  Date;
}