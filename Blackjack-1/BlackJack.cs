using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;



//class Card
//{
//    public string Shape { get; }
//    public string Number { get; }
//    public Card(string shape, string number)
//    {
//        Shape = shape;
//        Number = number;
//    }
//}


class CardDeck
{
    //public string Shape { get; }
    //public string Number { get; }
    //public CardDeck(string shape, string number)
    //{
    //    Shape = shape;
    //    Number = number;
    //}

    
        private string[] Shapes = { "♥", "◆", "♣", "♠" };
        private string[] Numbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        //private Card[] _cards;
        private string[] _cards;



    //private string[,] Cards = new string[4, 13]
    //{
    //    { "♥ A","♥ 2","♥ 3","♥ 4","♥ 5","♥ 6","♥ 7","♥ 8","♥ 9","♥ 10","♥ J","♥ Q","♥ K"},
    //    { "◆ A","◆ 2","◆ 3","◆ 4","◆ 5","◆ 6","◆ 7","◆ 8","◆ 9","◆ 10","◆ J","◆ Q","◆ K"},
    //    { "♣ A","♣ 2","♣ 3","♣ 4","♣ 5","♣ 6","♣ 7","♣ 8","♣ 9","♣ 10","♣ J","♣ Q","♣ K"},
    //    { "♠ A","♠ 2","♠ 3","♠ 4","♠ 5","♠ 6","♠ 7","♠ 8","♠ 9","♠ 10","♠ J","♠ Q","♠ K"}
    //};


    public string RandomCard()
    {
        Random number = new Random();
        int numbers = number.Next(52);
        return _cards[numbers];
    }

    public void Card()
    {
        int k = 0;
        _cards = new string[Shapes.Length * Numbers.Length];
        //foreach(string shape in Shapes)
        //{
        //    foreach(string number in Numbers)
        //    {
        //        _cards[i++] = new Card(shape, number);
        //    }
        //}
      
        for(int i = 0; i < Shapes.Length; i++)
        {
            for(int j = 0; j < Numbers.Length; j++)
            {
                _cards[k++] = $"{Shapes[i]}{Numbers[j]}";
            }
        }
    }
    


    //public string PickRandomCell(string[,] board, Random rng)
    //{
    //    // 행 개수, 열 개수
    //    int rows = board.GetLength(0);
    //    int cols = board.GetLength(1);

    //    // 0 ~ rows-1, 0 ~ cols-1 랜덤 좌표
    //    int r = rng.Next(rows);
    //    int c = rng.Next(cols);

    //    // 그 위치의 문자열 반환
    //    return board[r, c];
    //}



}

