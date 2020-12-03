namespace FSharp.Code

open System

module Day2 =
    let parseRange (range: string) =
        range.Split('-') 
        |> fun r -> (Int32.Parse r.[0], Int32.Parse r.[1])

    let parseEntry (entry: string) =
        entry.Split() 
        |> fun t -> (parseRange t.[0], t.[1].[0], t.[2])

    let isInRange range count =
        seq {fst range .. snd range} |> Seq.contains count

    let isValidPassword range ch password =
        password 
        |> Seq.filter(fun c -> c = ch)
        |> Seq.length
        |> isInRange range 

    let part1 (passwords:seq<string>) =
        passwords 
        |> Seq.map(parseEntry)
        |> Seq.filter(fun (range, ch, password) -> isValidPassword range ch password)
        |> Seq.length
