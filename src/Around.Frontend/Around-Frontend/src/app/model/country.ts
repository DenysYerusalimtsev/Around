import { CountryDto } from '../interface/country-dto';

export class Country {
    constructor(
        public id: number,
        public name: string) {
    }
    public static Create(dto: CountryDto): Country {
        return new Country(dto.id, dto.name);
    }
}
