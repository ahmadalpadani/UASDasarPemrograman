// Poin.cs
public class Poin
{
    private int _poin;

    public Poin()
    {
        _poin = 0;
    }

    public int DapatkanPoin() => _poin;

    public void TambahPoin(int poin)
    {
        _poin += poin;
    }

}
