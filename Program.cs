namespace TextRPG
{
    internal class Program
    {
       
        
        public class GamePlace
        {
            Start start = new Start();
            public void Start()
            {
                start.StartSence();
            }
            

            //시작화면
            //상태 보기
            //인벤토리
            //장착관리
            //상점
        }
          class Start
        {
             public void StartSence()
            {
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
                }
            }
            class Player
            {
                int level = 1;
                string name = "플레이어";
                string jop = "전사";
                int attackPower = 10;
                int defensePower = 5;
                int health = 100;
                int haveGold = 1500;
            }

            class Inventory
            {

            }

            class ItemEquipped
            {

            }

            class Shop
            {

            }

            class Shopping
            {

            }


            static void Main(string[] args)
            {
                GamePlace gamePlace = new GamePlace();
                gamePlace.Start();

                Console.Clear();

                Console.ReadLine();
            }
        }
    }
}
