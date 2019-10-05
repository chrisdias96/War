using System.Linq;

namespace war {
    public enum Suit {
        Clubs = '\u2663',
        Diamonds = '\u2666',
        Spades = '\u2660',
        Hearts = '\u2665'
    }

    public class Card {
        public Suit Suit { get; set; }
        public int Rank { get; set; }
        public int Value { get; set; }

        public override string ToString() {
            if (Rank > 1 && Rank < 11) {
                switch (Suit) {
                    case Suit.Clubs:
                    return $"{Rank}\u2663";
                    case Suit.Diamonds:
                    return $"{Rank}\u2666";
                    case Suit.Spades:
                    return $"{Rank}\u2660";
                    case Suit.Hearts:
                    return $"{Rank}\u2665";
                }
            }

            switch (Rank)
            {
                case 11:
                    switch (Suit) {
                        case Suit.Clubs:
                            return $"J\u2663";
                        case Suit.Diamonds:
                            return $"J\u2666";
                        case Suit.Spades:
                            return $"J\u2660";
                        case Suit.Hearts:
                            return $"J\u2665";
                    }

                    break;
                case 12:
                    switch (Suit) {
                        case Suit.Clubs:
                            return $"Q\u2663";
                        case Suit.Diamonds:
                            return $"Q\u2666";
                        case Suit.Spades:
                            return $"Q\u2660";
                        case Suit.Hearts:
                            return $"Q\u2665";
                    }

                    break;
                case 13:
                    switch (Suit) {
                        case Suit.Clubs:
                            return $"K\u2663";
                        case Suit.Diamonds:
                            return $"K\u2666";
                        case Suit.Spades:
                            return $"K\u2660";
                        case Suit.Hearts:
                            return $"K\u2665";
                    }

                    break;
                case 14:
                    switch (Suit) {
                        case Suit.Clubs:
                            return $"A\u2663";
                        case Suit.Diamonds:
                            return $"A\u2666";
                        case Suit.Spades:
                            return $"A\u2660";
                        case Suit.Hearts:
                            return $"A\u2665";
                    }

                    break;
            }

            return null;
        }


        public Card(int rank, Suit suit) {
            this.Suit = suit;
            this.Rank = rank;

        }

        public Card() {

        }

        public static bool operator ==(Card lhs, Card rhs) {
            if (lhs is null) {
                return rhs is null;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Card lhs, Card rhs) {
            return !lhs.Equals(rhs);
        }

        public override bool Equals(object obj) {
            Card card = obj as Card;
            if (card != null) {
                return Rank.Equals(card.Rank);
            }
            return false;
        }

        public static bool operator >(Card lhs, Card rhs) {
            if (lhs is null) {
                return rhs is null;
            }
            return lhs.Value > rhs.Value;
        }

        public static bool operator <(Card lhs, Card rhs) {
            if (lhs is null) {
                return rhs is null;
            }
            return lhs.Value < rhs.Value;
        }

    }//end card class

}
