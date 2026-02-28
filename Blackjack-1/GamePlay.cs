using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

public class GamePlay
{
    private Deck deck = new Deck();
    private bool restart = false;
    private Betting bet = new Betting();
    public int Winner { get; private set; }
    public void Run()
    {
        Start();
        while (true)
        {
            if (deck.CardCount > 30)
            {
                Console.Clear();
                Console.WriteLine("카드가 많이 사용되어 새로 섞습니다...");
                Thread.Sleep(2000);
                Start();
            }
            Playing();
            Restart();
            if (!restart) break;
        }
    }
    public void Start()
    {
        deck.DeckCreate();
        deck.DeckShuffle();
    }
    public void Playing()
    {
        bet.BettingCoin();
        Console.Clear();
        bet.BettingPrint();
        bool bust = false;
        Player player = new Player("플레이어");
        Player dealer = new Player("딜러");
        Console.WriteLine("=== 블랙잭 게임 ===\r\n\r\n카드를 섞는 중...\r\n\r\n=== 초기 패 ===");
        Console.WriteLine();
        string card = deck.Draw();
        dealer.ReceiveCard(card);
        card = deck.Draw();
        dealer.ReceiveCard(card);
        card = deck.Draw();
        player.ReceiveCard(card);
        card = deck.Draw();
        player.ReceiveCard(card);
        dealer.DeckPrint(true);
        Console.WriteLine("딜러 점수 : ?");
        Thread.Sleep(1000);
        Console.WriteLine();
        player.DeckPrint(false);
        player.ScorePrint();
        while (true)
        {
            Console.Write("\nH(Hit) 또는 S(Stand)를 선택하세요: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            input = input.ToUpper();
            if (input != "H" && input != "S")
            {
                Console.WriteLine("올바르게 입력해주세요");
                continue;
            }
            if (input == "S")
            {
                Console.WriteLine("플레이어가 Stand를 선택했습니다.\n");
                break;

            }
            card = deck.Draw();
            player.ReceiveCard(card);
            player.CardPrint(false);
            Thread.Sleep(1000);
            player.DeckPrint(false);
            Thread.Sleep(1000);
            player.ScorePrint();
            Thread.Sleep(1000);
            Console.WriteLine();
            if (player.Score() > 21)
            {
                bust = true;
                Console.WriteLine("플레이어 버스트!");
                break;
            }
        }
        if (bust == false)
        {
            dealer.CardPrint(true);
        }
        while (true)
        {
            if (bust == true || dealer.Score() >= 17)
            {
                break;
            }
            card = deck.Draw();
            dealer.ReceiveCard(card);
            dealer.CardPrint(false);
            Thread.Sleep(1000);
            dealer.DeckPrint(false);
            Thread.Sleep(1000);
            dealer.ScorePrint();
            Thread.Sleep(1000);
            Console.WriteLine();
        }

        Console.WriteLine("\n");
        Console.WriteLine("=== 게임 결과 ===");
        Console.WriteLine($"플레이어: {player.Score()}점");
        Console.WriteLine($"딜러: {dealer.Score()}점");
        if (bust == true ? true : dealer.Score() > 21 ? false : dealer.Score() >= player.Score() ? true : false)
        {
            if (dealer.Score() == player.Score())
            {
                Console.WriteLine("무승부!\n");
                Winner = 0;
            }
            else
            {
                Console.WriteLine("딜러 승리!\n");
                Winner = 2;
            }
        }
        else
        {
            Console.WriteLine("플레이어 승리!\n");
            Winner = 1;
        }
    }
    public void Restart()
    {
        while (true)
        {
            if (bet.CoinCalculate(Winner) <= 0)
            {
                bet.GetOrLoseCoinPrint(Winner);
                Console.WriteLine("보유한 코인을 모두 소모하셨습니다. 감사합니다");
                restart = false;
                break;
            }
            else
            {
                bet.GetOrLoseCoinPrint(Winner);
            }
            Console.Write("다시하시겠습니까?(y, n): ");
            string input = Console.ReadLine();
            Console.WriteLine();
            input = input.ToUpper();
            if (input != "Y" && input != "N")
            {
                Console.WriteLine("올바르게 입력해주세요");
                continue;
            }
            else if (input == "N")
            {
                Console.WriteLine("고생하셨습니다! 게임을 종료합니다.");
                restart = false;
                break;
            }
            else if (input == "Y")
            {
                restart = true;
                Console.Clear();
                break;
            }

        }
    }
}
