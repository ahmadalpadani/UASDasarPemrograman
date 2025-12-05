// Level.cs
public class Level
{
    public enum Tingkat { Easy, Medium, Hard }

    public Tingkat PilihLevel()
    {
        Console.WriteLine("Pilih level kuis (Easy, Medium, Hard): ");
        string input = Console.ReadLine().ToLower();

        return input switch
        {
            "easy" => Tingkat.Easy,
            "medium" => Tingkat.Medium,
            "hard" => Tingkat.Hard,
            _ => Tingkat.Easy
        };
    }
}
