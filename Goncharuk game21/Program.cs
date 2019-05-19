using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goncharuk_game21
{
    enum Value { Ace = 11, King = 4, Lady = 3, Jack = 2, Ten = 10, Nine = 9, Eight = 8, Seven = 7, Six = 6 }
    class Program
    {
        struct Deck
        {
            public string Suit;
            public Value value;
        }

        static void Main(string[] args)
        {
            Deck[] deck = new Deck[36];
            for (int i = 0; i < 36; i++)
            {
                switch (i / 9)
                {
                    case 0:
                        deck[i].Suit = "Heart";
                        break;
                    case 1:
                        deck[i].Suit = "Club";
                        break;
                    case 2:
                        deck[i].Suit = "Diamond";
                        break;
                    case 3:
                        deck[i].Suit = "Spade";
                        break;
                }
                switch (i % 9)
                {
                    case 0:
                        deck[i].value = Value.Ace;
                        break;
                    case 1:
                        deck[i].value = Value.King;
                        break;
                    case 2:
                        deck[i].value = Value.Lady;
                        break;
                    case 3:
                        deck[i].value = Value.Jack;
                        break;
                    case 4:
                        deck[i].value = Value.Ten;
                        break;
                    case 5:
                        deck[i].value = Value.Nine;
                        break;
                    case 6:
                        deck[i].value = Value.Eight;
                        break;
                    case 7:
                        deck[i].value = Value.Seven;
                        break;
                    case 8:
                        deck[i].value = Value.Six;
                        break;
                }
            }
            bool end = false;
            int Player = 0;
            int Computer = 0;
            int ComputerSum = 0;
            int PlayerSum = 0;
            int Game = 1;
            string Win = "CONGRATULATION!!! YOU WIN";
            string Lost = "You are LOOSER!";
            string MoreCard = "If you want another cards enter y,if dont enter n";
            string MoreGame = "If you want another game enter y,if dont enter n";
            Random rand = new Random();
            Deck temp;

            for (int i = 0; i < deck.Length; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < deck.Length; j++)
                    {
                        int t = rand.Next(1, 35);
                        temp = deck[j];
                        deck[j] = deck[t];
                        deck[t] = temp;

                    }
                    Console.WriteLine("************************");
                    Console.WriteLine("************************");
                    Console.WriteLine($"Game  {Game} Player win = {Player}  Computer win = {Computer} ");
                    Console.WriteLine();
                    Game++;
                }
                bool BlackJeck = false;
                int n = rand.Next(0, 2);
                if (n == 1) BlackJeck = false;
                else BlackJeck = true;
                while (i < 4 && i != -1)
                {
                    if (BlackJeck == false && i != -1)
                    {

                        PlayerSum += (int)deck[i].value;
                        Console.WriteLine($"{deck[i].value} of {deck[i].Suit}   Player points = { PlayerSum}");
                        if (i == 1) BlackJeck = true;
                        if (i == 4) BlackJeck = false;
                        i++;
                        if (PlayerSum == 21 || PlayerSum == 22)
                        {
                            Console.WriteLine(Win);
                            Player++;
                            Console.WriteLine(MoreGame);
                            if (Console.ReadLine() == "y")
                            {
                                i = -1;
                                ComputerSum = 0;
                                PlayerSum = 0;
                                BlackJeck = true;
                            }
                            else
                            {
                                Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                end = true;
                                break;
                            }
                        }
                    }
                    else if (BlackJeck == true && i != -1)
                    {
                        ComputerSum += (int)deck[i].value;
                        Console.WriteLine($"{deck[i].value} of {deck[i].Suit}   Computer points = {ComputerSum}");
                        if (i == 1) BlackJeck = false;
                        if (i == 3) BlackJeck = false;
                        i++;
                        if (ComputerSum == 21 || ComputerSum == 22)
                        {
                            Console.WriteLine(Lost);
                            Computer++;
                            Console.WriteLine(MoreGame);
                            if (Console.ReadLine() == "y")
                            {
                                i = -1;
                                ComputerSum = 0;
                                PlayerSum = 0;
                                BlackJeck = true;
                            }
                            else
                            {
                                Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                end = true;
                                break;
                            }
                        }
                    }
                }
                // Take one card

                if (BlackJeck == false)
                {
                    while ((ComputerSum < 17 || BlackJeck == false) && i != -1)
                    {

                        if (n == 1)
                        {
                            Console.WriteLine(MoreCard);
                            string current = Console.ReadLine();
                            if (current == "y")
                            {
                                PlayerSum += (int)deck[i].value;
                                Console.WriteLine($"{deck[i].value} of {deck[i].Suit}");
                                Console.WriteLine($"Player points = { PlayerSum}");
                                i++;

                                if (PlayerSum > 19)
                                {
                                    n = 0;
                                    BlackJeck = true;
                                }
                            }
                            else if (current == "n")
                            {

                                BlackJeck = true;
                                n = 0;
                                if (ComputerSum > 21)
                                {
                                    Console.WriteLine(Win);
                                    Player++;
                                    Console.WriteLine(MoreGame);
                                    if (Console.ReadLine() == "y")
                                    {
                                        i = -1;
                                        ComputerSum = 0;
                                        PlayerSum = 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                        end = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (n == 0 && i != -1)
                        {
                            while (ComputerSum < 17)
                            {
                                ComputerSum += (int)deck[i].value;
                                Console.WriteLine($"{deck[i].value} of {deck[i].Suit} ");
                                Console.WriteLine($"Computer points = {ComputerSum}");
                                i++;
                            }
                            n = 1;

                            if (ComputerSum < 21)
                            {

                                if (PlayerSum > 21)
                                {
                                    Console.WriteLine(Lost);
                                    Computer++;
                                    Console.WriteLine(MoreGame);
                                    if (Console.ReadLine() == "y")
                                    {
                                        i = -1;
                                        ComputerSum = 0;
                                        PlayerSum = 0;
                                        BlackJeck = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                        end = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    // Output of the result
                    if (end == true) break;
                    if (i != -1)
                    {
                        if (ComputerSum > 21 && PlayerSum > 21 && ComputerSum != PlayerSum)
                        {
                            if (ComputerSum > PlayerSum)
                            {
                                Console.WriteLine(Win);
                                Player++;

                            }
                            else
                            {
                                Console.WriteLine(Lost);
                                Computer++;
                            }
                            Console.WriteLine(MoreGame);
                            if (Console.ReadLine() == "y")
                            {
                                i = -1;
                                ComputerSum = 0;
                                PlayerSum = 0;
                            }
                            else
                            {
                                Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                break;
                            }
                        }
                        else if (ComputerSum < 21 && PlayerSum < 21 && ComputerSum != PlayerSum)
                        {
                            if (ComputerSum < PlayerSum)
                            {
                                Console.WriteLine(Win);
                                Player++;

                            }
                            else
                            {
                                Console.WriteLine(Lost);
                                Computer++;
                            }
                            Console.WriteLine(MoreGame);
                            if (Console.ReadLine() == "y")
                            {
                                i = -1;
                                ComputerSum = 0;
                                PlayerSum = 0;
                            }
                            else
                            {
                                Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                break;
                            }
                        }
                        else if (ComputerSum == PlayerSum)
                        {
                            Console.WriteLine("IT IS DRAW");
                            Console.WriteLine(MoreGame);
                            if (Console.ReadLine() == "y")
                            {
                                i = -1;
                                ComputerSum = 0;
                                PlayerSum = 0;
                            }
                            else
                            {
                                Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                break;
                            }
                        }
                        else
                        {
                            if (PlayerSum == 21)
                            {
                                Console.WriteLine(Win);
                                Player++;
                                Console.WriteLine(MoreGame);
                                if (Console.ReadLine() == "y")
                                {
                                    i = -1;
                                    ComputerSum = 0;
                                    PlayerSum = 0;
                                }
                                else
                                {
                                    Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                    break;
                                }
                            }
                            else if (ComputerSum == 21)
                            {
                                Console.WriteLine(Lost);
                                Computer++;
                                Console.WriteLine(MoreGame);
                                if (Console.ReadLine() == "y")
                                {
                                    i = -1;
                                    ComputerSum = 0;
                                    PlayerSum = 0;
                                }
                                else if (Console.ReadLine() == "n")
                                {
                                    Console.WriteLine($"Player win = {Player}  Computer win = {Computer}");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
