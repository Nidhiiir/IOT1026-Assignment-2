namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            bool quit = false;
            string user;
            TreasureChest chest = new TreasureChest();
            chest.Manipulate(TreasureChest.Action.Unlock);
            Console.WriteLine(chest.ToString());
            while(quit == false){
                Console.WriteLine("1.) Open\n");
                Console.WriteLine("2.) Close\n");
                Console.WriteLine("3.) Lock\n");
                Console.WriteLine("4.) Unlock\n");
                Console.WriteLine("5.) Exit\n");
                user =  Console.ReadLine();

                switch(user){
                    case "1":
                        chest.Manipulate(TreasureChest.Action.Open);
                    break;
                    case "2":
                        chest.Manipulate(TreasureChest.Action.Close);
                      break;
                    case "3":
                        chest.Manipulate(TreasureChest.Action.Lock);
                break;
                    case "4":
                        chest.Manipulate(TreasureChest.Action.Unlock);
                            break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("this option not exists");
                        break;

                }}}}}