using System;
using System.Text;
namespace war {
    public class Deck {

        public Card[] deck { get; set; } = new Card[52];

        //Shuffles the deck of cards using a temporary variable that swaps the index
        //of the deck with another one
        public Card[] shuffle() {
            Random random = new Random();
            for (int i = deck.Length - 1; i > 0; i--) {
                int index = random.Next(i + 1);
                var temp = deck[index];
                deck[index] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

        //This method loops through each rank of a card from 2-14, and converts 11+ into applicable letters
        //Loops through the Suit enum 1-4, and convert them to strings to output encoding
        //Add the converted results into the deck
        public void AppendCards() {
            int index = 0;

            for (int i = 2; i <= 14; i++) {
                foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                    Card card = new Card(i, suit);

                    deck[index] = card;
                    //DisplayCard(card, i, suit);

                    index++;
                }
            }
        } //end AppendCards()

    }//end Deck class

}
