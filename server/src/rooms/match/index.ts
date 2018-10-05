import { Room } from 'colyseus';
import { State } from './state'

export class Match extends Room {

    maxClients = 10;

    onInit (options) {
        this.setState(new State);
        this.setPatchRate( 1000 / 20);
        this.setSimulationInterval(this.update.bind(this));

        console.log("Match room created!", options);
    };

    //When a client try to joins the room
    //If true client joins the room
    requestJoin(options) {
        console.log("request join!", options);

        return this.clients.length < this.maxClients
    };

    //When a client joins the room
    onJoin (client) {
        this.state.addPlayer(client)
        console.log(`${ client.id } joined match room.`)
    };

    //When a client leaves the room
    onLeave (client) {
        this.state.removePlayer(client)
        console.log(`${ client.id } left match room.`)
    };

    //When a client send a message
    onMessage (client, data) {
        console.log("MatchRoom:", client.id, data)
    };

    //Cleanup callback, called after there are no more clients on the room
    onDispose () {
        console.log("Dispose match Room")
    };

    update () {
        this.state.calculateState()
    };
};
