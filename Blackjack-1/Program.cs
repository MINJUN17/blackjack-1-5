using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        GamePlay play = new GamePlay();
        play.Run();
    }

}