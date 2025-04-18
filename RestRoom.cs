namespace TextRPG
{
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
                if (player.haveGold >= 500)
                {
                    player.haveGold -= 500;
                    Console.WriteLine("여관에서 하룻밤 푹 쉬었다!");
                    player.health = 100;
                    Thread.Sleep(1000);
                    return Place.Restroom;
                }
                else
                {
                    Console.WriteLine("어디서 돈도 없이 들어와!");
                    Thread.Sleep(1000);
                    return Place.Restroom;
                }
                
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

