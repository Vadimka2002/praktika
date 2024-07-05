using System.IO;
using System.Xml.Linq;

Dictionary<string, string> glossary = new Dictionary<string, string>();
Console.Write( "Введите путь к файлу: " );
string PathToTheFile = Console.ReadLine();

void AddDictionary()
{
    string line;
    StreamReader sr = new StreamReader( $"{PathToTheFile}" );
    line = sr.ReadLine();    
    while ( line != null )
    {
        string[] words = line.Split( new char[] { ':' } );
        glossary[ words[ 0 ] ] = words[ 1 ];
        line = sr.ReadLine();
    }

    sr.Close();
}

void AddWords()
{
    Console.Write( $"Введите слово: " );
    string name = Console.ReadLine();
    Console.Write( $"Введите перевод слова {name}: " );
    string translate = Console.ReadLine();
    if(glossary.ContainsKey( name ) == true )
    {
        Console.WriteLine( $"Слово {name} уже есть в словаре, переводится как {glossary[ name ]}" );
    }
    else
    {
        glossary.Add( name, translate );
        Console.WriteLine( $"Слово {name} добавлено в словарь." );
    }      
}

void TranslateWords()
{
    Console.Write( "Введите слово, которое хотите перевести: " );
    string name = Console.ReadLine() ;
    if ( ( glossary.ContainsKey( name ) == false ) )
    {
        Console.WriteLine( "Такого слова нет в словаре." );
        Console.WriteLine( $"Хотите добавить {name} в словарь?" );
        Console.Write( "Введите 'Да', если хотите добавить: " );
        if ( Console.ReadLine() == "Да" )
            AddWords();       
    }
    else
    {
        Console.WriteLine( $"Перевод слова {name}: {glossary[name]}" );
    }    
}

void AddDictionaryInFile()
{
    StreamWriter sw = new StreamWriter( $"{PathToTheFile}" );
    foreach(string  word in glossary.Keys )
    {
        sw.WriteLine( $"{word}:{glossary[word]}" );
    }

    sw.Close();
}

void Menu()
{
    AddDictionary();
    while ( true )
    {
        Console.WriteLine( "Введите цифру 1, если хотите перевести слово." );
        Console.WriteLine( "Введите цифру 2, если хотите добавить слово." );
        Console.WriteLine( "Введите цифру 3, если хотите завершить." );
        string ch = Console.ReadLine();
        switch ( ch )
        {
            case "1":
                TranslateWords();
                break;
            case "2":
                AddWords();
                break;
            case "3":
                AddDictionaryInFile();
                return;
            default:
                Console.WriteLine( "Некорректный ввод" );
                break;
        }
    }    
}

Menu();
