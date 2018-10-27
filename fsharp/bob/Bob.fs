module Bob
open System

let getTotalChars (input) = 
    input
    |> Seq.filter(fun c -> Char.IsLetter(c))
    |> Seq.length

let isShouting (input:string) bool =
  let totalChars = getTotalChars input
  let totalUpperCaseChars = 
    input
    |> Seq.filter(fun c -> Char.IsUpper(c))
    |> Seq.length

  totalChars > 0 && totalUpperCaseChars = totalChars

let isQuestion (input:string) bool =
  input.EndsWith "?"

let isForceFulQuestion (input:string) bool =
  let a = isShouting(input) () // this is weird, why do i have to use ()?
  let b = isQuestion(input) ()

  a && b

let isSilence (input:string) bool =
  String.IsNullOrWhiteSpace input

type InputResponsePair = { predicate: string -> unit -> bool; response: string }
let response (input: string): string = 
  let inputResponsePairs = [
    { predicate = isForceFulQuestion; response = "Calm down, I know what I'm doing!" };
    { predicate = isShouting; response = "Whoa, chill out!" };
    { predicate = isQuestion; response = "Sure." };
    { predicate = isSilence; response = "Fine. Be that way!" };
  ]
  let trimmed = input.TrimEnd()
  let response = 
    inputResponsePairs
    |> Seq.tryFind(fun pair -> pair.predicate(trimmed)())

  match response with
  | Some pair -> pair.response
  | None -> "Whatever."