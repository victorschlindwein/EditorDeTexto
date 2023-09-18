Menu();

static void Menu()
{
  Console.Clear();
  Console.WriteLine("O que você deseja fazer?");
  Console.WriteLine("1 - Abrir arquivo");
  Console.WriteLine("2 - Novo arquivo");
  Console.WriteLine("0 - Sair");

  short option = short.Parse(Console.ReadLine());

  switch (option)
  {
    case 1:
      AbrirArquivo(); break;
    case 2:
      CriarArquivo(); break;
    case 0:
      System.Environment.Exit(0); break;
    default: Menu(); break;
  }
}

static void AbrirArquivo()
{
  Console.Clear();
  Console.WriteLine("Qual arquivo você deseja abrir?");

  string[] fyles = Directory.GetFiles("C:/dev/texteditor/texts", "*", 0);
  Console.WriteLine(String.Join(Environment.NewLine, fyles));

  string filename = Console.ReadLine();
  string path = $"C:/dev/texteditor/texts/{filename}.txt";

  using (var file = new StreamReader(path))
  {
    string fileText = file.ReadToEnd();
    Console.Write("");

    Console.Write(fileText);
  }
}

static void CriarArquivo()
{
  Console.Clear();
  Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
  Console.WriteLine("-----------------------");
  string text = "";

  do
  {
    text += Console.ReadLine();
    text += Environment.NewLine;
  }
  while (Console.ReadKey().Key != ConsoleKey.Escape);

  SalvarArquivo(text);
}

static void SalvarArquivo(string text)
{
  Console.Clear();
  Console.WriteLine("Qual o nome do arquivo?");
  string filename = Console.ReadLine();
  string path = $"C:/dev/texteditor/texts/{filename}.txt";

  using (var file = new StreamWriter(path))
  {
    file.Write(text);
  }

  Console.WriteLine($"Arquivo {path} salvo com sucesso!");
  Console.ReadLine();

  Menu();
}