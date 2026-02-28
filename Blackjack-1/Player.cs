using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

public class Player
{
    public string[] Hand { get; private set; } = new string[15];
    public int HandCount { get; private set; } = 0;
    private bool first;
    private string playerName;
    //private ConsoleColor blackCardColor = ConsoleColor.Blue;
    //private ConsoleColor RedCardColor = ConsoleColor.Red;
    //private ConsoleColor HideCardColor = ConsoleColor.Yellow;
    public Player(string name)
    {
        playerName = name;
    }
    public void ReceiveCard(string Card)
    {
        Hand[HandCount] = Card;
        HandCount++;
    }
    public int Score()
    {
        int sum = 0;
        int ace = 0;
        for (int i = 0; i < HandCount; i++)
        {
            string getNumber = Hand[i].Substring(1);
            if (getNumber == "A")
            {
                sum += 11;
                ace++;
            }
            else if (getNumber == "K" || getNumber == "Q" || getNumber == "J")
            {
                sum += 10;
            }
            else
            {
                sum += int.Parse(getNumber);
            }
        }
        while (sum > 21 && ace > 0)
        {
            sum -= 10;
            ace--;
        }
        return sum;
    }
    public void ScorePrint()
    {
        Console.WriteLine($"{playerName} 점수: {Score()}");
    }
    public void DeckPrint(bool IsFirst)
    {
        Console.Write($"{playerName}의 패: ");
        for (int i = 0; i < HandCount; i++)
        {
            if (i == 0 && IsFirst == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[??]");
            }
            else
            {
                string GetShape = Hand[i].Remove(1);
                if (GetShape == "♥" || GetShape == "◆")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{Hand[i]}]");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"[{Hand[i]}]");
                }
            }
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    public void CardPrint(bool first)
    {
        int card = first ? 0 : HandCount - 1;
        string GetShape = Hand[card].Remove(1);
        if(card == 0)
        {
            if (GetShape == "♥" || GetShape == "◆")
            {
                Console.Write("딜러의 숨겨진 카드: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{Hand[card]}]");
            }
            else
            {
                Console.Write("딜러의 숨겨진 카드: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[{Hand[card]}]");
                Console.WriteLine();
            }
        }
        else if (GetShape == "♥" || GetShape == "◆")
        {
            Console.Write($"{playerName}가 카드를 받았습니다: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{Hand[card]}]");
        }
        else
        {
            Console.Write($"{playerName}가 카드를 받았습니다: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{Hand[card]}]");
        }
        Console.ResetColor();
    }
}
