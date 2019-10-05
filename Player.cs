using System;
namespace war {
    public class Player {

        public int PlayerNum { get; set; }
        public int Score { get; set; }
        public Card[] PlayerDeck { get; set; }

        public Player() {
        }

        public Player(int PlayerNum, int Score) {
            this.PlayerNum = PlayerNum;
            this.Score = Score;
            PlayerDeck = new Card[26];
        }

    }
}
