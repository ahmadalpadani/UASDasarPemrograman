using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Game
{
    private User user1;
    private User user2;
    private List<Soal> soalList;
    private Level level;
    private Poin poin1;
    private Poin poin2;
    private bool isPlayer1Turn = true; 

    public Game(User player1, User player2)
    {
        user1 = player1;
        user2 = player2;
        soalList = new List<Soal>();
        level = new Level();
        poin1 = new Poin();
        poin2 = new Poin();
    }

    public void MulaiGame()
    {
        var levelPilih = level.PilihLevel();
        PersiapkanSoal(levelPilih);
        MainKuis();
    }

    private void PersiapkanSoal(Level.Tingkat level)
    {
        List<Soal> soalEasy = new List<Soal>
        {
            new Soal("Ibu kota negara Indonesia adalah?", new string[] { "Semarang", "Jakarta", "Denpasar", "Balikpapan" }, "Jakarta"),
            new Soal("Mata uang resmi Jepang adalah?", new string[] { "Ringgit", "Rupiah", "Yen", "Rupee" }, "Yen"),
            new Soal("Planet terbesar di tata surya adalah?", new string[] { "Uranus", "Neptune", "Jupiter", "Mars" }, "Jupiter"),
            new Soal("Samudra terbesar di dunia adalah?", new string[] { "Samudra Hindia", "Samudra Pasifik", "Samudra Atlantik", "Samudra Selatan" }, "Samudra Pasifik"),
            new Soal("Hewan yang dapat hidup di air dan darat disebut?", new string[] { "Mamalia", "Amfibi", "Reptil", "Serangga" }, "Amfibi"),
            new Soal("Presiden pertama Indonesia adalah?", new string[] { "Ir. Soekarno", "Joko Widodo", "Prof. Habibie", "Abdurrahman Wahid" }, "Ir. Soekarno"),
            new Soal("Benua terkecil di dunia adalah?", new string[] { "Eropa", "Afrika", "Australia", "Amerika Selatan" }, "Australia"),
            new Soal("Hutan hujan terbesar di dunia berada di?", new string[] { "Amazon", "Kalimantan", "Madagaskar", "Papua Nugini" }, "Amazon"),
            new Soal("Alat untuk mengukur suhu adalah?", new string[] { "Mikroskop", "Barometer", "Termometer", "Seismograf" }, "Termometer"),
            new Soal("Ikan terbesar di dunia adalah?", new string[] { "Hiu Paus", "Ikan Pari", "Hiu Martil", "Paus Sperma" }, "Hiu Paus")
        };

        List<Soal> soalMedium = new List<Soal>
        {
            new Soal("Negara dengan luas wilayah terbesar adalah?", new string[] { "Tiongkok", "Rusia", "Australia", "Amerika Serikat" }, "Rusia"),
            new Soal("Perubahan wujud air menjadi uap disebut?", new string[] { "Filtrasi", "Koagulasi", "Evaporasi", "Kristalisasi" }, "Evaporasi"),
            new Soal("Penemu lampu pijar adalah?", new string[] { "Wright Bersaudara", "Thomas Edison", "Nikola Tesla", "Benjamin Franklin" }, "Thomas Edison"),
            new Soal("Ketinggian Gunung Everest sekitar?", new string[] { "5.100 m", "6.300 m", "8.848 m", "9.100 m" }, "8.848 m"),
            new Soal("Organ terbesar manusia adalah?", new string[] { "Otak", "Kulit", "Jantung", "Ginjal" }, "Kulit"),
            new Soal("Laut Mati terkenal karena?", new string[] { "Memiliki ombak besar", "Mempunyai kadar garam tinggi", "Banyak terumbu karang", "Terdalam di dunia" }, "Mempunyai kadar garam tinggi"),
            new Soal("Negara yang dijuluki Negeri Matahari Terbit adalah?", new string[] { "Tiongkok", "Jepang", "Thailand", "Korea" }, "Jepang"),
            new Soal("Badai tropis di Asia Tenggara disebut?", new string[] { "Tornado", "Topan", "Cyclone", "Storm Wave" }, "Topan"),
            new Soal("Sungai Amazon berada di?", new string[] { "Asia", "Afrika", "Amerika Selatan", "Australia" }, "Amerika Selatan"),
            new Soal("Penemu mesin uap modern adalah?", new string[] { "Thomas Newcomen", "James Watt", "Henry Ford", "George Stephenson" }, "James Watt")
        };

        List<Soal> soalHard = new List<Soal>
        {
            new Soal("Teori yang menyatakan benua dulunya menyatu adalah?", new string[] { "Teori Continental Drift", "Teori Evolusi Darwin", "Teori Quantum", "Teori Geosentris" }, "Teori Continental Drift"),
            new Soal("Negara dengan sistem Absolute Monarchy adalah?", new string[] { "Norwegia", "Swedia", "Arab Saudi", "Belanda" }, "Arab Saudi"),
            new Soal("Perjanjian internasional pengurangan CFC adalah?", new string[] { "Protokol Rio", "Protokol Montreal", "Protokol Tokyo", "Protokol Manila" }, "Protokol Montreal"),
            new Soal("Pesawat jet terbang di lapisan?", new string[] { "Mesosfer", "Troposfer", "Stratosfer", "Eksosfer" }, "Stratosfer"),
            new Soal("Proses pelepasan uap air tumbuhan disebut?", new string[] { "Osmosis", "Transpirasi", "Absorpsi", "Kemosintesis" }, "Transpirasi"),
            new Soal("Penemu vaksin rabies adalah?", new string[] { "Alexander Fleming", "Louis Pasteur", "Edward Jenner", "Joseph Lister" }, "Louis Pasteur"),
            new Soal("Lempeng pembentuk Himalaya adalah?", new string[] { "India dan Afrika", "Pasifik dan Eurasia", "India dan Eurasia", "Australia dan Arab" }, "India dan Eurasia"),
            new Soal("Negara dengan kepadatan penduduk tertinggi adalah?", new string[] { "Qatar", "Monako", "Jepang", "Belanda" }, "Monako"),
            new Soal("Bintang terdekat setelah Matahari adalah?", new string[] { "Rigel", "Polaris", "Proxima Centauri", "Bellatrix" }, "Proxima Centauri"),
            new Soal("Gas terbesar penyebab efek rumah kaca adalah?", new string[] { "CO₂", "Nitrogen", "Ozon", "Argon" }, "CO₂")
        };


        Random rand = new Random();

        if (level == Level.Tingkat.Easy)
        {
            soalList = soalEasy.OrderBy(x => rand.Next()).Take(10).ToList();
        }
        else if (level == Level.Tingkat.Medium)
        {
            soalList = soalMedium.OrderBy(x => rand.Next()).Take(7).ToList();
            soalList.AddRange(soalEasy.OrderBy(x => rand.Next()).Take(3));
        }
        else if (level == Level.Tingkat.Hard)
        {
            soalList = soalHard.OrderBy(x => rand.Next()).Take(7).ToList();
            soalList.AddRange(soalMedium.OrderBy(x => rand.Next()).Take(3));
        }
    }

    private void MainKuis()
    {
        int count = 0;
        while (count < soalList.Count)
        {
            if (isPlayer1Turn)
            {
                Console.WriteLine($"{user1.Nama}'s Turn:");
                PemainBermain(user1, poin1);
            }
            else
            {
                Console.WriteLine($"{user2.Nama}'s Turn:");
                PemainBermain(user2, poin2);
            }

            isPlayer1Turn = !isPlayer1Turn;  
            count++;
        }

        AkhiriGame();
    }

    private void PemainBermain(User pemain, Poin poin)
    {
        var soal = soalList.First();
        soalList.RemoveAt(0);

        Console.WriteLine($"Soal: {soal.Pertanyaan}");
        for (int i = 0; i < soal.Pilihan.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {soal.Pilihan[i]}");
        }

        bool jawabanBenar = JawabSoalDenganTimer(soal, pemain, poin);

        if (jawabanBenar)
        {
            Console.WriteLine("Jawaban Anda benar!");
        }
        else
        {
            Console.WriteLine($"Jawaban Anda salah! Jawaban yang benar adalah: {soal.Jawaban}");
        }
    }

    private bool JawabSoalDenganTimer(Soal soal, User pemain, Poin poin)
    {
        Console.WriteLine("Waktu Anda mulai sekarang, jawab dalam waktu 15 detik!");
        DateTime startTime = DateTime.Now;

        string jawabanUser = null;

        while ((DateTime.Now - startTime).TotalSeconds < 15)
        {
            if (Console.KeyAvailable)
            {
                jawabanUser = Console.ReadLine()?.Trim();
                break;
            }
        }

        if (jawabanUser == null)
        {
            Console.WriteLine("Waktu habis! Jawaban Anda salah.");
            return false;
        }

        int jawabanIndex = -1;
        if (int.TryParse(jawabanUser, out jawabanIndex) && jawabanIndex >= 1 && jawabanIndex <= soal.Pilihan.Length)
        {
            jawabanUser = soal.Pilihan[jawabanIndex - 1]; 
        }
        else
        {
            Console.WriteLine("Input tidak valid! Anda harus memilih angka antara 1 dan 4.");
            return false;
        }

        bool isJawabanBenar = soal.CekJawaban(jawabanUser);
        if (isJawabanBenar)
        {
            poin.TambahPoin(10);  
        }
        return isJawabanBenar;
    }

    private void AkhiriGame()
    {
        Console.WriteLine($"Game selesai! Poin {user1.Nama}: {poin1.DapatkanPoin()}");
        Console.WriteLine($"Poin {user2.Nama}: {poin2.DapatkanPoin()}");

        string pemenang = poin1.DapatkanPoin() > poin2.DapatkanPoin() ? user1.Nama : user2.Nama;
        Console.WriteLine($"Pemenang: {pemenang}");

        Console.WriteLine("Apakah Anda ingin bermain lagi? (y/n)");
        string jawab = Console.ReadLine();
        if (jawab.ToLower() == "y")
        {
            MulaiGame();
        }
        else
        {
            Console.WriteLine("Terima kasih sudah bermain!");
        }
    }
}
