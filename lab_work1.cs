/* Variant 8
 * Составить описание класса прямоугольного параллелепипеда со сторонами, параллельными осям
координат. Предусмотреть возможность перемещения его в пространстве, изменение размеров,
построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда, и
параллелепипеда, являющегося общей частью (пересечением) двух параллелепипеда. Программа
должна содержать меню, позволяющее осуществлять проверку всех методов.*/
/* Функции, не прописанные в ТЗ, но существующие в меню работы: Выход из программы, вывод одного
 * из двух параллелепипедов, переназначение параллелепипеда */


using System.Linq.Expressions;
using System.Runtime.InteropServices;

public class Parallelepiped
{
    public double x0, y0, z0, height0, width0, len0;

    public Parallelepiped(double x, double y, double z, double len, double width, double height)
    {
        x0 = x; y0 = y; z0 = z;
        len0 = len; width0 = width; height0 = height;
    }


    //Parallelepiped parfin = new Parallelepiped(0, 0, 0, 0, 0, 0);
    public bool CmdInit(Parallelepiped parall1, Parallelepiped parall2, Parallelepiped parfin)
    {
        string str;
        Console.Write($"\nInsert comand(to see list of possible comands, write 'help'):\n\t---> ");
        str = Convert.ToString(Console.ReadLine());
        double[] cords = { 0, 0, 0 };



        if (str == "help" || str == "Help" || str == "H" || str == "h")
        {
            Console.Write("List of comands which you can use\n\n" +
                "\tPrint <number of figure>/p< >/p < > - to show info about figure\n" +
                "\tMove/m - to move figures in x|y|z coordinates\n" +
                "\tResize/size/s - to change length/width/height of figure\n" +
                "\tReassign/change/new/n - to create new figure instead of previous\n" +
                "\tIntersection/intersect/cross/cr - to find parallelepiped which contaned in another two\n" +
                "\tCompare/Summ/s - to build parallelogramm which contains two another");
            return CmdInit(parall1, parall2, parfin);
        }



        if (str == "Move" || str == "move" || str == "m" || str == "M")
        {
            Console.Write("Choose number of figure that you wanna move:\n\t---> ");
            int cmnd = Convert.ToInt16(Console.ReadLine());
            Console.Write($"Insert coordinates what on you wanna move figure: \n");
            CordsFill(cords);
            switch (cmnd)
            {
                case 1:
                    Move(cords[0], cords[1], cords[2], parall1);
                    break;
                case 2:
                    Move(cords[0], cords[1], cords[2], parall2);
                    break;
            }
        }



        else if (str == "Resize" || str == "resize" || str == "size" || str == "s")
        {
            Console.Write("Choose number of figure which you wanna resize:\n\t---> ");
            int cmnd = Convert.ToInt16(Console.ReadLine());
            Console.Write($"Insert length what on you wanna resize figure: \n");
            CordsFill(cords);
            switch (cmnd)
            {
                case 1:
                    parall1.len0 += cords[0];
                    parall1.width0 += cords[1];
                    parall1.height0 += cords[2];
                    Console.Write($"Size that you've got:\n" +
                        $"length = {parall1.len0}; width = {parall1.width0}; height = {parall1.height0}");
                    break;
                case 2:
                    parall2.len0 += cords[0];
                    parall2.width0 += cords[1];
                    parall2.height0 += cords[2];
                    Console.WriteLine($"Size that you've got: \n" +
                        $"length = {parall2.len0}; width = {parall2.width0}; height = {parall2.height0}\n");
                    break;
            }
        }



        else if (str == "Intersection" || str == "intersection" || str == "Crossing" || str == "crossing"
            || str == "intersect" || str == "cr" || str == "cross" || str == "Cr")
        {
            Console.Write("Creating parallelepiped inside chosen two...\n");
            for (int i = 0; i < 10; i++) { Console.Write($"Progress: {(i + 1) * 10}%\n"); }
            parfin = BuildLittle(parall1, parall2);
            print(parfin);
        }



        else if (str == "sum" || str == "Summ" || str == "summ" || str == "Sum")
        {
            Console.WriteLine("Creating parallelepiped which contains our two...");
            parfin = BuildBig(parall1, parall2);
            print(parfin);
        }




        else if (str == "reassignment" || str == "change" || str == "new" || str == "n")
        {
            Console.Write("insert number of parallelepiped which you wanna change:\n\t---> ");
            int cmnd = Convert.ToInt16(Console.ReadLine());
            switch (cmnd)
            {
                case 1:
                    CordsFill(cords);
                    parall1.x0 = cords[0]; parall1.y0 = cords[1]; parall1.z0 = cords[2];
                    Console.Write("Length -> "); parall1.len0 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Width -> "); parall1.width0 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Height -> "); parall1.height0 = Convert.ToDouble(Console.ReadLine());
                    break;
                case 2:
                    CordsFill(cords);
                    parall1.x0 = cords[0]; parall1.y0 = cords[1]; parall1.z0 = cords[2];
                    Console.Write("Length -> "); parall2.len0 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Width -> "); parall2.width0 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Height -> "); parall2.height0 = Convert.ToDouble(Console.ReadLine());
                    break;
            }
        }
        else if (str == "print 1" || str == "p 1" || str == "Print 1" || str == "P 1" || str == "p1") { print(parall1); }
        else if (str == "print 2" || str == "p 2" || str == "Print 2" || str == "P 2" || str == "p2") { print(parall2); }
        else if (str == "print 3" || str == "p 3" || str == "Print 3" || str == "P 3" || str == "p3") { print(parfin); }
        else if (str == "Exit" || str == "exit" || str == "Ex" || str == "ex" || str == "x")
        {
            return false;
        }

            return CmdInit(parall1, parall2, parfin);
        }



    public void Move(double x, double y, double z, Parallelepiped par)
    {
        par.x0 += x;
        par.y0 += y;
        par.z0 += z;
        Console.WriteLine($"Coordinates that you've got: ({par.x0}, {par.y0}, {par.z0})\n");
    }
    public Parallelepiped BuildLittle(Parallelepiped parall1, Parallelepiped parall2)
    {
        double x = 0, y = 0, z = 0, len, width, height;
        // Мысль: если координата начала одной фигуры принадлежит координате и длине второй,
        // то её можно считать точкой начала маленького параллелепипеда. 
        // Соответственно, расстояние от точки пересечения до конца одной из длин - длина меньшей фигуры
        // Меньшая сумма координаты и длины кончается где-то на большом отрезке => 
        // => если от них убрать отступ большей длины, то получим длину маленького пар-да
        // Мысль провальная...

        x = Math.Max(parall1.x0, parall2.x0);
        len = Math.Min(parall1.x0 + parall1.len0, parall2.x0 + parall2.len0) - Math.Max(parall1.x0, parall2.x0); ;
        y = Math.Max(parall1.y0, parall2.y0);
        width = Math.Min(parall1.y0 + parall1.width0, parall2.y0 + parall2.width0) - Math.Max(parall1.y0, parall2.y0);
        z = Math.Max(parall1.z0, parall2.z0);
        height = Math.Min(parall1.z0 + parall1.height0, parall2.z0 + parall2.height0) - Math.Max(parall1.z0, parall2.z0);
        if (len < 0 || width < 0 || height < 0)
        {
            Console.WriteLine("ERROR !-----------------------------------------!\nImpossible to create parallelepiped\n");
            var parlit = new Parallelepiped(0, 0, 0, 0, 0, 0);
            return parlit;
        }
        else
        {
            var parlit = new Parallelepiped(x, y, z, len, width, height);
            return parlit;
        }
    }
    public void CordsFill(double[] cords) // Для внесения данных о перемещении/редактировании фигуры
    {
        for (int i = 0; i < cords.Length; i++)
        {
            string step;
            double mov = 0;
            switch (i)
            {
                case 0:
                    Console.Write("x -> ");
                    step = Convert.ToString(Console.ReadLine());
                    if (step == " " || step == "") { mov = 0; }
                    else { mov = Convert.ToDouble(step); }
                    cords[0] = mov;
                    break;
                case 1:
                    Console.Write("y -> ");
                    step = Convert.ToString(Console.ReadLine());
                    if (step == " " || step == "") { mov = 0; }
                    else { mov = Convert.ToDouble(step); }
                    cords[1] = mov;
                    break;
                case 2:
                    Console.Write("z -> ");
                    step = Console.ReadLine();
                    if (step == " " || step == "") { mov = 0; }
                    else { mov = Convert.ToDouble(step); }
                    cords[2] = mov;
                    break;
            }
        }
    }
    public Parallelepiped BuildBig(Parallelepiped par1, Parallelepiped par2)
    {
        double x = 0, y = 0, z = 0, len = 0, width = 0, height = 0;
        x = Math.Min(par1.x0, par2.x0);
        y = Math.Min(par1.y0, par2.y0);
        z = Math.Min(par1.z0, par2.z0);
        if (par1.len0 + par1.x0 > par2.x0 + par2.len0)  { len = par1.x0 + par1.len0 - Math.Min(par1.x0, par2.x0); }
        else                                            { len = par2.x0 + par2.len0 - Math.Min(par1.x0, par2.x0); }
        if (par1.width0 + par1.y0 > par2.y0 + par2.width0)  { width = par1.y0 + par1.width0 - Math.Min(par1.y0, par2.y0); }
        else                                                { width = par2.y0 + par2.width0 - Math.Min(par1.y0, par2.y0); }
        if (par1.height0 + par1.z0 > par2.z0 + par2.height0) { height = par1.z0 + par1.height0 - Math.Min(par1.z0, par2.z0); }
        else                                                 { height = par2.z0 + par2.height0 - Math.Min(par1.z0, par2.z0); }
        Parallelepiped parfin = new Parallelepiped(x, y, z, len, width, height);
        return parfin;
    }
    public void print(Parallelepiped par)
    {
        Console.WriteLine($"Coordinates of start (x, y, z) = ({par.x0}, {par.y0}, {par.z0})\n" +
            $"Coordinates of finish(x, y, z) = ({par.x0 + par.len0}, {par.y0 + par.width0}, {par.z0 + par.height0})");
        Console.WriteLine($"length = {par.len0}; width = {par.width0}; height = {par.height0}");
    }
}



