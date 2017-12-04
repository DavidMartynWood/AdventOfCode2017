namespace Day1

type InverseCaptcha() =
    let evaluateItem (x, y) = 
        if (x = y) then
            x
        else
            0;

    let rec sumListTailRecHelper (accumulator, comparer, xs) =
        match xs with 
        | []    -> accumulator 
        | y::ys -> sumListTailRecHelper (accumulator + evaluateItem(y, comparer), y, ys);
    
    let rec sumListTailRecHelper2 (accumulator, xs, ys) =
        match xs, ys with 
        | [], _   -> accumulator 
        | _, []   -> accumulator 
        | xHead::xTail, yHead::yTail -> sumListTailRecHelper2 (accumulator + evaluateItem(xHead, yHead), xTail, yTail);

    member this.Evaluate(input: int array) =
        evaluateItem(input.[0], input.[input.Length - 1]) +
        sumListTailRecHelper(0, input.[0], List.ofArray(input.[1 .. input.Length - 1]));

    member this.EvaluatePart2(input: int array) =
        let left, right = input |> Array.splitAt (input.Length / 2)
        sumListTailRecHelper2(0, List.ofArray(input), List.ofArray(Array.concat([|right; left|])));