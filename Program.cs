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
      EditarArquivo(); break;
    case 0:
      System.Environment.Exit(0); break;
    default: Menu(); break;
  }
}

static void AbrirArquivo()
{
  Console.Clear();
  Console.WriteLine("Qual o caminho do arquivo?");
  string path = Console.ReadLine();

  using (var file = new StreamReader(path))
  {
    string fileText = file.ReadToEnd();
    Console.Write("");

    Console.Write(fileText);

  }
}

static void EditarArquivo()
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
  Console.WriteLine("Qual caminho para salvar o arquivo?");
  var path = Console.ReadLine();

  using (var file = new StreamWriter(path))
  {
    file.Write(text);
  }

  Console.WriteLine($"Arquivo {path} salvo com sucesso!");
  Console.ReadLine();

  Menu();
}