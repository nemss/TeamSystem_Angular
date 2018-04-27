export class PlayersModel {
    id: number;
    firstName: string;
    secondName: string;
    lastName: string;
    role: string;
}

export class PersonModel {
    id: number;
    ucn: number;
    firstName: string;
    secondName: string;
    lastName: string;
    birthDate: Date;
    teamName: string;
    teamId: number;
    modelRoleName: string;
    modelRoleId: number;
    isReserved: boolean;
}