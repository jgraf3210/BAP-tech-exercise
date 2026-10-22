export interface Person {
  id: number;
  name: string;
  astronautDetail: AstronautDetail;
  astronautDuty: AstronautDuty;  
}

export interface AstronautDetail {
  id: number;
  personId: number;
  currentRank: string;
  currentDutyTitle: string;
  careerStartDate: Date;
  careerEndDate: Date;
  person:Person;
}

export interface AstronautDuty {
  id: number;
  personId: number;
  rank: string;
  dutyTitle: string;
  dutyStartDate: Date;
  dutyEndDate: Date | null;
  person: Person;
}

