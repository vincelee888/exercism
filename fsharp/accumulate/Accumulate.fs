module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = 
  let rec myMap f acc = function 
    | [] -> acc
    | head :: tail -> myMap f (f head :: acc) tail
  
  myMap func [] input
  |> List.rev