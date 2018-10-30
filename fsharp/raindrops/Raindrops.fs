module Raindrops

type Converter = {
  predicate: int -> bool;
  result: string
}

let convert (number: int): string =
  let hasFactorOf = fun x y -> y % x = 0 

  let pairs = [
    (3, "Pling");
    (5, "Plang");
    (7, "Plong")
  ]

  let result = 
    pairs
    |> Seq.map(fun p -> { predicate = hasFactorOf (fst p); result = snd p })
    |> Seq.filter (fun c -> c.predicate number)
    |> Seq.fold (fun acc c -> System.String.Concat(acc, c.result)) ""

  match result with
  | "" -> string number
  | _ -> result