namespace Day1

open System

type Day5() =
   let rec WalkArray(position: int, numberOfSteps: int, trampoline: int array) =
        match position with
        | i when i < 0 || i >= trampoline.Length -> numberOfSteps
        | _ ->
            let move = trampoline.[position]
            let left, right = trampoline |> Array.splitAt(position)
            let tail = List.toArray(Array.toList(right).Tail)
            let newTrampoline = Array.concat([| left; [| move + 1 |]; tail |] )
            WalkArray(position + move, numberOfSteps + 1, newTrampoline);

   let rec WalkArray2(position: int, numberOfSteps: int, trampoline: int array) =
        match position with
        | i when i < 0 || i >= trampoline.Length -> numberOfSteps
        | _ ->
            let move = trampoline.[position]
            let left, right = trampoline |> Array.splitAt(position)
            let tail = List.toArray(Array.toList(right).Tail)
            let newTrampoline = 
                if move < 3 then
                    Array.concat([| left; [| move + 1 |]; tail |] )
                else
                    Array.concat([| left; [| move - 1 |]; tail |] )
            WalkArray2(position + move, numberOfSteps + 1, newTrampoline);

   member this.Execute(input: int array) = WalkArray(0, 0, input);

   member this.Execute2(input: int array) = WalkArray2(0, 0, input);