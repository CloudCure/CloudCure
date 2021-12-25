export interface Assessment {
  id?: number;
  diagnosisId: number;
  chiefComplaint?: string;
  historyOfPresentIllness?: string;
  painAssessment?: string;
  painScale?: number;
  encounterDate?: Date;
}
