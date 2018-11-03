import { ChequeDto } from '../interface/cheque-dto';

export class Cheque {
    constructor(
        id: number,
        clientName: string,
        copterBrand: string,
        copterName: string,
        startTime: Date,
        finishTime: Date,
        dateOfCreation: Date,
        totalPrice: number) {
        }

    public static Create(dto: ChequeDto): Cheque {
        return new Cheque(dto.id, dto.clientName, dto.copterBrand,
            dto.copterName, dto.startTime, dto.finishTime, dto.dateOfCreation,
            dto.totalPrice);
    }
}
