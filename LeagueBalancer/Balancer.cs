﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueBalancer
{
    static class Balancer
    {
        public static int RomanToArabic(string roman)
        {
            switch (roman)
            {
                case "I":
                    return 1;
                case "II":
                    return 2;
                case "III":
                    return 3;
                case "IV":
                    return 4;
            }
            return -1;
        }

        public static int RankToPoints(string rank)
        {
            rank = rank.ToLower();
            int mult = 0;
            if (rank.Contains("iron"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 300;
                    case 2:
                        return 200;
                    case 3:
                        return 100;
                    case 4:
                        return 0;
                }
            }
            if (rank.Contains("bronze"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 700;
                    case 2:
                        return 600;
                    case 3:
                        return 500;
                    case 4:
                        return 400;
                }
            }
            else if (rank.Contains("silver"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 1100;
                    case 2:
                        return 1000;
                    case 3:
                        return 900;
                    case 4:
                        return 800;
                }
            }
            else if (rank.Contains("gold"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 1500;
                    case 2:
                        return 1400;
                    case 3:
                        return 1300;
                    case 4:
                        return 1200;
                }
            }
            else if (rank.Contains("platinum"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 1900;
                    case 2:
                        return 1800;
                    case 3:
                        return 1700;
                    case 4:
                        return 1600;
                }
            }
            else if (rank.Contains("emerald"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 2300;
                    case 2:
                        return 2200;
                    case 3:
                        return 2100;
                    case 4:
                        return 2000;
                }
            }
            else if (rank.Contains("diamond"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                switch (mult)
                {
                    case 1:
                        return 2700;
                    case 2:
                        return 2600;
                    case 3:
                        return 2500;
                    case 4:
                        return 2400;
                }
            }
            else if (rank.Contains("master"))
            {
                if (rank.Contains("grand"))
                {
                    return 2900;
                }
                else
                    return 2800;
            }
            else if (rank.Contains("challenger"))
            {
                return 3000;
            }

            return 0;
        }

        public static string GetRankIcon(string rank)
        {
            rank = rank.ToLower();
            string lnk = "https://cdn.leagueofgraphs.com/img/league-icons-v2/160/";
            int mult = 0;
            if (rank.Contains("iron"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                return lnk + "1-" + mult + ".png";
            }
            if (rank.Contains("bronze"))
            {

                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                return lnk + "2-" + mult + ".png";
            }
            else if (rank.Contains("silver"))
            {
                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                return lnk + "3-" + mult + ".png";
            }
            else if (rank.Contains("gold"))
            {

                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                return lnk + "4-" + mult + ".png";
            }
            else if (rank.Contains("platinum"))
            {

                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                return lnk + "5-" + mult + ".png";
            }
            else if (rank.Contains("diamond"))
            {

                mult = (int)Char.GetNumericValue(rank[rank.Length - 1]);
                return lnk + "6-" + mult + ".png";
            }
            else if (rank.Contains("master"))
            {
                if (rank.Contains("grand"))
                {
                    return lnk + "8-1.png";
                }
                else
                    return lnk + "7-1.png";
            }
            else if (rank.Contains("challenger"))
            {
                return lnk + "9-1.png";
            }
            return "https://opgg-static.akamaized.net/images/medals/default.png";
        }

        public static List<LeagueSummoner>[] TeamBalancer(List<LeagueSummoner> summoners)
        {

            List<LeagueSummoner> pool = summoners.OrderBy(x => x.points).ToList<LeagueSummoner>();

            int sum = 0;
            foreach (LeagueSummoner summoner in pool)
                sum += summoner.points;
            float halfSum = sum / 2f;

            List<LeagueSummoner> team1 = new List<LeagueSummoner>();
            List<LeagueSummoner> team2 = new List<LeagueSummoner>();
            int sum1 = 0, sum2 = 0;
            int tcnt2 = 0;
            for (int i = 9; i >= 0; i--)
            {
#pragma warning disable S2589 // Boolean expressions should not be gratuitous
                if (sum1 <= sum2 || sum2 >= halfSum || tcnt2 == 5)
                {
                    team1.Add(pool[i]);
                    sum1 += pool[i].points;
                }
                else
                {
                    team2.Add(pool[i]);
                    sum2 += pool[i].points;
                    tcnt2++;
                }
#pragma warning restore S2589 // Boolean expressions should not be gratuitous
            }
            List<LeagueSummoner>[] teams = {team1,team2};
            return teams;
        }

        public static List<LeagueSummoner>[] TeamRandomizer(List<LeagueSummoner> summoners)
        {
            Random random = new Random();
            List<LeagueSummoner> pool = summoners.OrderBy(x => random.Next()).ToList();

            List<LeagueSummoner> team1 = new List<LeagueSummoner>();
            List<LeagueSummoner> team2 = new List<LeagueSummoner>();

            for (int i = 9; i >= 0; i--)
            {
                if(team1.Count < 5)
                {
                    team1.Add(pool[i]);
                } else
                {
                    team2.Add(pool[i]);
                }
            }
            List<LeagueSummoner>[] teams = { team1, team2 };
            return teams;
        }
    }
}
