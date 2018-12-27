import { RentDto } from '../interface/rent-dto';

export class Rent {
    constructor(
        public id: number,
        public clientId: number,
        public copterId: number,
        public startTime: Date) {
    }
    public static Create(dto: RentDto): Rent {
        return new Rent(dto.id, dto.clientId, dto.copterId,
             dto.startTime);
    }
}
