import { RentDto } from '../interface/rent-dto';

export class Rent {
    constructor(
    id: number,
    clientName: string,
    copterBrand: string,
    copterName: string,
    startTime: Date,
    finishTime: Date) {
    }
    public static Create(dto: RentDto): Rent {
        return new Rent(dto.id, dto.clientName, dto.copterBrand,
            dto.copterName, dto.startTime, dto.finishTime);
    }
}
