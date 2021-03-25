# Bowling

## Used Tools
* C#
* .NET Core 3.1
* [RazorEngine](https://antaris.github.io/RazorEngine/) 

## Bowling Library

Bowling library containts three modules

### Parser
Convering data from outside source to model class (Bowling.BowlingScore). First version contains only one built-in implementation.<br/>
FileParser convert data from file with known structure.
First line has name, second line has collected pins in one throw separated by comma.
#### Example
```
Pyoneru
10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 4, 6, 10
```

#### Code Example
```C#
IParser parser = ...
ICollection<BowlingScore> scores = parser.Parse();
```

### Bowling
Counting final score and checking if the data is correct. Data from outside could contains points with correct format but they could be no correct.
First two numbers will be first two thrown in first round(if the first thrown was not a strike). In one round player can knock down max 10 the pins. In this situtation, if sum of first two number is more then 10(or even negative), then IBowling implementation should thrown exception about no correct data.

#### Code Example
```C#
var score = scores[0];
IBowling bowling = ...;
bowling.CountScore(ref score);
```

#### SimpleBowling
Build-in implementation works only with full game scores. That's mean, instance of BowlingScore should contains all thrown in game for all 10 rund with additional throws, if they are. Please, remember about it, when you will using this implementation, otherwise it won't working.

### Output
Generating output content or/and file. When you have the ready data, you should generate something output to represnating it. First version of library contains HTMLOutput which generate HTML file use RazorEngine. This implementation need template(you can find example template in Data folder), by default it will be looking for 'template.cshtml' fille as template to generate.

#### Code Example
```C#
IOutput output = ...;
var filename = "...";
output.CreateOutput(scores, filename);
dynamic content = output.Output;
Console.WriteLine(content);
```
