using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Dungeon
    {
        public int Level;
        Player Player;
        public Dungeon(Player player)
        {

        }

        //던전 플레이스
        public Place DungeonScene()
        {
            Console.Clear();
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 늑대가 우는 숲 | 방어력 5 이상 권장");
            Console.WriteLine("2. 콜로세움 | 방어력 20 이상 권장");
            Console.WriteLine("3. 페르시아 전쟁 | 방어력 50 이상 권장");
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
                    return Place.Dungeon;
                }
            }
            Level = choice;
            switch (choice)
            {
                case 1:
                    return Place.DungeonClear;
                case 2:
                    return Place.DungeonClear;
                case 3:
                    return Place.DungeonClear;
                case 0:
                    return Place.Start;
                default:
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Dungeon;
            }
            
        
           
        }
        //세가지 난이도

        //쉬운던전
        //일반 던전
        //어려운 던전
        //권장 방어력이 낮다면
        //40% 확률로 실패
        //권장 방어력보다 높다면
        //던전 클리어
        //체력 소모, 던전 클리어 횟수++

        //난이도별 보상 함수
        //공격력 ~ 공격력두배 % 추가보상
    }
}

