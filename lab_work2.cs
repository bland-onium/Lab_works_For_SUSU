/* Вариант 8
Описать класс «строка» на основе char[], позволяющий выполнять основные операции –
сравнение, конкатенация (слияние), умножение строки на число N (повторение строки N раз). Все
операции реализовать в виде перегрузки операторов. Программа должна содержать меню,
позволяющее осуществлять проверку всех методов.
Дополненительные функции: Вывод строки, отсекание текста в конце строки
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

public class stroka
{
    public Char[] value0;
    public stroka(Char[] value)
    {
        value0 = value;
    }



    public bool Menu(stroka str)
    {
        string cmd;
        Console.Write($"Insert comands and methods what you wanna do with string\n(To see more info, write 'help/h')\n");
        cmd = Convert.ToString(Console.ReadLine());
        if (cmd == null || cmd == "" || cmd.Length<2 ) { return Menu(str); }
        


        if (cmd.ToLower() == "exit" || cmd.ToLower() == "ex")
        {
            return false;
        }
        if (cmd.ToLower() == "help" || cmd.ToLower() == "h")
        {
            Console.Write("\nList of possible commands:\n == -> checks is same first and added string\n" +
                " != -> reverse command to '=='\n + -> summarize first string with written\n - -> delete suffix\n" +
                " * -> to repeat inputted string n times (write as '* 5')\n print/p -> to show text\n" +
                " exit/ex/x -> to stop programm\n you have to write text as: '== qwerty'\n\n");
            return Menu(str);
        }
        if (cmd.ToLower() == "print")
        {
            Console.Write("You have: "); Print(str);
            return Menu(str);
        }


        stroka str2 = CreateStroka(cmd);
        if ((cmd[0] == '=' || cmd[0] == '!') && cmd[1] == '=')
        {
            bool check = (str == str2);
            if (check == true) { Console.WriteLine("Strings are equal"); }
            else { Console.WriteLine("Strings are not same"); }
        }



        else if (cmd[0] == '+')
        {
            str = str + str2;
            Console.WriteLine($"You've got:"); Print(str); Console.Write("\n");
        }
        else if (cmd[0] == '-')
        {
            str = str - str2;
        }
        else if (cmd[0] == '*')
        {
            string numbers = "0123456789";
            string multiplier = "";
            int i = 1;
            if (cmd[1] == ' ') { i = 2; }
            while (i < cmd.Length)
            {
                if (numbers.IndexOf(cmd[i]) == 0 && (i == 1 || i == 2) ) { str = str - str; }
                multiplier += numbers.IndexOf(cmd[i]);
                i++;
            }
            str = str * Convert.ToInt32(multiplier);
            Console.WriteLine("You've got:"); Print(str);
        }
        return Menu(str);
    }

    public static stroka CreateStroka(string cmd)
    {
        char[] empty = { ' ' };
        var final = new stroka(empty);
        string NotAdd = new("=+-*!");
        string add = "";
        int exst = 0;

        for (int i = 0; i < NotAdd.Length; i++) { if (cmd[0] == NotAdd[i]) { exst = 1; break; } }
        if (cmd[1] == '=')
        {
            exst = 2;
            if (cmd[2] == ' ') { exst = 3; }
        }
        switch (exst) {
            case 0:
                {
                    Console.WriteLine("Something wrong in command");
                    return final;
                }
            case 1:
                {
                    int i;
                    if (cmd[1] == ' ') { i = 2; }
                    else { i = 1; }
                    while (i < cmd.Length)
                    { 
                        add += cmd[i];
                        i++;
                    }
                    final.value0 = add.ToCharArray();
                    return final;
                }
            case 2:
                {
                    for (int i = 2; i < cmd.Length; i++) { add += cmd[i]; }
                    final.value0 = add.ToCharArray();
                    return final;
                }
            case 3:
                {
                    for (int i = 3; i < cmd.Length; i++) { add += cmd[i]; }
                    final.value0 = add.ToCharArray();
                    return final;
                }
        }
        return final;
    }
    static bool SameOrNot(stroka str1, stroka str2)
    {
        if (Length(str1) != Length(str2))
        {
            return false;
        }
        else
        {
            int cntr = 0;
            bool chck = false;
            while (str1.value0[cntr] == str2.value0[cntr] && cntr < Length(str1))
            {
                if ( (str1.value0[cntr] == str2.value0[cntr]) )
                {
                    chck = true;
                }
                cntr++;
                if (cntr == Length(str1)) { return chck; }
            }
            chck = false;
        }
        Console.WriteLine("Something has gone wrong");
        return false;
    }

    static stroka Concatenate(stroka str1, stroka str2)
    {
        char[] empty = { ' ' };
        var final = new stroka(empty);
        string prefinal = ""; final.value0 = prefinal.ToCharArray();
        for (int i = 0; i < Length(str1); i++)
        {
            prefinal += str1.value0[i];
        }
        for ( int i = 0; i < Length(str2); i++)
        {
            prefinal += str2.value0[i];
        }
        final.value0 = prefinal.ToCharArray();
        return final;
    }
    static stroka Deconcatenate(stroka str1, stroka str2)
    {
        char[] empty = { ' ' };
        var final = new stroka(empty);
        string prefinal = "";
        string stchk1 = "";
        for (int i = 0; i < Length(str2); i++) 
        {
            stchk1 += str2.value0[i];
        }
        stroka strckmain = new stroka(stchk1.ToCharArray());
        if (SameOrNot(strckmain, str2) == true)
        {
            for ( int i = 0; i < Length(str1) - Length(str2); i++)
            {
                prefinal += str1.value0[i];
            }
            final.value0 = prefinal.ToCharArray();
            Console.WriteLine($"You've got:"); Print(final); Console.Write("\n");
            return final;
        }
        else { Console.WriteLine("Impossible to delete this part of wtring"); }
        return final;
    }
    static stroka Multiply(stroka str, int n)
    {
        stroka buff = str;
        for(int i = 0; i < n - 1; i++)
        {
            str = str + buff;
        }
        return str;
    }
    public static bool operator ==(stroka str1, stroka str2)
    {
        return (SameOrNot(str1, str2));
    }
    public static bool operator !=(stroka str1, stroka str2)
    {
        return (SameOrNot(str1, str2));
    }
    public static stroka operator +(stroka str1, stroka str2)
    {
        return (Concatenate(str1, str2));
    }
    public static stroka operator -(stroka str1, stroka str2)
    {
        return (Deconcatenate(str1, str2));
    }
    public static stroka operator *(stroka str, int n)
    {
        return (Multiply(str, n));
    }


    private static int Length(stroka str) // To find count of symbols in chosen "stroka"
    {
        int cntr = 0;
        try
        {
            while (str.value0[cntr] != null || str.value0[cntr] != str.value0[-1])
            {
                cntr += 1;
            }
        }
        catch
        {
        }
        return cntr;
    }
    static void Print(stroka str)
    {
        for(int i = 0; i < Length(str); i++)
        {
            Console.Write(str.value0[i]);
        }
        Console.Write("\n");
    }
}
class Prog1
{
    static void Main()
    {
        Console.WriteLine("Insert text with which you wanna work:");
        char[] srt1 = Console.ReadLine().ToCharArray();
        var str1 = new stroka(srt1);
        str1.Menu(str1);
    }
}