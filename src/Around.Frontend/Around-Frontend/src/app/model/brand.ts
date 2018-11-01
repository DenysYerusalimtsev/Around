import { BrandDto } from '../interface/brand-dto';

export class Brand {
    constructor(
        public id: number,
        public name: string,
        public country: string) {
        }

    public static Create(dto: BrandDto): Brand {
        return new Brand(dto.id, dto.name, dto.country);
    }
}
