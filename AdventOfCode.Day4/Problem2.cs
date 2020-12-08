using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day4
{
    public class Problem2
    {
        // 4 total, all invalid
        public const string InvalidExamples = @"
eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007";

        // 4 total, all valid
        public const string ValidExamples = @"
pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";

        public static int Solve()
        {
            var passports = Problem1.Parse(Problem1.Input);

            var validPassports = passports.Count(IsValid);

            return validPassports;
        }

        public static bool IsValid(Problem1.Passport p)
        {
            if (String.IsNullOrWhiteSpace(p.BirthYear) || (p.BirthYear.Length != 4) ||
                Convert.ToInt16(p.BirthYear) < 1920 || Convert.ToInt16(p.BirthYear) > 2002)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(p.IssueYear) || (p.IssueYear.Length != 4) ||
                Convert.ToInt16(p.IssueYear) < 2010 || Convert.ToInt16(p.IssueYear) > 2020)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(p.ExpirationYear) || (p.ExpirationYear.Length != 4) ||
                Convert.ToInt16(p.ExpirationYear) < 2020 || Convert.ToInt16(p.ExpirationYear) > 2030)
            {
                return false;
            }

            if (!IsValidHeight(p.Height))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(p.HairColor) || (p.HairColor.Length != 7) ||
                p.HairColor[0] != '#' || Regex.IsMatch(p.HairColor[1..], "[0-9a-f]") == false)
            {
                return false;
            }

            var validEyeColors = new List<string>() {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            if (String.IsNullOrWhiteSpace(p.EyeColor) || validEyeColors.Contains(p.EyeColor) == false)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(p.PassportId) || p.PassportId.Length != 9 || Regex.IsMatch(p.PassportId, "[0-9]") == false)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidHeight(string height)
        {
            if (String.IsNullOrWhiteSpace(height)) return false;

            var units = height.Substring(height.Length - 2);

            if (units != "cm" && units != "in") return false;

            var value = height.Replace(units, "");
            if (value == "") return false;

            var asInt = Convert.ToInt16(value);

            if (units == "cm" && (asInt < 150 || asInt > 193)) return false;

            if (units == "in" && (asInt < 59 || asInt > 76)) return false;

            return true;
        }
    }
}
