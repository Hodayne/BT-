using System;

class Program
{
    static int Menu(string msg)
    {
        Console.WriteLine($"\n{msg}:");
        Console.WriteLine("1. Binary (2)");
        Console.WriteLine("2. Decimal (10)");
        Console.WriteLine("3. Hexadecimal (16)");
        Console.Write("Chon (1-3, 0 de thoat): ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 0) Environment.Exit(0);
        if (choice < 1 || choice > 3) throw new ArgumentException("Lua chon khong hop le");
        return choice;
    }

    static string ConvertBase(string val, int fromBase, int toBase)
    {
        try
        {
            int num = Convert.ToInt32(val, fromBase);
            string result = Convert.ToString(num, toBase).ToUpper();
            return result;
        }
        catch (FormatException)
        {
            return "Gia tri khong hop le cho he co so da chon";
        }
        catch (Exception)
        {
            return "Loi khong xac dinh";
        }
    }

    static void Main()
    {
        while (true)
        {
            int fromBase = Menu("He co so dau vao");
            int toBase = Menu("He co so dau ra");
            Console.Write("Nhap gia tri: ");
            string value = Console.ReadLine();

            string result = ConvertBase(value, fromBase == 1 ? 2 : fromBase == 2 ? 10 : 16, 
                                      toBase == 1 ? 2 : toBase == 2 ? 10 : 16);
            Console.WriteLine("Ket qua: " + result);

            Console.Write("Tiep tuc? (y/n): ");
            if (Console.ReadLine().ToLower() != "y") break;
            Console.WriteLine();
        }
    }
}