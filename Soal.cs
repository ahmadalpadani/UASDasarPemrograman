public class Soal
{
    public string Pertanyaan { get; set; }
    public string[] Pilihan { get; set; }
    public string Jawaban { get; set; }

    public Soal(string pertanyaan, string[] pilihan, string jawaban)
    {
        Pertanyaan = pertanyaan;
        Pilihan = pilihan;
        Jawaban = jawaban;
    }

    public bool CekJawaban(string jawabanUser)
    {
        return jawabanUser.Trim().Equals(Jawaban.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
