namespace Day1

type SpreadsheetChecksum() =
    let rec CalculateRowChecksum1(row: int[]) = Array.max(row) - Array.min(row);
    
    let rec CalculateRowChecksum2 (row: int[]) =
        let checksumItems = 
            seq {
                for i in row do
                    for j in row do
                        if (i <> j) && ((i % j) = 0) then
                            yield! [i / j]
                }
        Seq.sum(checksumItems);
    
    member this.Evaluate(spreadsheet:int[][]) = 
        Array.sum(
            spreadsheet |> 
            Array.Parallel.map (fun x -> CalculateRowChecksum1 x));

    member this.EvaluatePart2(spreadsheet:int[][]) = 
        Array.sum(
            spreadsheet |> 
            Array.Parallel.map (fun x -> CalculateRowChecksum2(x)));