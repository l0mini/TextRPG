using System.Net.Http.Headers;
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
        Shopping,
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
        class GameManager //관리자
        {
            StartScene startScene;
             Player player;
             Inventory inventory;
            ItemEquipped itemEquipped;
            Shop shop;
            Shopping shopping;
            Place currentPlace;

            public GameManager()
            {
                startScene = new StartScene();
                 player = new Player();
                 inventory = new Inventory();
                 itemEquipped = new ItemEquipped();
                 shop = new Shop(player);
                 shopping = new Shopping();
                currentPlace = Place.Start;
            }

            public void GameRoof()
            {
                while (true)
                {
                    switch (currentPlace)
                    {
                        case Place.Start:
                            currentPlace = startScene.startScene();
                            break;
                        case Place.Player:
                            currentPlace = player.PlayerInfo();
                            break;
                        case Place.Inventory:
                            currentPlace = inventory.ShowInven();
                            break;
                        case Place.ItemEquipped:
                            currentPlace = itemEquipped.Equals();
                            break;
                        case Place.Shop:
                            currentPlace = shop.ShowShop();
                            break;
                        case Place.Shopping:
                            currentPlace = shopping.BuyScene();
                            break;
                        case Place.Exit:
                            Console.WriteLine("게임을 종료합니다.");
                            return;
                    }
                }

            }
        }
        class StartScene
        {
                public Place startScene()
                {

                    Console.Clear();
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                    Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("1. 상태보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.WriteLine("0. 게임종료");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");

                    int choice = int.Parse(Console.ReadLine());

                    return choice switch
                    {
                        1 => Place.Player,
                        2 => Place.Inventory,
                        3 => Place.Shop,
                        0 => Place.Exit,
                        _ => Place.Start
                    };
                
            }

        }// 시작화면
        class Player//상태 보기
        {
            int level = 1;
            string name = "플레이어";
            string jop = "전사";
            int attackPower = 10;
            int defensePower = 5;
            int health = 100;
            public int haveGold = 1500;

            public Place PlayerInfo()
            {
                GameManager start = new GameManager();

                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv. {level}");
                Console.WriteLine($"{name} ({jop})");
                Console.WriteLine($"공격력 : {attackPower}");
                Console.WriteLine($"방어력 : {defensePower}");
                Console.WriteLine($"체 력 : {health}");
                Console.WriteLine($"Gold : {haveGold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                return choice == 0 ? Place.Start : Place.Player;


            }
        }
        class Inventory//인벤토리
        {

            string[] Item = { }; //아이템들어갈 배열
            public Place ShowInven()
            {

                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int choice = int.Parse(Console.ReadLine());

                return choice switch
                {
                    1 => Place.ItemEquipped,
                    0 => Place.Start,
                    _ => Place.Inventory
                };
            }
        }
        class ItemEquipped//장착관리
        {
            public Place Equals()
            {

                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int choice = int.Parse(Console.ReadLine());

                return choice == 0 ? Place.Inventory : Place.ItemEquipped;
            }
        }
        class Shop//상점
        {
            Player player;
            public Shop(Player player)
            {
                this.player = player;
            }

            public Place ShowShop()
            {


                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.haveGold}G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("아이템 리스트 들어갈 곳");
                Console.WriteLine();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int choice = int.Parse(Console.ReadLine());

                return choice == 1 ? Place.Shopping : Place.Start;
            }
        }
        class Shopping//상점 구매
        {
            public Place BuyScene()
            {


                Console.Clear();
                Console.WriteLine("■ 아이템 구매 ■");
                Console.WriteLine("아직 구매 가능한 아이템이 없습니다.");
                Console.WriteLine("0. 돌아가기");

                int choice = int.Parse(Console.ReadLine());
                return choice == 0 ? Place.Shop : Place.Shopping;
            }
        }
    }





