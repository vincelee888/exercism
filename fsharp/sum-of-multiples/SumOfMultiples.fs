module SumOfMultiples

let rec isMultipleOf(value: int, numbers: int list): bool =
  match numbers with
  | head :: tail when value % head <> 0 -> isMultipleOf (value, tail)
  | head :: _ when value % head = 0 -> true
  | _ -> false

let sum (numbers: int list) (upperBound: int): int =
  [0..upperBound]
    |> List.filter (fun x -> x < upperBound)
    |> List.filter (fun x -> isMultipleOf(x, numbers))
    |> List.sum