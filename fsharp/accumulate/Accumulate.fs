module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = 
  let rec myMap f acc = function 
    | [] -> acc
    | head :: tail -> myMap f (acc @ [ f head]) tail
  
  myMap func [] input
