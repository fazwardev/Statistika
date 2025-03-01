namespace Statistika_Satu
{
    internal class Program
    {
        public double HitungPeluang(double Rusak, double nTotal, double Persentase)
        {
            double Peluang_Rusak, Peluang_Bagus, Peluang, Persen_Des;

            if (Rusak == 0)
            {
                return 0;
            }
            else if (nTotal == 0)
            {
                return 0;
            }
            else if (Persentase == 0)
            {
                return 0;
            }

            Persen_Des = Persentase / 100;
            Peluang_Rusak = Rusak / 100;
            Peluang_Bagus = 1 - Peluang_Rusak;

            Persen_Des = Math.Pow(Persen_Des, Rusak);
            Peluang = Math.Pow(Peluang_Bagus, (nTotal - Rusak));

            Console.WriteLine("PDes: " + Persen_Des);
            Console.WriteLine("PRus: " + Peluang_Rusak);
            Console.WriteLine("PBag: " + Peluang_Bagus);
            Console.WriteLine("Pel: " + Peluang);

            return Persen_Des * Peluang;
        }

        public double HitungFaktor(double Rusak, double nTotal)
        {
            double a = 1;
            double b = 1;
            double c = 1;

            if (Rusak == 0)
            {
                return 0;
            } 
            else if (nTotal == 0)
            {
                return 0;
            }

            // Faktor yang atas
            for (int i = 1; i <= nTotal; i++)
            {
                a *= i;
            }

            // Faktor yang bawah kiri
            for (int i = 1; i <= Rusak; i++)
            {
                b *= i;
            }

            // Faktor yang bawah kanan
            for (int i = 1; i <= (nTotal - Rusak); i++)
            {
                c *= i;
            }

            Console.WriteLine("a: " + a);
            Console.WriteLine("b: " + b);
            Console.WriteLine("c: " + c);

            return a / (b * c);
        }

        static void Main(string[] args)
        {
        Kesini:

            Console.WriteLine();

            char back = '0';

            Console.Write("Masukkan jumlah barang rusak: ");
            double Barang_Rusak = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan jumlah barang total: ");
            double Barang_Total = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan persentase barang rusak: ");
            double Persentase = Convert.ToDouble(Console.ReadLine());
            
            Program Hasil = new Program();
            double Jawaban = Hasil.HitungFaktor(Barang_Rusak, Barang_Total) * Hasil.HitungPeluang(Barang_Rusak, Barang_Total, Persentase);
            Console.WriteLine("Hasil: " + Jawaban);

            if(back != 'p')
            {
                Console.Write("tekan P untuk kembali ke menu awal: ");
                back = Convert.ToChar(Console.ReadLine());
                goto Kesini;
          
            }
            else
            {
                Environment.Exit(0);
            }

        }
    }
}
