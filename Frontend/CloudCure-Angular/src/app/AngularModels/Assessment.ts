export interface Assessment {
  AssessmentId?: number;
  PatientId: number;
  ChiefComplaint: string;
  HistoryOfPresentIllness: string;
  PainAssessment?: string;
  PainScale?: number;
}
