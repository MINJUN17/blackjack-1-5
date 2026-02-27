using System;

CardDeck card = new CardDeck();
Random rng = new Random();

CardDeck card1 = card;

string picked = CardDeck.PickRandomCell(card1, rng);
Console.WriteLine($"·£´ý ¼±ÅÃ: {picked}");