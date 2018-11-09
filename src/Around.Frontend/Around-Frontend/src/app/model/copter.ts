import { CopterDto } from '../interface/copter-dto';

export class Copter {
    constructor(
        public id: number,
        public name: string,
        public status: string,
        public latidude: string,
        public longitude: string,
        public costPerMinute: number,
        public brandName: string,
        public maxSpeed: number,
        public maxFlightHeight: number,
        public control: string,
        public droneType: string) {
    }
    public static Create(dto: CopterDto): Copter {
        return new Copter(dto.id, dto.name, dto.status,
            dto.latidude, dto.longitude, dto.costPerMinute,
            dto.brandName, dto.maxSpeed, dto.maxFlightHeight,
            dto.control, dto.droneType);
    }
}
