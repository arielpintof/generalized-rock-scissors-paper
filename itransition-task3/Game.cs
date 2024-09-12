using ConsoleTables;
using itransition_task3.CommandLine;
using itransition_task3.Utils;

namespace itransition_task3;

public class Game(List<string> moves)
{
    private readonly Random _random = new();

    public void Run()
    {
        var secretKey = Crypto.GenerateRandomKey();
        var computerChoice = _random.Next(1, moves.Count);
        var hash = Crypto.ComputeHmac(secretKey, moves[computerChoice - 1]);

        Console.WriteLine($"{BitConverter.ToString(hash).Replace("-", string.Empty)}\n");

        ShowMenu(moves);
        PlayRound(moves, computerChoice);

        Console.WriteLine($"\nkey: {BitConverter.ToString(secretKey).Replace("-", string.Empty)}");
        Console.WriteLine($"\nYou can check the hmac value at: https://cryptii.com/pipes/hmac with message 'paper' (computer choice) and with key: {BitConverter.ToString(secretKey).Replace("-", string.Empty)}");
    }

    private static void PlayRound(List<string> moves, int computerChoice)
    {
        var userInput = Console.ReadLine();
    
        if (IsValidUserInput(userInput, moves.Count, out var userChoice))
        {
            ProcessUserMove(moves, computerChoice, userChoice);
        }
        else
        {
            if (userInput != null) HandleInvalidInput(userInput, moves);
        }
    }
    
    private static bool IsValidUserInput(string? userInput, int moveCount, out int userChoice)
    {
        userChoice = 0;
        return userInput != null && int.TryParse(userInput, out userChoice) && userChoice > 0 && userChoice <= moveCount;
    }
    
    private static void ProcessUserMove(List<string> moves, int computerChoice, int userChoice)
    {
        Console.WriteLine($"Your move: {moves[userChoice - 1]}");

        var computerMove = moves[computerChoice - 1];
        Console.WriteLine($"Computer move: {computerMove}");

        var result = GetResult(userChoice - 1, computerChoice - 1, moves.Count) switch
        {
            0 => "It's a draw!",
            1 => "You Win!",
            -1 => "You Lost",
            _ => "?"
        };

        Console.WriteLine(result);
    }
    private static void HandleInvalidInput(string userInput, List<string> moves)
    {
        switch (userInput)
        {
            case "0":
                return;
            case "?":
                DrawTable(moves);
                return;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    }
    private static int GetResult(int playerIndex, int computerIndex, int totalMoves)
    {
        if (playerIndex == computerIndex) return 0;
        var half = totalMoves / 2;
        if ((computerIndex > playerIndex && computerIndex <= playerIndex + half) ||
            (computerIndex < playerIndex && playerIndex - computerIndex > half))
        {
            return -1;
        }

        return 1;
    }

    private static void ShowMenu(List<string> moves)
    {
        Console.WriteLine("Available moves:");
        for (var i = 0; i < moves.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {moves[i]}");
        }

        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
        Console.Write("Enter your move: ");
    }

    private static int[,] SetTable(List<string> moves)
    {
        var results = new int[moves.Count, moves.Count];
        
        for (var i = 0; i < moves.Count; i++)
        {
            for (var j = 0; j < moves.Count; j++)
            {
                results[i, j] = GetResult(j, i, moves.Count);
            }
        }

        return results;
    }
    private static void DrawTable(List<string> moves)
    {
        var results = SetTable(moves);
        var table = new ConsoleTable(moves.Prepend("").ToArray());
        for (var i = 0; i < moves.Count; i++)
        {
            var row = new object[moves.Count + 1];
            row[0] = moves[i];
            for (var j = 0; j < moves.Count; j++)
            {
                row[j + 1] = results[i, j] switch
                {
                    0 => "Draw",
                    1 => "Win",
                    -1 => "Lose",
                    _ => "?"
                };
            }

            table.AddRow(row);
        }

        table.Write(Format.MarkDown);
    }
}