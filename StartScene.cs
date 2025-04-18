namespace TextRPG
{
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
            Console.WriteLine("5. 던전입장");
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
                case 5:
                    return Place.Dungeon;
                case 0:
                    return Place.Exit;
                default:
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Start;
            }
        }
    }
}

