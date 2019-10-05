using System;

namespace war {
    class MainClass {
        private static int round;
        private static int currentIndex;
        private static bool isPlayingAgain;
        private static int[] FinalScore = { 0, 0, 0 };
        private static int CurrentDeckSize = 52;

        private static Deck DeckClass = new Deck();
        private static Player Player1 = new Player(1, 0);
        private static Player Player2 = new Player(2, 0);

        private static ConsoleKey UserInput;
        private static ConsoleKey PlayAgainUserInput;

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            WelcomeDisplay();

            UserInput = Console.ReadKey().Key;

            //Begin the game
            do {
                //Add the cards to the deck,
                //Shuffle the cards,
                //Distribute half the deck to each player
                DeckClass.AppendCards();
                DeckClass.shuffle();
                DistributeCards(Player1, Player2);

                isPlayingAgain = false;
                //Continue looping through the game until the
                //deck array becomes empty.

                do {
                    
                    //Enter the game once user presses enter
                    //if (UserInput == ConsoleKey.Enter) {
                        round++;

                        //Play the round
                        BeginRound(ref Player1, ref Player2, CurrentDeckSize);

                    //Read the key pressed
                    if (CurrentDeckSize != 0) {
                        UserInput = Console.ReadKey().Key;
                    }
                    //}
                } while (CurrentDeckSize != 0 && UserInput == ConsoleKey.Enter);

                //determine game winner
                DetermineGameWinner(ref Player1, ref Player2);

                Console.WriteLine("Play Again? (Y/N)");
                PlayAgainUserInput = Console.ReadKey().Key;

                if (PlayAgainUserInput == ConsoleKey.Y) {
                    currentIndex = 0;
                    CurrentDeckSize = 52;
                    Player1.Score = 0;
                    Player2.Score = 0;
                    round = 0;
                    isPlayingAgain = true;
                }

                Console.Clear();
            } while (isPlayingAgain);

            //Display the total wins
            Console.WriteLine();
            Console.WriteLine($"Total Wins - Player 1: {FinalScore[0]}  Player 2: {FinalScore[1]}   Draws: {FinalScore[2]}");

        } //end of Main

        /*           *
         *  METHODS  *
         *           */

        public static void WelcomeDisplay() {
            Console.WriteLine(new String('*', 31));
            Console.WriteLine("| Welcome to the game of WAR! |");
            Console.WriteLine(new String('*', 31));
            Console.WriteLine("Press <enter> to begin...");
        }

        public static void BeginRound(ref Player p1, ref Player p2, int CurrentDeckSize) {
            //Check how many cards are remaining in the deck
            if (CurrentDeckSize != 0) {

                //Display the scores
                Console.WriteLine($"P1 Score: {p1.Score}     P2 Score: {p2.Score}");
                Console.WriteLine($"Round {round}");

                Console.WriteLine($"Player 1 plays: {p1.PlayerDeck[currentIndex]}         Player 2 plays: {p2.PlayerDeck[currentIndex]}");

                DetermineRoundWinner(ref Player1, ref Player2);

            }
        }//end of beginRound

        //This function splits the deck in half and distributes it to each player
        public static void DistributeCards(Player p1, Player p2) {
            for (int i = 0; i <= 25; i++) {
                p1.PlayerDeck[i] = DeckClass.deck[i];
            }
            for (int i = 0; i <= 25; i++) {
                p2.PlayerDeck[i] = DeckClass.deck[i + 25];
            }
        }//end distribute cards


        public static void DetermineRoundWinner(ref Player p1, ref Player p2) {
            int points = 1;

            if (p1.PlayerDeck[currentIndex].Rank > p2.PlayerDeck[currentIndex].Rank) {
                Console.WriteLine($"Player 1 wins {points} point(s)");
                Console.WriteLine();
                Console.WriteLine("Press <enter> to continue...");
                p1.Score += points;
            } else if (p2.PlayerDeck[currentIndex].Rank > p1.PlayerDeck[currentIndex].Rank) {
                Console.WriteLine($"Player 2 wins {points} point(s)");
                Console.WriteLine();
                Console.WriteLine("Press <enter> to continue...");
                p2.Score += points;
            }

            CurrentDeckSize -= 2;
            while (p1.PlayerDeck[currentIndex].Rank == p2.PlayerDeck[currentIndex].Rank && CurrentDeckSize != 0) {
                int cardsPicked = 0;
                
                //If the player cards match, declare a war
                Console.WriteLine("                    >>>>>>>>>>WAR<<<<<<<<<<<");

                while (currentIndex < 25 && cardsPicked < 4) {
                    CurrentDeckSize -= 2;
                    cardsPicked++;
                    points++;
                    currentIndex++;
                    Console.WriteLine($"                {p1.PlayerDeck[currentIndex]}                         {p2.PlayerDeck[currentIndex]}");
                }

                if (p1.PlayerDeck[currentIndex].Rank > p2.PlayerDeck[currentIndex].Rank) {
                    Console.WriteLine($"Player 1 wins {points} point(s)");
                    Console.WriteLine();
                    Console.WriteLine("Press <enter> to continue...");
                    p1.Score += points;
                } else if (p2.PlayerDeck[currentIndex].Rank > p1.PlayerDeck[currentIndex].Rank) {
                    Console.WriteLine($"Player 2 wins {points} point(s)");
                    Console.WriteLine();
                    Console.WriteLine("Press <enter> to continue...");
                    p2.Score += points;
                }
            }

            currentIndex++;
        }//end DetermineWinner

        public static void DetermineGameWinner(ref Player p1, ref Player p2) {
            if (p1.Score > p2.Score) {
                Console.WriteLine();
                Console.WriteLine($"Congratulations Player 1, you've won!!!");
                FinalScore[0] += 1;
            } else if (p2.Score > p1.Score) {
                Console.WriteLine();
                Console.WriteLine($"Congratulations Player 2, you've won!!!");
                FinalScore[1] += 1;
            } else if (p1.Score == p2.Score) {
                Console.WriteLine();
                Console.WriteLine("This round was a draw!");
                FinalScore[2] += 1;
            }
        }//end DetermineGameWinner

        public static bool PlayAgain() {
            
            

            return false;
        }
    }
}
