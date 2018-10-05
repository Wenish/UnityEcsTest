import { EntityMap } from 'colyseus';
import { Player } from '../../models/player';

export class State {
    players: EntityMap<Player> = {};
    counter: number = 0;
    messages: EntityMap<string> = {};
    constructor () {
        //Do here some init stuff;
        var player1 = Player.generate();
        this.players["53g34g4"] = Player.generate();
        var player2 = Player.generate();
        this.players["thg433g"] = Player.generate();
        var player3 = Player.generate();
        this.players["34gergr"] = Player.generate();
        console.log(this.players);
    };

    addPlayer (client) {
        this.players[client.id] = new Player(client.id, 100, 6);
        console.log('added player');
    };


    removePlayer (client) {
        delete this.players[client.id]
        console.log('removed player');
    };

    increaseCounter () {
        this.counter++;
    };

    addMessage (){

    };

    calculateState () {
        this.increaseCounter();
    };
};
