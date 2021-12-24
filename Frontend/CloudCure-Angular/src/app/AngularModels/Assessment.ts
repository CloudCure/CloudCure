export interface Assessment {
  id?: number;
  patientId: number;
  diagnosisId: number;
  chiefComplaint?: string;
  historyOfPresentIllness?: string;
  painAssessment?: string;
  painScale?: number;
  encounterDate?: Date;
  /*
  AssessmentId?: number;
  PatientId: number;
  ChiefComplaint: string;
  HistoryOfPresentIllness: string;
  PainAssessment?: string;
  PainScale?: number;
  */
}
