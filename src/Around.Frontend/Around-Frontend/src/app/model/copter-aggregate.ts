export class CopterAggregate {
    constructor(
        public id: number,
        public name: string,
        public status: string,
        public latitude: string,
        public longitude: string,
        public costPerMinute: number,
        public brandName: string,
        public maxSpeed: number,
        public maxFlightHeight: number,
        public control: string,
        public droneType: string) {
    }
}
