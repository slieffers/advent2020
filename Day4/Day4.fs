namespace FSharp.Code

open System

module Day4 =
    let requiredFields = ["byr"; "iyr"; "eyr"; "hgt"; "hcl"; "ecl"; "pid"]
    let validEyeColors = ["amb"; "blu"; "brn"; "gry"; "grn"; "hzl"; "oth"]
    let validHexComponents = ['0'; '1'; '2'; '3'; '4'; '5'; '6'; '7'; '8'; '9'; 'a'; 'b'; 'c'; 'd'; 'e'; 'f']
        
    let checkForAllFields (line:seq<string>) =
        requiredFields |> List.forall(fun f -> line |> Seq.exists(fun s -> s.Substring(0, s.IndexOf(':')) = f))

    let getValue (field:string) =
        field.Substring(field.IndexOf(":") + 1)
    
    let getNumber (stringifiedNum:string) =
        match Int32.TryParse stringifiedNum with  
        | true, value -> Some value
        | _ -> None

    let checkNumericValue lowerRange upperRange (field:string) =
        field |> (fun v -> v.Length = 4 && (getNumber v) |> (fun n -> n.IsSome && n.Value >= lowerRange && n.Value <= upperRange))

    let isValidMeasure (measure:string) lowerRange upperRange (field:string) =
        field |> (fun f -> f.EndsWith(measure) && ((getNumber (f.Substring(0, f.Length - 2))) |> (fun n -> n.IsSome && n.Value >= lowerRange && n.Value <= upperRange)))
        
    let fieldToValiationDict = 
                              ["byr", (fun f -> f |> getValue |> checkNumericValue 1920 2002)
                               "iyr", (fun f -> f |> getValue |> checkNumericValue 2010 2020)
                               "eyr", (fun f -> f |> getValue |> checkNumericValue 2020 2030)
                               "hgt", (fun f -> f |> getValue |> (fun f -> isValidMeasure "cm" 150 193 f || isValidMeasure "in" 59 76 f))
                               "hcl", (fun f -> f |> getValue |> (fun f -> f.StartsWith("#") && (f.Substring(1) |> Seq.forall(fun c -> List.exists(fun h -> h = c) validHexComponents))))
                               "ecl", (fun f -> f |> getValue |> (fun f -> List.exists(fun c -> c = f) validEyeColors))
                               "pid", (fun f -> f |> getValue |> (fun f -> f.Length = 9 && (getNumber f).IsSome))
                               "cid", (fun f -> true)
                               ] |> Map.ofList

    let isValidValue (field:string) =
        field |> fieldToValiationDict.[field.Substring(0, 3)]

    let allFieldsAreValid (line:seq<string>) =
        line |> Seq.forall(isValidValue)



    let part1 (passports:seq<string>) =
            passports
            |> Seq.map(fun s -> s.Split(' ') |> Array.toSeq)
            |> Seq.filter(checkForAllFields)
            |> Seq.length
    
    let part2 (passports:seq<string>) =
            passports
            |> Seq.map(fun s -> s.Split(' ') |> Array.toSeq)
            |> Seq.filter(checkForAllFields)
            |> Seq.filter(allFieldsAreValid)
            |> Seq.length
