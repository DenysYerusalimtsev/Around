import { ChequeDto } from '../interface/cheque-dto';

export class Cheque {
    constructor(
        public id: number,
        public clientName: string,
        public copterBrand: string,
        public copterName: string,
        public startTime: Date,
        public finishTime: Date,
        public dateOfCreation: Date,
        public totalPrice: number) {
        }

    public static Create(dto: ChequeDto): Cheque {
        return new Cheque(dto.id, dto.clientName, dto.copterBrand,
            dto.copterName, dto.startTime, dto.finishTime, dto.dateOfCreation,
            dto.totalPrice);
    }
}
