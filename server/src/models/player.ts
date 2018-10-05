import * as shortid from 'shortid';
export class Player {
    public position: any = {
        x: "0",
        y: "0",
        z: "0"
    }
    public playerInput: any = {
        horizontal: "0",
        vertical: "0"
    }
    constructor (
        public id: string,
        public health: number,
        public moveSpeed: number,
    ) {
        this.id = id;
        this.health = health;
        this.moveSpeed = moveSpeed;
        this.moveSpeed = Math.floor(Math.random() * 6) + 1;
        this.position.x = Math.floor(Math.random() * 6) + 1;
        this.position.z = Math.floor(Math.random() * 6) + 1;
    }

    static generate () {
        return new Player(
            shortid.generate(), //id
            100, //hp
            5, //moveSpeed
        );
    }
}