internal class Program
{
    static void print(Parallelepiped par)
    {
        Console.WriteLine($"\nCoordinates of start (x, y, z) = ({par.x0}, {par.y0}, {par.z0})");
        Console.WriteLine($"length = {par.len0}; width = {par.width0}; height = {par.height0}");
    }
    static Parallelepiped FigureInit()
    {
        double x = 0, y = 0, z = 0;
        double len = 0, width = 0, height = 0;
        Console.Write("Insert necessary information about parallelepiped with which you wanna work:\n");
        Console.Write("x -> "); x += Convert.ToDouble(Console.ReadLine());
        Console.Write("y -> "); y += Convert.ToDouble(Console.ReadLine());
        Console.Write("z -> "); z += Convert.ToDouble(Console.ReadLine());
        Console.Write("Length -> "); len = Convert.ToDouble(Console.ReadLine());
        Console.Write("Width -> "); width = Convert.ToDouble(Console.ReadLine());
        Console.Write("Height -> "); height = Convert.ToDouble(Console.ReadLine());
        //Console.Write($"\tLength -> {len} ___ Width -> {width} ___ height -> {height}");
        var parall = new Parallelepiped(x, y, z, len, width, height);
        return parall;
    }
    private static void Main(string[] args)
    {
        // for tests
        //Parallelepiped par1 = new ( 1, 1, 1, 6, 2, 4 );
        //var par2 = new Parallelepiped(2, 2, 2, 4, 5, 4);
        Parallelepiped par1 = FigureInit();
        Parallelepiped par2 = FigureInit();
        Console.Write($"You've got:");
        print(par1);
        Console.Write($"====================");
        print(par2);
        Parallelepiped parfin = new(0, 0, 0, 0, 0, 0);
        par1.CmdInit(par1, par2, parfin);
    }
}