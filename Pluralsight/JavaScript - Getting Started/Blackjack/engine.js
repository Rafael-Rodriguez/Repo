export default class Engine {
    constructor()
    {
        this.suits = ['Hearts', 'Diamonds', 'Clubs', 'Spades'];
    
        this.values = ['Ace', 'King', 'Queen', 'Jack', 
        '10', '9', '8', '7', '6', '5', '4', '3', '2', '1'];

        this.textArea = this.$('textArea');
        this.buttonNewGame = this.$('buttonNewGame');
        this.buttonHit = this.$('buttonHit');
        this.buttonStay = this.$('buttonStay');

        this.gameStarted = false;
        this.gameOver = false;
        this.playerWon = false;
        this.dealerCards = [];
        this.playerCards = [];
        this.dealerScore = 0;
        this.playerScore = 0;
        this.deck = [];
    }
    

    run()
    {
        console.log("run:  in run")
        
        this.buttonHit.style.display = 'none';

        console.log("typeof(buttonHit)" + typeof(this.buttonHit));
    }

    $(id) 
    {
        if(typeof id != "string")
        {
            console.log("typeof(id)" + typeof(id));
            throw Error('Invalid argument ' + id + ' passed into $ function');
        }
    
        return document.getElementById(id);
    }
    
}