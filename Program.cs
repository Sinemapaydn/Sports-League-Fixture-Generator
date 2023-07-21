using System;

class Program
{
    static void Main()
    {
        int teamCount = 18;
        int totalWeeks = 36;
        int totalMatchesPerWeek = teamCount / 2;

        // Takımların isimlerini tutmak için dizi oluşturulur.
        string[] teams = new string[teamCount];
        for (int i = 0; i < teamCount; i++)
        {
            teams[i] = "Team " + (i + 1);
        }

        // Her hafta için fikstür oluşturulur.
        for (int week = 0; week < totalWeeks; week++)
        {
            Console.WriteLine("Week " + (week + 1) + ":");

            // Takımların maç yapma durumlarını tutmak için indeks tablosu oluşturulur.
            int[] teamIndices = new int[teamCount];
            for (int i = 0; i < teamCount; i++)
            {
                teamIndices[i] = i;
            }

            // Her hafta için maçlar oluşturulur.
            for (int match = 0; match < totalMatchesPerWeek; match++)
            {
                // Her maç için ev sahibi ve deplasman takımları belirlenir.
                for (int i = 0; i < totalMatchesPerWeek; i++)
                {
                    int homeTeamIndex = (week + i) % teamCount;
                    int awayTeamIndex = (teamCount - 1 + week - i) % teamCount;

                    // 18.haftadan sonra ev sahibi ve deplasman takımlarının yerleri değiştirilir.
                    if (week >= 18)
                    { 
                        int temp = homeTeamIndex;
                        homeTeamIndex = awayTeamIndex;
                        awayTeamIndex = temp;
                    }

                    // Ev sahibi ve deplasman takımları birbirinden farklı ve daha önce maç yapmamışsa maç oluşturulur.
                    if (homeTeamIndex != awayTeamIndex && !HasPlayedBefore(teamIndices, homeTeamIndex, awayTeamIndex))
                    {
                        Console.WriteLine(teams[homeTeamIndex] + " (home) vs. " + teams[awayTeamIndex] + " (away)");

                        // Ev sahibi ve deplasman takımların o hafta maç yaptığını işaretlemek için indeksler -1 olarak işaretlenir.
                        // Böylece aynı takımların bir sonraki maçta tekrar karşılaşması engellenir.
                        teamIndices[homeTeamIndex] = -1;
                        teamIndices[awayTeamIndex] = -1;

                        break;
                    }
                }
            }

            Console.WriteLine(); 
        }

        Console.ReadLine();
    }

    // Eğer ev sahibi veya deplasman takımlarından biri daha önce maç yapmışsa true döner, aksi halde false döner.
    static bool HasPlayedBefore(int[] teamIndices, int homeTeamIndex, int awayTeamIndex)
    {
        return teamIndices[homeTeamIndex] == -1 || teamIndices[awayTeamIndex] == -1;
    }
}
