import { CopterDto } from '../interface/copter-dto';

export class Copter {
    constructor(
    id: number,
    name: string,
    brandName: string,
    maxSpeed: number,
    maxFlightHeight: number,
    control: string,
    droneType: string) {
    }
    public static Create(dto: CopterDto): Copter {
        return new Copter(dto.id, dto.name, dto.brandName,
            dto.maxSpeed, dto.maxFlightHeight, dto.control,
            dto.droneType);
    }
}
