using System;

class Program
{
    static int EnDusukEnerjiMaliyeti(int[,] enerji, int N)
    {
        int[,] dp = new int[N, N];
        dp[0, 0] = enerji[0, 0];

        // İlk satırdaki hücrelerin maliyetlerini hesapla (sadece sağa hareket edilebilir)
        for (int j = 1; j < N; j++)
            dp[0, j] = dp[0, j - 1] + enerji[0, j];

        // İlk sütundaki hücrelerin maliyetlerini hesapla (sadece aşağı hareket edilebilir)
        for (int i = 1; i < N; i++)
            dp[i, 0] = dp[i - 1, 0] + enerji[i, 0];

        // Diğer hücreler için sağa, aşağıya veya sağ aşağı diyagonal hareketleri değerlendir
        for (int i = 1; i < N; i++)
        {
            for (int j = 1; j < N; j++)
            {
                dp[i, j] = enerji[i, j] + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
            }
        }

        // Hedef noktadaki (N-1, N-1) minimum enerji maliyeti
        return dp[N - 1, N - 1];
    }

    static void Main()
    {
        // Enerji matrisi örneği
        int[,] enerji = {
            { 4, 7, 8, 6, 4 },
            { 6, 7, 3, 9, 2 },
            { 3, 8, 1, 2, 4 },
            { 7, 1, 7, 3, 7 },
            { 2, 9, 8, 9, 3 }
        };

        int N = enerji.GetLength(0);
        int sonuc = EnDusukEnerjiMaliyeti(enerji, N);

        Console.WriteLine("En az enerji maliyeti: " + sonuc);
    }
}
