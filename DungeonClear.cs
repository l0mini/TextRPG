using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class DungeonClear
    {
        private static Random random = new Random();
        

        Player Player;
        Dungeon Dungeon;
        public DungeonClear(Player player, Dungeon dungeon) 
        {
            this.Dungeon = dungeon;
            this.Player = player;
        }
        
        string[] dungeoNames = { "늑대가 우는 숲", "콜로세움", "페르시아 전쟁" };
        public Place DungeonClearScene()
        {
           
            float minBouse = Player.totalAttack;
            float maxBouse = Player.totalAttack * 2;
            float bonusPercent = random.Next((int)minBouse, (int)(maxBouse + 1)) /100.0f;
            int Level = Dungeon.Level;
            string dungeonName = dungeoNames[Level-1];
            int failChance = random.Next(0,101);
            

            Console.Clear();
            Console.WriteLine("[전투 종료]");
            Console.WriteLine();
           
            if (Level == 1)
            {
                int mDefense=5;
                int gold = 1000;
                if (Player.totalDefense >= mDefense)
                {
                    DungeonClear(mDefense, gold);

                }
                else if (Player.totalDefense < mDefense)
                {
                    if (failChance < 40)
                    {
                        DungeonFail();
                    }
                    else
                    {
                        DungeonClear(mDefense, gold);
                    }
                }
            }
            else if (Level == 2)
            {
                int mDefense = 20;
                int gold = 2500;
                if (Player.totalDefense >= mDefense)
                {
                    DungeonClear(mDefense, gold);
                }
                else if (Player.totalDefense < mDefense)
                {
                    if (failChance < 40)
                    {
                        DungeonFail();
                    }
                    else
                    {
                        DungeonClear(mDefense, gold);
                    }
                    
                }
            }
            else if (Level == 3)
            {
                int mDefense = 50;
                int gold = 4500;
                if (Player.totalDefense >= mDefense)
                {
                    DungeonClear(mDefense, gold);
                }
                else if (Player.totalDefense < mDefense)
                {
                    if (failChance < 40)
                    {
                        DungeonFail();
                    }
                    else
                    {
                        DungeonClear(mDefense, gold);
                    }

                }


            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
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
                    return Place.DungeonClear;
                }
            }

            switch (choice)
            {
                case 0:
                    return Place.Start;
                default:
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Dungeon;
            }
            void DungeonClear(int mDefense, int gold)
            {
                //체력 계산
                int damage = random.Next(20, 36) - (Player.totalDefense - mDefense); // 방어력 적용
                if (damage < 0) damage = 0;

                int beforeHealth = Player.health;
                Player.health -= damage;
                if (Player.health <= 0)
                {
                    Player.health = 1;
                    Player.playerLevel = Player.playerLevel - 3;
                    if (Player.playerLevel < 0) Player.playerLevel = 0;
                    Player.haveGold = Player.haveGold - 1500;
                    Console.WriteLine("치명적인 부상을 입었습니다!");
                    Console.WriteLine("치료에 상당한 골드를 지불했습니다.");
                }
                else
                {
                    // 골드 보상
                    int rewardGold = (int)(gold * (1 + bonusPercent));
                    int beforeGold = Player.haveGold;
                    Player.haveGold += rewardGold;
                    //던전 클리어 스택
                    Player.clearStack += 1;
                    //콘솔
                    Console.WriteLine($"{dungeonName}전투에서 승리 하였습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[전투 결과]");
                    Console.WriteLine($"체력 {beforeHealth} -> {Player.health}");
                    Console.WriteLine($"Gold {beforeGold} -> {Player.haveGold} (+{rewardGold}G)");
                }

            }
            void DungeonFail()
            {
                int beforeHealth = Player.health;
                Player.health -= 50;
                if (Player.health <= 0)
                {
                    Player.health = 1;
                    Player.playerLevel = Player.playerLevel - 3;
                    if (Player.playerLevel < 0) Player.playerLevel = 1;
                    Player.haveGold = Player.haveGold - 1500;
                    Console.WriteLine("치명적인 부상을 입었습니다!");
                    Console.WriteLine("치료에 상당한 골드를 지불했습니다.");
                    if (Player.haveGold < 0)
                    {
                        Console.WriteLine("Gold가 부족해 빚이 생겼습니다.");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"{dungeonName}전투에서 패배했습니다!");
                Console.WriteLine($": 체력 : {beforeHealth} -> {Player.health}");
            }

        }
        
    }
}
