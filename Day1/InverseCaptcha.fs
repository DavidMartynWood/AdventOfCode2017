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

    member this.Evaluate(input: int array) =
        evaluateItem(input.[0], input.[input.Length - 1]) +
        sumListTailRecHelper(0, input.[0], List.ofArray(input.[1 .. input.Length - 1]));