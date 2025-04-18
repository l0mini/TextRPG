using System.Text.Json.Serialization;

namespace TextRPG
{
    [Serializable]
    public class Player//상태 보기
    {
        public int clearStack = 0;
        public int playerLevel = 1;
        string name = "스파르타인";
        string jop = "전사";
        public float attackPower = 10;
        public int defensePower = 5;
        public int health = 100;
        public int haveGold = 0;
        public float WeaponPower = 0;
        public int ArmorPower = 0;

        public float totalAttack => attackPower + WeaponPower;
        public int totalDefense => defensePower + ArmorPower;
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
        public void LevelUp()
        {
            if (clearStack % 5 == 0)
            {
                playerLevel++;
                LevelUpStat();
            }
          
        }
        public void LevelUpStat()
        {
            attackPower += 0.5f;
            defensePower += 1;
        }
        public Place PlayerInfoScene()
        {
            LevelUp();
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {playerLevel}");
            Console.WriteLine($"던전 클리어 횟수 : {clearStack}");
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
}

