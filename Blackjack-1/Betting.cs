using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Betting
{
    public int TotalCoin { get; private set; } = 1000;
    public int BetCoin { get; private set; }
    public int Winner { get; set; }

    public void BettingCoin()
    {
        while (true)
        {
            Console.Write($"베팅할 코인의 갯수를 입력하세요(ALLIN: {TotalCoin}): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("숫자만 입력해주세요!");
                continue;
            }

            if (value <= 0)
            {
                Console.WriteLine("0보다 큰 숫자를 입력하세요!");
                continue;
            }

            if (value > TotalCoin)
            {
                Console.WriteLine("최대 갯수를 초과했습니다!");
                continue;
            }

            BetCoin = value;
            TotalCoin -= BetCoin;
            break;
        }
    }
    public int CoinCalculate(int winner)
    {
        if (winner == 0)
        {
            TotalCoin += BetCoin;
        }
        else if(winner == 1)
        {
            TotalCoin += BetCoin * 2;
        }
        return TotalCoin;
    }
    public void GetOrLoseCoinPrint(int winner)
    {
        if (winner == 0)
        {
            Console.WriteLine($"{BetCoin}코인을 돌려 받으셨습니다.(현재{TotalCoin})");
        }
        else if (winner == 1)
        {
            Console.WriteLine($"{BetCoin * 2}코인을 획득!(현재{TotalCoin})");
        }
        else
        {
            Console.WriteLine($"코인을 잃으셨습니다.(현재{TotalCoin})");
        }
    }
    public void BettingPrint()
    {
        Console.WriteLine($"현재 코인: {TotalCoin}, 베팅 된 코인: {BetCoin}");
    }
}
