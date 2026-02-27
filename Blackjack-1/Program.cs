using System;

CardDeck deck = new CardDeck();

string[] playerHand = new string[52];
string[] dealerHand = new string[52];

int handCount = 0;
int dealerCount = 0;


CardDeck.AddCard(deck, playerHand, ref handCount); // 1장 추가
CardDeck.AddCard(deck, playerHand, ref handCount);

CardDeck.AddCard(deck, dealerHand, ref dealerCount); // 1장 추가
CardDeck.AddCard(deck, dealerHand, ref dealerCount);

int sum_d = 0;
Console.WriteLine("=== 초기 패 ===");
Console.Write("딜러 패:");
for (int i = 0; i < dealerCount; i++)
{
    if (i == 0)
    {
        Console.Write($"[?] ");
    }
    else { Console.Write($"[{dealerHand[i]}] "); }
    sum_d += deck.GetNumValue(dealerHand[i], sum_d);
}
Console.WriteLine($"\n딜러 점수: ?");


int sum_p = 0;
Console.Write("플레이어의 패:");
for (int i = 0; i < handCount; i++)
{
    Console.Write($"[{playerHand[i]}] ");
    sum_p += deck.GetNumValue(playerHand[i], sum_p);
}
Console.WriteLine($"\n플레이어 점수: {sum_p}");


int inputFlag = 0;
do
{
    Console.Write("H(Hit) 또는 S(Stand)를 선택하세요:");
    string input = Console.ReadLine();
    if (input == "h")
    {
        CardDeck.AddCard(deck, playerHand, ref handCount);
        Console.WriteLine($"플레이어가 카드를 받았습니다: [{playerHand[handCount - 1]}]");
        Console.Write("플레이어의 패:");
        sum_p = 0;
        for (int i = 0; i < handCount; i++)
        {
            Console.Write($"[{playerHand[i]}] ");
            sum_p += deck.GetNumValue(playerHand[i], sum_p);
        }
        Console.WriteLine($"\n플레이어 점수: {sum_p}");
    }
    else
    {
        Console.WriteLine("플레이어가 stand를 선택했습니다.");
        inputFlag = 1;
    }
    if (sum_p > 21)
    {
        Console.WriteLine("버스트! 21을 초과했습니다.");
        inputFlag = 2;
    }
} while (inputFlag == 0);


int dFlag = 0;
while (inputFlag != 2 || sum_d < 17)
{
   
    CardDeck.AddCard(deck, dealerHand, ref dealerCount);
    Console.WriteLine($"딜러가 카드를 받습니다: [{dealerHand[dealerCount - 1]}]");
    Console.Write("딜러의 패:");
    sum_d = 0;
    for (int i = 0; i < dealerCount; i++)
    {
        Console.Write($"[{dealerHand[i]}] ");
        sum_d += deck.GetNumValue(dealerHand[i], sum_d);
    }
    Console.WriteLine($"\n딜러 점수: {sum_d}");

    if (sum_d > 21)
    {
        dFlag = 1;
        Console.WriteLine("버스트! 21을 초과했습니다.");
        break;
    }
    else if (sum_d >= 17)
    {
        dFlag = 2;
        break;
    }
}
Console.WriteLine($"=== 게임 결과 ===\r\n플레이어: {sum_p}점\r\n딜러: {sum_d}점");
if (inputFlag == 1 && dFlag == 1)
{
    Console.WriteLine("플레이어 승리!");
}
else if (sum_d == sum_p)
{
    Console.WriteLine("무승부");
}
else
{
    Console.WriteLine("딜러 승리!");
}

