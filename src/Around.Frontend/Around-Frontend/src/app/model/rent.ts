import { RentDto } from '../interface/rent-dto';

export class Rent {
    constructor(
        public id: number,
        public clientName: string,
        public copterBrand: string,
        public copterName: string,
        public startTime: Date,
        public finishTime: Date) {
    }
    public static Create(dto: RentDto): Rent {
        return new Rent(dto.id, dto.clientName, dto.copterBrand,
            dto.copterName, dto.startTime, dto.finishTime);
    }
}
