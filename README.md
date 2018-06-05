# MacroSource.Guid
Tool for generate guids.

[Nuget](https://www.nuget.org/packages/MacroSource.Guid)

-----
## Install:
dotnet tool install --global MacroSource.Guid

## Sample
```
> guid  
987dae0c-0ca9-4710-93d3-e7355c8def65

> guid 3 -f N
2CA6FA0D3E034A6CABE489DF62859B51
66AA381BA4334BFE894F9609843EAFC1
B92D4784772C48B28400637288DAB3D0

> guid 1000 -o e:\guids.txt

> guid --help
```

## Usage
```
USAGE: guid [--help] [--format <format>] [--output <output>] [<count>]

COUNT:

    <count>               count of guids.

OPTIONS:

    --format, -f <format> specify a guid format (n d b p x), default is 'd', upper arg for upper output.
    --output, -o <output> output file.
    --help                display this list of options.
```

