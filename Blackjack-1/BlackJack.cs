using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Markup;



class Card
{
    public string Shape { get; }
    public string Number { get; }
    public Card(string shape, string number)
    {
        Shape = shape;
        Number = number;
    }
}


class CardDeck
{
    //public string Shape { get; }
    //public string Number { get; }
    //public CardDeck(string shape, string number)
    //{
    //    Shape = shape;
    //    Number = number;
    //}


    //private string[] Shapes = { "♥", "◆", "♣", "♠" };
    //private string[] Numbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    private string[,] Cards = new string[4, 13]
    {
        { "♥ A","♥ 2","♥ 3","♥ 4","♥ 5","♥ 6","♥ 7","♥ 8","♥ 9","♥ 10","♥ J","♥ Q","♥ K"},
        { "◆ A","◆ 2","◆ 3","◆ 4","◆ 5","◆ 6","◆ 7","◆ 8","◆ 9","◆ 10","◆ J","◆ Q","◆ K"},
        { "♣ A","♣ 2","♣ 3","♣ 4","♣ 5","♣ 6","♣ 7","♣ 8","♣ 9","♣ 10","♣ J","♣ Q","♣ K"},
        { "♠ A","♠ 2","♠ 3","♠ 4","♠ 5","♠ 6","♠ 7","♠ 8","♠ 9","♠ 10","♠ J","♠ Q","♠ K"}
    };



    public void RandomCard()
    {
        Random shape = new Random();
        Random number = new Random();
        int shapes = shape.Next(4);
        int numbers = number.Next(13);

    }
    public void CardPrint(string shape, string number)
    {
        int Shapes = this.shape;
        Console.WriteLine(shape);
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

