import { EntityMap } from 'colyseus';
import { Player } from '../../models/player';

export class State {
    players: EntityMap<Player> = {};
    counter: number = 0;
    messages: EntityMap<string> = {};
    constructor () {
        //Do here some init stuff;
        var player1 = Player.generate();
        this.players[player1.id] = player1;
        var player2 = Player.generate();
        this.players[player2.id] = player2;
        var player3 = Player.generate();
        this.players[player3.id] = player3;
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
