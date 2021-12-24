export interface Vitals
{
    VitalsId?:       number;
    id?:                any;
    patientId:       number;
    diagnosisId: number;
    systolic?:        number;
    diastolic?:       number;
    oxygenSat?:       number;
    heartRate?:       number;
    temperature?:     number;
    respiratoryRate?: number;
    height?:          number;
    weight?:          number;
    encounterDate?:  Date;
}