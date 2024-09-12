// See https://aka.ms/new-console-template for more information

using itransition_task3;

try
{
    var game = GameFactory.CreateGame(args);
    game.Run();
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}