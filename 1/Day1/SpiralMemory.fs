namespace Day1

open System

type SpiralMemory() =
    let rec FindDistance(seed: int, sideLength: int, value: int) =
        let maxValueInNextCircuit = seed + (sideLength - 1) * 4 
        if (value < maxValueInNextCircuit) then
            let zeroOffset = (value - seed) % (sideLength - 1)
            let midPoint = (sideLength + 1) / 2
            if (zeroOffset + 1 = midPoint) then
                midPoint - 1
            else if (zeroOffset < midPoint) then
                (midPoint - 1) * 2 - zeroOffset
            else
                midPoint + zeroOffset - midPoint
        else
            FindDistance(maxValueInNextCircuit, sideLength + 2, value);

    member this.Evaluate(input: int) =
        if input = 1 then
            0
        else
            FindDistance (1, 3, input);