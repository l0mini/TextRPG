namespace TextRPG
{
    internal class Program
    {
        class Start//시작화면
        {
            public void StartSence()
            {
                Player player = new Player();
                Inventory inventory = new Inventory();
                Shop shop = new Shop();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                    Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("1. 상태보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");

                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        player.PlayerInfo();
                    }
                    else if (choice == 2)
                    {
                        inventory.ShowInven();
                    }
                    else if (choice == 3)
                    { 
                        shop.ShowShop();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("아무 숫자를 입력해 다시시도");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
        }
        class Player//상태 보기
        {
            Start start = new Start();

            int level = 1;
            string name = "플레이어";
            string jop = "전사";
            int attackPower = 10;
            int defensePower = 5;
            int health = 100;
            int haveGold = 1500;

            public void PlayerInfo()
            {
                while (true)
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
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 0)
                    {
                        start.StartSence();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("아무 숫자를 입력해 다시시도");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
        }

        class Inventory//인벤토리
        {
            Start Start = new Start();
            ItemEquipped itemEquipped = new ItemEquipped();
            string[] Item = { }; //아이템들어갈 배열
            public void ShowInven()
            {
                while (true)
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

                    if (choice == 0)
                    {
                        Start.StartSence();
                    }
                    else if (choice == 1)
                    {
                        itemEquipped.Equals();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("아무 숫자를 입력해 다시시도");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
        }

        class ItemEquipped//장착관리
        {
            public void Equals()
            {

            }
        }

        class Shop//상점
        {
            int haveGold = 0;
            Player Player = new Player();
            Shopping shopping = new Shopping();
            Start start = new Start();
            public void ShowShop()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine();
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($"{haveGold}G");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine("아이템 리스트 들어갈 곳");
                    Console.WriteLine();
                    Console.WriteLine("1. 아이템 구매");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 0)
                    {
                        start.StartSence();
                    }
                    else if (choice == 1)
                    {
                        shopping.BuyScene();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("아무 숫자를 입력해 다시시도");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
        }

        class Shopping//상점 구매
        {
            public void BuyScene()
            {

            }
        }

        static void Main(string[] args)
        {
            Start start = new Start();
            start.StartSence();
        }
    } 
}

