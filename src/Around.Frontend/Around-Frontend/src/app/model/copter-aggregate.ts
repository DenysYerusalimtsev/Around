export class CopterAggregate {
    constructor(
        public name: string,
        public status: number,
        public latitude: number,
        public longitude: number,
        public costPerMinute: number,
        public brandId: number,
        public maxSpeed: number,
        public maxFlightHeight: number,
        public control: number,
        public droneType: number) {
    }
}
