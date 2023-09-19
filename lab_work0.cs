

Console.Write("Insert number which you wanna put in degree of 2:\n");
int num = Convert.ToInt32(Console.ReadLine());
int num2 = 2;
double fin = Math.Pow(num, num2);
Console.WriteLine($"{num} ^ {num2} = {fin}");
Console.Write("Insert some word which will update phrase 'Hello world'\n");
var name = Console.ReadLine();
Console.WriteLine($"You got phrase: Hello, {name}");
return 0;