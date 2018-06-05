open Argu
open System

let writeAllLines = 
    (IO.File.WriteAllLines :(string*string seq)->unit) 
    |> FuncConvert.FuncFromTupled

let toUpper (s:string) = s.ToUpper();

type CLIArguments =
    | [<MainCommand;First>] Count of count:UInt32
    | [<AltCommandLine("-f")>] Format of format:String
    | [<AltCommandLine("-o")>] Output of output:String
with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Count _ -> "count of guids."
            | Format _ -> "specify a guid format (n d b p x), default is 'd', upper arg for upper output."
            | Output _ -> "output file."

[<EntryPoint>]
let main argv =    
    let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some ConsoleColor.Red)
    let parser = ArgumentParser.Create<CLIArguments>(programName = "guid", errorHandler = errorHandler)
    let results = parser.Parse argv

    let count = results.GetResult<UInt32> (Count, defaultValue = 1u)
    let format = 
        <@ Format @> 
        |> results.TryGetResult<String> 
        |> Option.defaultValue "d"
        
    let output = results.TryGetResult<String> Output

    let gFunc =       
        fun _ -> Guid.NewGuid().ToString(format)
        >> if Char.IsUpper(format.[0]) then toUpper else id

    [1..count |> int] 
    |> Seq.map gFunc
    |> match output with 
        | Some path -> writeAllLines path
        | _________ -> Seq.iter (printfn "%s")
    0
