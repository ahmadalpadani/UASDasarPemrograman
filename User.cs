public class User
{
    public string Nama { get; set; }
    public int Poin { get; set; }

    public User(string nama)
    {
        Nama = nama;
        Poin = 0;
    }

    public void TambahPoin(int poin)
    {
        Poin += poin;
    }
}
