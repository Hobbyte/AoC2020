using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    class PassportInfo
    {
        public string BirthYear;
        public string IssueYear;
        public string ExpirationYear;
        public string Height;
        public string HairColor;
        public string EyeColor;
        public string PassportId;
        public string CountryId;

        public string SourceString;

        public bool HasAllFields()
        {
            if (String.IsNullOrEmpty(BirthYear) ||
                String.IsNullOrEmpty(IssueYear) ||
                String.IsNullOrEmpty(ExpirationYear) ||
                String.IsNullOrEmpty(Height) ||
                String.IsNullOrEmpty(HairColor) ||
                String.IsNullOrEmpty(EyeColor) ||
                String.IsNullOrEmpty(EyeColor) ||
                String.IsNullOrEmpty(PassportId)
               )
                return false;

            return true;
        }

        public bool IsValid()
        {
            if (!HasAllFields())
                return false;

            int byr;
            if (!int.TryParse(BirthYear, out byr) || byr < 1920 || byr > 2002)
                return false;

            int iyr;
            if (!int.TryParse(IssueYear, out iyr) || iyr < 2010 || iyr > 2020)
                return false;

            int eyr;
            if (!int.TryParse(ExpirationYear, out eyr) || eyr < 2020 || eyr > 2030)
                return false;

             
            var heightMatch = Regex.Match(Height, @"(\d+)(.+)");
            string heightNum = heightMatch.Groups.GetValueOrDefault("1").Value;
            string heightUnit = heightMatch.Groups.GetValueOrDefault("2").Value;

            int hgt;
            if (!int.TryParse(heightNum, out hgt))
                return false;

            if (heightUnit == "cm")
            {
                if (hgt < 150 || hgt > 193)
                    return false;
            }
            else if (heightUnit == "in")
            {
                if (hgt < 59 || hgt > 76)
                    return false;
            }
            else
            {
                return false;
            }

            if (!Regex.IsMatch(HairColor, "^#[0-9a-f]{6}$"))
                return false;

            if (!Regex.IsMatch(EyeColor, "(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)$"))
                return false;

            if (!Regex.IsMatch(PassportId, @"^[\d]{9}$"))
                return false;



            return true;
        }

        public static PassportInfo FromString(string s)
        {
            PassportInfo pi = new PassportInfo();
            pi.SourceString = s;

            pi.BirthYear = Regex.Match(s, @"byr:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.IssueYear = Regex.Match(s, @"iyr:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.ExpirationYear = Regex.Match(s, @"eyr:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.Height = Regex.Match(s, @"hgt:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.HairColor = Regex.Match(s, @"hcl:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.EyeColor = Regex.Match(s, @"ecl:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.PassportId = Regex.Match(s, @"pid:(\S+)").Groups.GetValueOrDefault("1")?.Value;
            pi.CountryId = Regex.Match(s, @"cid:(\S+)").Groups.GetValueOrDefault("1")?.Value;


            return pi;
        }
    }

    class Program
    {
    
        static List<PassportInfo> GetPassports()
        {
            List<PassportInfo> passports = new List<PassportInfo>();

            string inputPath = "input.txt";

            List<string> lines = new List<string>(File.ReadAllLines(inputPath));

            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {

                if (line.Length == 0)
                {
                    passports.Add(PassportInfo.FromString(sb.ToString()));

                    sb.Clear();
                    continue;
                }

                sb.Append(" ");
                sb.Append(line.Trim());
            }

            passports.Add(PassportInfo.FromString(sb.ToString()));

            return passports;
        }

        static void Part1()
        {

            int validPassports = GetPassports().Count(x => x.HasAllFields());

            Console.WriteLine("Part1: " + validPassports);

        }

        static void Part2()
        {

            int validPassports = GetPassports().Count(x => x.IsValid());

            Console.WriteLine("Part2: " + validPassports);

        }

        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
