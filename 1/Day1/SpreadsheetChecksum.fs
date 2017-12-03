namespace Day1

type SpreadsheetChecksum() =
    member this.Evaluate(spreadsheet:int[][]) = 
        Array.sum(
            spreadsheet |> 
            Array.Parallel.map (fun x -> Array.max(x) - Array.min(x)));