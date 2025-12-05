public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di Kuis Trivia!");
        Console.WriteLine("Memulai permainan...");
        
        Console.Write("Masukkan nama pemain 1: ");
        string namaPemain1 = Console.ReadLine();

        Console.Write("Masukkan nama pemain 2: ");
        string namaPemain2 = Console.ReadLine();

        User player1 = new User(namaPemain1);
        User player2 = new User(namaPemain2);

        Game game = new Game(player1, player2);

        game.MulaiGame();
    }
}
