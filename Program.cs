using System;
using System.Threading;
using System.IO;


namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1- Abrir arquivo");
            Console.WriteLine("2- Criar novo arquivo");
            Console.WriteLine("0- Sair");

            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 0: Exit(); break;
                case 1: OpenFile(); break;
                case 2: NewFile(); break;
                default: Menu(); break;
            }
        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using ( var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
                
            }
                Console.WriteLine("");
                Console.WriteLine("----------fim---------");
                Console.ReadLine();
                Menu();
        }

        static void NewFile()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("---------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

        static void Exit()
        {
            Console.WriteLine("Saindo...");
            Thread.Sleep(1000);
            Console.Clear();
            System.Environment.Exit(0);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.WriteLine("Saindo...");
            Thread.Sleep(2000);
            Menu();
        }
    } 
}