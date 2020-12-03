namespace Day1

module Code =
    let rec findNums (total: int) (dict: Map<int, int>) (nums: list<int>) =
        if dict.ContainsKey(nums.Head) 
        then 
            Some (nums.Head, dict.[nums.Head])
        elif nums.Length = 1
        then
            None
        else
            findNums total (dict.Add(total - nums.Head, nums.Head)) nums.Tail

    let combineTuples (dict: Map<int, int>) tup =
        (fst tup, snd tup, dict.[(fst tup) + (snd tup)])

    let findPairForNums total nums =
        nums 
        |> Seq.toList 
        |> findNums total Map.empty

    let part1 nums = 
        findPairForNums 2020 nums
        |> Option.get

    let part2 nums = 
        let dict = 
            nums 
            |> Seq.toList 
            |> List.map(fun i -> 2020 - i, i) 
            |> Map.ofList

        dict
        |> Map.toList
        |> List.map fst
        |> List.tryPick(fun k -> findPairForNums k nums)
        |> Option.get
        |> combineTuples dict
