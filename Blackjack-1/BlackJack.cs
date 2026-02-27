using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;

class CardDeck
{
    private string[] Shapes = { "♥", "◆", "♣", "♠" };
    private string[] Numbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private string[] Cards;
    //private int handCount = 0;
    Random number = new Random();

    public CardDeck()
    {
        int k = 0;
        Cards = new string[Shapes.Length * Numbers.Length];

        for (int i = 0; i < Shapes.Length; i++)
        {
            for (int j = 0; j < Numbers.Length; j++)
            {
                Cards[k++] = $"{Shapes[i]}{Numbers[j]}";
            }
        }
    }

    public string RandomCard()
    {
        int numbers = number.Next(52);
        return Cards[numbers];
    }

    //public void Shuffle()
    //{

    //    for (int i = 0; i < Cards.Length; i++)
    //    {
    //        int randomIndex = number.Next(52);

    //        string temp = Cards[i];
    //        Cards[i] = Cards[randomIndex];
    //        Cards[randomIndex] = temp;
    //    }
    //}
    public static void AddCard(CardDeck deck, string[] hand, ref int handCount)
    {
        string card = deck.RandomCard();

        // 이미 가진 카드면 다시 뽑기
        for (int i = 0; i < handCount; i++)
        {
            if (hand[i] == card)
            {
                card = deck.RandomCard();
                i = -1; // 처음부터 다시 검사
            }
        }

        hand[handCount++] = card; // ✅ 여기서 1장 추가
    }
    public int GetNumValue(string card, int currentsum)
    {
        string numbercard = card.Substring(1);
        if(numbercard == "A"&& currentsum > 11)
        {
            return 1;
        }
        else if(numbercard == "A" && currentsum <= 11)
        {
            return 11;
        }
        if (numbercard == "J" || numbercard == "Q" || numbercard == "K")
        {
            return 10;
        }
        return int.Parse(numbercard);
    }
}

