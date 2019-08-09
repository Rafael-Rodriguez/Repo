export default class Engine {
    constructor()
    {
        this.suits = ['Hearts', 'Diamonds', 'Clubs', 'Spades'];
    
        this.values = ['Ace', 'King', 'Queen', 'Jack', 
        '10', '9', '8', '7', '6', '5', '4', '3', '2'];

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
        this.buttonStay.style.display = 'none';
        this.showStatus();

        this.initializeEventListeners();
    }

    onNewGameClicked()
    {
        this.gameStarted = true;
        this.gameOver = false;
        this.playerWon = false;

        this.buttonHit.style.display = 'inline';
        this.buttonStay.style.display = 'inline';
        this.buttonNewGame.style.display = 'none';

        this.deck = this.createDeck();
        this.shuffleDeck(this.deck);
        this.dealerCards = [this.getNextCard(), this.getNextCard()];
        this.playerCards = [this.getNextCard(), this.getNextCard()];

        this.showStatus();
    }

    onHitClicked()
    {
        this.playerCards.push(this.getNextCard());
        this.checkForEndOfGame();
        this.showStatus();
    }

    onStayClicked()
    {
        this.gameOver = true;
        this.checkForEndOfGame();
        this.showStatus();
    }

    initializeEventListeners()
    {
        //Use the 'arrow function' to set the callback method
        //Versus using an anonymous or function callback
        //"While anonymous (and all traditional JavaScript functions) create their own this bindings, 
        //arrow functions inherit the this binding of the containing function.

        //That means that the variables and constants available to the containing function 
        //are also available to the event handler when using an arrow function."
        //https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener
        this.buttonNewGame.addEventListener('click', () => { this.onNewGameClicked(); });
        this.buttonHit.addEventListener('click', () => { this.onHitClicked(); });
        this.buttonStay.addEventListener('click', () => { this.onStayClicked(); });
    }

    createDeck()
    {
        let deck = [];
        
        for(let suitIndex = 0; suitIndex < this.suits.length; ++suitIndex)
        {
            for(let valueIndex = 0; valueIndex < this.values.length; ++valueIndex)
            {
                let card = {
                    suit:  this.suits[suitIndex],
                    value:  this.values[valueIndex]
                }

                deck.push(card);
            }
        }

        return deck;
    }

    shuffleDeck(deck)
    {
        for(let i = 0; i < deck.length; ++i)
        {
            let swapIndex = Math.trunc(Math.random() * deck.length);
            let tmpCard = deck[swapIndex];
            deck[swapIndex] = deck[i];
            deck[i] = tmpCard;
        }
    }

    getCardString(card)
    {
        return card.value + ' of ' + card.suit + '\n';
    }

    getNextCard() 
    {
        return this.deck.shift();
    }

    showStatus()
    {
        if(!this.gameStarted)
        {
            this.textArea.innerText = 'Welcome to BlackJack!';
            return
        }

        let dealerCardString = '';
        for(let i = 0; i < this.dealerCards.length; ++i)
        {
            dealerCardString += this.getCardString(this.dealerCards[i]);
        }

        let playerCardString = '';
        for(let i = 0; i < this.playerCards.length; ++i)
        {
            playerCardString += this.getCardString(this.playerCards[i]);
        }

        this.updateScores();

        this.textArea.innerText = 
            'Dealer has:\n' +
            dealerCardString +
            '(score: ' + this.dealerScore + ')\n\n' +

            'Player has:\n' +
            playerCardString +
            '(score: ' + this.playerScore + ')\n\n';

        if(this.gameOver)
        {
            if(this.playerWon)
            {
                this.textArea.innerText += 'YOU WIN!';
            }
            else
            {
                this.textArea.innerText += 'DEALER WINS.';
            }

            this.buttonNewGame.style.display = 'inline';
            this.buttonHit.style.display = 'none';
            this.buttonStay.style.display = 'none';
        }
    }

    updateScores()
    {
        this.dealerScore = this.getScore(this.dealerCards);
        this.playerScore = this.getScore(this.playerCards);
    }

    getScore(cardArray)
    {
        let score = 0;
        let hasAce = false;

        for(let i = 0; i < cardArray.length; ++i)
        {
            let card = cardArray[i];
            score += this.getCardNumericValue(card);

            console.log("Card value: " + card.value);
            console.log("this.getCardNumericValue: " + this.getCardNumericValue(card));

            if(card.value === 'Ace')
            {
                hasAce = true;
            }
        }

        if(hasAce && score + 10 <= 21)
        {
            return score + 10;
        }

        return score;
    }

    getCardNumericValue(card)
    {
        switch(card.value)
        {
            case 'Ace':
                return 1;
            case '2':
                return 2;
            case '3':
                return 3;
            case '4':
                return 4;
            case '5':
                return 5;
            case '6':
                return 6;
            case '7':
                return 7;
            case '8':
                return 8;
            case '9':
                return 9;
            default:
                return 10;
        }
    }

    checkForEndOfGame()
    {
        this.updateScores();

        if(this.gameOver)
        {
            while(  this.dealerScore < this.playerScore &&
                    this.playerScore <= 21 &&
                    this.dealerScore <= 21)
            {
                this.dealerCards.push(this.getNextCard());
                this.updateScores();
            }
        }

        if(this.playerScore > 21)
        {
            this.playerWon = false;
            this.gameOver = true;
        }
        else if(this.dealerScore > 21)
        {
            this.playerWon = true;
            this.gameOver = true;
        }
        else if(this.gameOver)
        {
            if(this.playerScore > this.dealerScore)
            {
                this.playerWon = true;
            }
            else
            {
                this.playerWon = false;
            }

            this.buttonNewGame.style.display = 'inline';
            this.buttonHit.style.display = 'none';
            this.buttonStay.style.display = 'none';
        }
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