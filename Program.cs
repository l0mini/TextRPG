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
        Shop shop;
        Shopping shopping;
        Inventory inventory;
        ItemEquipped itemEquipped;
        Place currentPlace;

        public GameManager()
        {
            startScene = new StartScene();
            player = new Player();
            shop = new Shop(player);
            shopping = new Shopping(shop.AllItems, player);
            inventory = new Inventory(shop.AllItems);
            itemEquipped = new ItemEquipped();
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
            int choice;

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Start;
                }
            }
            switch (choice)
            {
                case 1:
                    return Place.Player;
                case 2:
                    return Place.Inventory;
                case 3:
                    return Place.Shop;
                case 0:
                    return Place.Exit;
                default:
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Start;
            }

        }

    }// 시작화면
    class Player//상태 보기
    {
        ItemPro itemPro;
        int level = 1;
        string name = "플레이어";
        string jop = "전사";
        int attackPower = 10;
        int defensePower = 5;
        int health = 100;
        public int haveGold = 1500;

        public Place PlayerInfo()
        {
            

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
            int choice;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Player;

                }
            }
            if (choice == 0)
            {
                return Place.Start;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                return Place.Player;
            }


        }
    }
    class Inventory//인벤토리
    {
        public List<Item> AllItems;
        public Inventory(List<Item> AllItems)
        {
            this.AllItems = AllItems.Where(item => item.itemPro.IsSold).ToList();
        }

        public Place ShowInven()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            if (AllItems.Count == 0)
            {
                Console.WriteLine("※ 보유한 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < AllItems.Count; i++)
                {
                    Console.WriteLine($"{AllItems[i]}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int choice;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Inventory;
                }
            }

            switch (choice)
            {
                case 1:
                    return Place.ItemEquipped;
                case 0:
                    return Place.Start;
                default:
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Inventory;


            }
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
            int choice;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.ItemEquipped;
                }
            }
            if (choice == 0)
            {
                return Place.Inventory;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                return Place.ItemEquipped;
            }
        }
    }
    class Shop//상점
    {

        public List<Item> AllItems { get; set; }

        Player player;
        public Shop(Player player)
        {
            this.player = player;
            AllItems = new List<Item>();

            AllItems.Add(new Item(Item.BeginnerArmor()));
            AllItems.Add(new Item(Item.IronArmor()));
            AllItems.Add(new Item(Item.SpartaArmor()));
            AllItems.Add(new Item(Item.OldSword()));
            AllItems.Add(new Item(Item.BronzeAx()));
            AllItems.Add(new Item(Item.SpartaSphere()));
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
            foreach (var Item in AllItems)
            {
                Console.WriteLine(Item);
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int choice;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Shop;
                }
            }
            if (choice == 1)
            {
                return Place.Shopping;
            }
            else if (choice == 0)
            {
                return Place.Start;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                return Place.Shop;
            }
        }
    }
    class Shopping//상점 구매
    {
        public List<Item> AllItems;
        Player player;
        public Shopping(List<Item> AllItems, Player player)
        {
            this.player = player;
            this.AllItems = AllItems;
        }
        public Place BuyScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.haveGold} G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < AllItems.Count; i++)//아이템의 배열을 위부터 반복해 출력
                {
                    Console.WriteLine($"{i + 1} {AllItems[i]}");
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int choice;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out choice))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다!");
                        Thread.Sleep(1000);
                        return Place.Shopping;

                    }
                }
                if (choice == 0) return Place.Shop;

                int index = choice - 1;

                if (index >= 0 && index < AllItems.Count)
                {
                    var selectedItem = AllItems[index];
                    if (!selectedItem.itemPro.IsSold && player.haveGold >= selectedItem.itemPro.ItemValue)
                    {
                        player.haveGold -= selectedItem.itemPro.ItemValue;
                        selectedItem.itemPro.IsSold = true;

                        Console.WriteLine("구매 완료!");
                    }
                    else if (selectedItem.itemPro.IsSold && player.haveGold < selectedItem.itemPro.ItemValue)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                        Thread.Sleep(1000);
                    }
                    else if (selectedItem.itemPro.IsSold)
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Shopping;
                }
            }
        }
    }
}
class ItemPro
{
    public string ItemName { get; set; }
    public int ItemStat { get; set; }
    public string ItemInfo { get; set; }
    public int ItemValue { get; set; }
    public bool IsSold { get; set; }
    public bool IsArmor { get; set; }
    public bool IsWeapon { get; set; }

    public ItemPro(string name, int stat, string info, int value, bool isArmor, bool isWeapon)
    {
        ItemName = name;
        ItemStat = stat;
        ItemValue = value;
        ItemInfo = info;
        IsSold = false;
        IsArmor = isArmor;
        IsWeapon = isWeapon;
    }
    public override string ToString()
    {
        if (IsSold && IsArmor)
        {
            return $"-{ItemName} | {ItemStat} | {ItemInfo} | [판매 완료]";
        }
        else if (IsSold && IsWeapon)
        {
            return $"-{ItemName} | {ItemStat} | {ItemInfo} | [판매 완료]";
        }
        else if (!IsSold && IsArmor)
        {
            return $"-{ItemName} | 방어력 : {ItemStat} | {ItemInfo} | {ItemValue}G";
        }
        else
        {
            return $"-{ItemName} | 공격력 : {ItemStat} | {ItemInfo} | {ItemValue}G]";
        }
    }
}
class Item
{
    public ItemPro itemPro;
    public Item(ItemPro itemPro)
    {
        this.itemPro = itemPro;
    }
    public static ItemPro BeginnerArmor()
    {
        return new ItemPro("수련자의 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, true, false);
    }
    public static ItemPro IronArmor()
    {
        return new ItemPro("무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, true, false);
    }
    public static ItemPro SpartaArmor()
    {
        return new ItemPro("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, true, false);
    }
    public static ItemPro OldSword()
    {
        return new ItemPro("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600, true, false);
    }
    public static ItemPro BronzeAx()
    {
        return new ItemPro("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500, true, false);
    }
    public static ItemPro SpartaSphere()
    {
        return new ItemPro("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500, true, false);
    }
    public override string ToString()
    {
        return itemPro.ToString();
    }
}

