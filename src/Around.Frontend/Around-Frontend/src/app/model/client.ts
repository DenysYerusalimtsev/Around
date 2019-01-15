import { ClientDto } from '../interface/client-dto';

export class Client {
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public email: string,
        public password: string,
        public phoneNumber: string,
        public passportNumber: string,
        public сreditCardNumber: string,
        public discountPercentage: number,
        public token: any) {
    }
    public static Create(dto: ClientDto): Client {
        return new Client(dto.id, dto.firstName, dto.lastName, dto.email, dto.password,
            dto.phoneNumber, dto.passportNumber, dto.сreditCardNumber,
            dto.discountPercentage, dto.token);
    }
}
