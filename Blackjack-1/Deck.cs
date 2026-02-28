using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Deck
{
    private string[] cards = new string[52];
    private string[] shapes = { "♥", "◆", "♣", "♠" };
    private string[] numbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private Random num = new Random();
    public int CardCount { get; private set; } = 0;

    public void DeckCreate()
    {
        CardCount = 0;
        int k = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            for(int j = 0; j < numbers.Length; j++)
            {
                cards[k++] = $"{shapes[i]}{numbers[j]}";
            }
        }
    }

    public void DeckShuffle()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            int randomIndex = num.Next(cards.Length);
            string temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }
    public string Draw()
    {
        return cards[CardCount++];
    }
}

