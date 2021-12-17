export interface Assessment {
  AssessmentId?: number;
  PatientId?: number;
  ChiefComplaint: string;
  HistOfPresentIllness: string;
  PainAssessment?: string;
  PainScale?: number;
}
