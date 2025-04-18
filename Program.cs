using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TextRPG
{
    public enum Place
    {
        Start,
        Player,
        Inventory,
        ItemEquipped,
        Shop,
        Buy,
        Sell,
        Restroom,
        Dungeon,
        DungeonClear,
        Exit
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            GameManager gameManager = new GameManager();
            gameManager.GameRoof();

        }
    }
}

