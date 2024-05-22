import { Room, Client } from "colyseus";
import { Schema, type, MapSchema } from "@colyseus/schema";

export class Player extends Schema {
    @type("string") l = "";
    @type("uint8") f = 0;
    @type("uint8") c = 0;
}

export class State extends Schema {
    @type({ map: Player })
    players = new MapSchema<Player>();

    something = "This attribute won't be sent to the client-side";

    createPlayer(sessionId: string, login, fraction, clan) {
        const player = new Player();
        player.l = login;
        player.f = fraction;
        player.c = clan;
        this.players.set(sessionId, player);
    }

    removePlayer(sessionId: string) {
        this.players.delete(sessionId);
    }
}

export class StateHandlerRoom extends Room<State> {
    maxClients = 2;

    onCreate (options) {
        console.log("StateHandlerRoom created!", options);

        this.setState(new State());
    }

    onAuth(client, options, req) {
        return true;
    }

    onJoin (client: Client, data) {
        console.log("Player joined", client.sessionId, ":", data);
        this.state.createPlayer(client.sessionId, data.login, data.fraction, data.clan);
    }

    onLeave (client) {
        this.state.removePlayer(client.sessionId);
    }

    onDispose () {
        console.log("Dispose StateHandlerRoom");
    }

}
