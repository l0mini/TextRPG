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
        RestRoom restScene;
        Player player;
        Shop shop;
        Buy buy;
        Sell sell;
        Inventory inventory;
        ItemEquipped itemEquipped;
        Place currentPlace;
        private ItemPro itemProInstance;

        public GameManager()
        {
            startScene = new StartScene();
            player = new Player();
            shop = new Shop(player);
            inventory = new Inventory(player);
            itemEquipped = new ItemEquipped(player, inventory);
            buy = new Buy(shop.AllItems, player, inventory, itemEquipped);
            sell = new Sell(player, inventory);
            restScene = new RestRoom(player);
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
                        currentPlace = player.PlayerInfoScene();
                        break;
                    case Place.Inventory:
                        currentPlace = inventory.InventoryScene();
                        break;
                    case Place.ItemEquipped:
                        currentPlace = itemEquipped.EqualsScene();
                        break;
                    case Place.Shop:
                        currentPlace = shop.ShopScene();
                        break;
                    case Place.Buy:
                        currentPlace = buy.BuyScene();
                        break;
                    case Place.Sell:
                        currentPlace = sell.SellScene();
                        break;
                    case Place.Restroom:
                        currentPlace = restScene.RestScene();
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
            Console.WriteLine("4. 휴식하기");
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
                case 4:
                    return Place.Restroom;
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
       
        int level = 1;
        string name = "플레이어";
        string jop = "전사";
        int attackPower = 10;
        int defensePower = 5;
        public int health = 100;
        public int haveGold = 10000;
        public int WeaponPower;
        public int ArmorPower;
        public void UpdateStatsFromInventory(List<Item> items)
        {
            WeaponPower = 0;
            ArmorPower = 0;

            foreach (var item in items)
            {
                if (item.itemPro.IsEquipped)
                {
                    if (item.itemPro.IsWeapon)
                        WeaponPower += item.itemPro.ItemStat;
                    if (item.itemPro.IsArmor)
                        ArmorPower += item.itemPro.ItemStat;
                }
            }
        }

        public Place PlayerInfoScene()
        {
            

            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {level}");
            Console.WriteLine($"{name} ({jop})");
            if (WeaponPower > 0)
                Console.WriteLine($"공격력 : {attackPower} (+{WeaponPower})");
            else
                Console.WriteLine($"공격력 : {attackPower}");
            if (ArmorPower > 0)
                Console.WriteLine($"방어력 : {defensePower} (+{ArmorPower})");
            else
                Console.WriteLine($"방어력 : {defensePower}");
            Console.WriteLine($"체 력 : {health}");
            Console.WriteLine($"Gold : {haveGold} G");
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
        Player player;

        public Inventory(Player player)
        {
            this.player = player;
            this.AllItems = new List<Item>();
        }

        public Place InventoryScene()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            if (AllItems.Count == 0)
            {
                Console.WriteLine(" 보유한 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < AllItems.Count; i++)
                {
                    Console.WriteLine(AllItems[i].itemPro.ToInventoryString());
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
     class ItemEquipped
    {
        public Inventory inventory;
        public Player player;
        
        public ItemEquipped(Player player, Inventory inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public Place EqualsScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();

                if (inventory.AllItems.Count == 0)
                {
                    Console.WriteLine("보유한 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < inventory.AllItems.Count; i++)
                    {
                        Console.WriteLine($"{i+1}{inventory.AllItems[i].itemPro.ToInventoryString()}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                        return Place.Inventory;

                    int index = input - 1;
                    if (index >= 0 && index < inventory.AllItems.Count)
                    {
                        var selectedItem = inventory.AllItems[index];
                        if (selectedItem.itemPro.IsEquipped)
                        {
                            Console.WriteLine("이미 장착한 아이템입니다.");
                            Thread.Sleep(1000);
                        }
                        else { 
                        foreach (var item in inventory.AllItems)
                        {
                            if (item.itemPro.IsArmor && selectedItem.itemPro.IsArmor)
                                item.itemPro.IsEquipped = false;
                            if (item.itemPro.IsWeapon && selectedItem.itemPro.IsWeapon)
                                item.itemPro.IsEquipped = false;
                        }


                        selectedItem.itemPro.IsEquipped = true;
                        player.UpdateStatsFromInventory(inventory.AllItems);
                        Console.WriteLine($"'{selectedItem.itemPro.ItemName}'를 장착했습니다!");
                        Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다!");
                        Thread.Sleep(1000);
                    }
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                }
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
            AllItems.Add(new Item(Item.Sparta300Armor()));
            AllItems.Add(new Item(Item.ArmorOfSpartacus()));
            AllItems.Add(new Item(Item.OldSword()));
            AllItems.Add(new Item(Item.BronzeAx()));
            AllItems.Add(new Item(Item.SpartaSphere()));
            AllItems.Add(new Item(Item.Sparta300Sphere()));
            AllItems.Add(new Item(Item.SphereOfSpartacus()));
        }

        public Place ShopScene()
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
            Console.WriteLine("2. 아이템 판매");
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
                return Place.Buy;
            }
            else if (choice == 0)
            {
                return Place.Start;
            }
            else if(choice == 2)
            {
                return Place.Sell;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                return Place.Shop;
            }
        }
    }
    class Buy//구매 상점
    {
        public List<Item> AllItems;
        Inventory inventory;
        ItemEquipped itemEquipped;
       Player player;
        public Buy(List<Item> AllItems, Player player, Inventory inventory, ItemEquipped itemEquipped)
        {
            this.inventory = inventory;
            this.player = player;
            this.AllItems = AllItems;
            this.itemEquipped = itemEquipped;
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
                Console.WriteLine($"{player.haveGold}G");
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
                        return Place.Buy;

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
                        inventory.AllItems.Add(selectedItem);
                       
                        Console.WriteLine("구매 완료!");
                    }
                    else if (!selectedItem.itemPro.IsSold && player.haveGold < selectedItem.itemPro.ItemValue)
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Thread.Sleep(1000);
                    }
                    else if (selectedItem.itemPro.IsSold)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Buy;
                }
            }
        }
    } 
    class Sell//판매 상점
    {

        public Inventory inventory;
        public Player player;

        public Sell(Player player, Inventory inventory)
        {

            this.player = player;
            this.inventory = inventory;
        }
        public Place SellScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 팔 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.haveGold}G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < inventory.AllItems.Count; i++)//아이템의 배열을 위부터 반복해 출력
                {
                    Console.WriteLine($"{i + 1}{inventory.AllItems[i].itemPro.ToSellString()}");
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
                        return Place.Sell;
                    }
                }
                if (choice == 0) return Place.Shop;

                int index = choice - 1;
                
                

                if (index >= 0 && index < inventory.AllItems.Count)
                {
                    var selectedItem = inventory.AllItems[index];
                    
                    if (selectedItem.itemPro.IsSold)
                    {
                        player.haveGold += selectedItem.itemPro.ItemValue*17/20;
                        selectedItem.itemPro.IsSold = false;
                        
                        if (selectedItem.itemPro.IsEquipped)
                        {
                            selectedItem.itemPro.IsEquipped = false;
                            if (selectedItem.itemPro.IsWeapon)
                                player.WeaponPower -= selectedItem.itemPro.ItemStat;
                            if (selectedItem.itemPro.IsArmor)
                                player.ArmorPower -= selectedItem.itemPro.ItemStat;
                        }
                        inventory.AllItems.Remove(selectedItem);

                       
                        Console.WriteLine("판매 완료!");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Sell;
                }
            }
        }
    }
    class RestRoom
    {Player player;
        public RestRoom(Player player)
        { 
            this.player = player;
        }
        public Place RestScene()
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine("500G 를 내면 체력을 회복할 수 있습니다.");
            Console.WriteLine($"보유 골드 : {player.haveGold}");
            Console.WriteLine();
            Console.WriteLine("1. 휴식하기");
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
                    return Place.Restroom;

                }
            }
            if (choice == 0)
            {
                return Place.Start;
            }
            else if(choice == 1)
            {
                Console.WriteLine("여관에서 하룻밤 푹 쉬었다!");
                player.health = 100;
                Thread.Sleep(1000);
                return Place.Restroom;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                return Place.Restroom;
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
    public bool IsEquipped { get; set; }


    public ItemPro(string name, int stat, string info, int value, bool isArmor, bool isWeapon)
    {
        ItemName = name;
        ItemStat = stat;
        ItemValue = value;
        ItemInfo = info;
        IsSold = false;
        IsArmor = isArmor;
        IsWeapon = isWeapon;
        IsEquipped = false;
    }

    // 인벤토리에서 출력용
    public string ToInventoryString()
    {
        string equipStatus = IsEquipped ? "[E]" : "";
        if (IsArmor)
            return $"-{equipStatus}{ItemName} | 방어력 : {ItemStat} | {ItemInfo}";
        else
            return $"-{equipStatus}{ItemName} | 공격력 : {ItemStat} | {ItemInfo}";
    }
    public string ToSellString()
    {
        string equipStatus = IsEquipped ? " [E]" : "";

        if (IsSold && IsArmor)
        {
            return $"-{ItemName} | 방어력 : {ItemStat} | {ItemInfo} | {ItemValue*17/20}G";
        }
        else if (IsSold && IsWeapon)
        {
            return $"-{ItemName} | 공격력 : {ItemStat} | {ItemInfo} | {ItemValue * 17 / 20}G";
        }
        else if (!IsSold && IsArmor)
        {
            return $"-{ItemName} | 방어력 : {ItemStat} | {ItemInfo} | [판매완료]";
        }
        else
        {
            return $"-{ItemName} | 공격력 : {ItemStat} | {ItemInfo} | [판매완료]";
        }
    }

    public override string ToString()
    {
        string equipStatus = IsEquipped ? " [E]" : "";

        if (IsSold && IsArmor)
        {
            return $"{ItemName} | 방어력 : {ItemStat} | {ItemInfo} | [구매 완료]";
        }
        else if (IsSold && IsWeapon)
        {
            return $"{ItemName} | 공격력 : {ItemStat} | {ItemInfo} | [구매 완료]";
        }
        else if (!IsSold && IsArmor)
        {
            return $"{ItemName} | 방어력 : {ItemStat} | {ItemInfo} | {ItemValue}G";
        }
        else
        {
            return $"{ItemName} | 공격력 : {ItemStat} | {ItemInfo} | {ItemValue}G]";
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
        return new ItemPro("가죽 갑옷", 5, "말린 소가죽으로 만든 갑옷입니다.", 1000, true, false);
    }
    public static ItemPro IronArmor()
    {
        return new ItemPro("강철 갑옷", 9, "일반 병사에게 보급되는 평범한 갑옷입니다.", 2000, true, false);
    }
    public static ItemPro SpartaArmor()
    {
        return new ItemPro("스파르타의 갑옷", 16, "스파르타의 전사들이 사용했다는 갑옷입니다.", 4000, true, false);
    } public static ItemPro Sparta300Armor()
    {
        return new ItemPro("스파르타의 최후의 갑옷", 25, "스파르타 최후의 300인의 전사가 사용한 갑옷입니다.", 8000, true, false);
    } public static ItemPro ArmorOfSpartacus()
    {
        return new ItemPro("스파르타쿠스의 의지", 40, "스파르타쿠스만이 사용할 수 있는 전설의 창입니다.", 15000, true, false);
    }
    public static ItemPro OldSword()
    {
        return new ItemPro("나무 창", 2, "나무를 뾰족하게 깎아 만든 창 입니다.", 600, false, true);
    }
    public static ItemPro BronzeAx()
    {
        return new ItemPro("강철 창", 5, "일반 병사에게 보급되는 평범한 창입니다.", 1500, false, true);
    }
    public static ItemPro SpartaSphere()
    {
        return new ItemPro("스파르타의 창", 10, "스파르타의 전사들이 사용했다는 창입니다.", 3500, false, true);
    }
    public static ItemPro Sparta300Sphere()
    {
        return new ItemPro("스파르타 최후의 창", 16, "스파르타의 최후의 300인의 전사가 사용한 창입니다", 8000, false, true);
    } 
    public static ItemPro SphereOfSpartacus()
    {
        return new ItemPro("스파르타쿠스의 분노", 30, "스파르타쿠스만이 사용할 수 있는 전설의 창입니다.", 15000, false, true);
    }
    

    public override string ToString()
    {
        return itemPro.ToString();
    }
}

