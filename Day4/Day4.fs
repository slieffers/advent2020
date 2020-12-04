﻿namespace FSharp.Code

module Day4 =
    let testData = seq{
                        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm"
                        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929"
                        "hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm"
                        "hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in"
                        }
    let requiredFields = ["byr"; "iyr"; "eyr"; "hgt"; "hcl"; "ecl"; "pid"]
    
    let checkForAllFields (line:seq<string>) =
        requiredFields |> List.forall(fun f -> line |> Seq.exists(fun l -> l = f))
        
    let part1 (passports:seq<string>) =
            passports
            |> Seq.map(fun s -> s.Split(' ') |> Array.toSeq |> Seq.map(fun s -> s.Substring(0, s.IndexOf(':'))))
            |> Seq.filter(fun s -> Seq.length s > 6)
            |> Seq.filter(checkForAllFields)
            |> Seq.length
        
