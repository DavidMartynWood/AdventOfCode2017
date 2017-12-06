namespace Day1

open System
open System.Runtime.InteropServices.ComTypes

type HighEntropyPassphrases() =

    let rec IsHeadDuplicatedInTail(word, tail) =
        match tail with
        | [] -> 1
        | y::ys when Seq.exists (fun n -> n = word) tail -> 0
        | y::ys -> IsHeadDuplicatedInTail(y, ys);

    let IsPassphraseWithoutDuplicates(passphrase: string) =
        let words = List.ofArray(passphrase.Split(' '))
        IsHeadDuplicatedInTail(words.Head, words.Tail);

    let rec SequenceEqual(seq1, seq2) =
        match seq1, seq2 with
        | [], _ 
        | _, [] -> true
        | x::xs, y::ys -> 
            if (x = y) then
                SequenceEqual(xs,ys)
            else
                false;

    let IsAnagram(word1: string, word2: string) = 
        if word1.Length <> word2.Length then
            false
        else
            let ordered1 = word1.ToCharArray() |> Array.toList |> List.sort
            let ordered2 = word2.ToCharArray() |> Array.toList |> List.sort
            SequenceEqual(ordered1, ordered2);


    let rec IsHeadAnagramInTail(word, tail) =
        match tail with
        | [] -> 1
        | y::ys when Seq.exists (fun n -> IsAnagram(n, word)) tail -> 0
        | y::ys -> IsHeadAnagramInTail(y, ys);

    let IsPassphraseWithoutAnagrams(passphrase: string) =
        let words = List.ofArray(passphrase.Split(' '))
        IsHeadAnagramInTail(words.Head, words.Tail);

    member this.Evaluate(passphrases: string) =
        passphrases.Split('\n')
        |> Array.map(fun passphrase -> IsPassphraseWithoutDuplicates(passphrase))
        |> Array.sum;

    member this.Evaluate2(passphrases: string) =
        passphrases.Split('\n')
        |> Array.map(fun passphrase -> IsPassphraseWithoutAnagrams(passphrase))
        |> Array.sum;