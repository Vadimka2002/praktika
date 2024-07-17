using System.IO;
using System.Xml.Linq;

Dictionary<string, string> dictionary = new Dictionary<string, string>();
Console.Write( "Введите путь к файлу: " );
string FilePath = Console.ReadLine();
Menu();

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

void AddDictionary()
{
    string line;
    if ( !File.Exists( FilePath ) )
    {
        Console.WriteLine( "Файл словаря не найден, создаем новый." );
        using ( File.Create( FilePath ) )
        { }
        return;
    }

    using ( StreamReader file = new StreamReader( $"{FilePath}" ) )
    {
        line = file.ReadLine();
        while ( line != null )
        {
            string[] words = line.Split( new char[] { ':' } );
            dictionary[ words[ 0 ] ] = words[ 1 ];
            line = file.ReadLine();
        }
    }    
}

void AddWords()
{
    Console.Write( $"Введите слово: " );
    string name = Console.ReadLine();
    Console.Write( $"Введите перевод слова {name}: " );
    string translate = Console.ReadLine();
    if( dictionary.ContainsKey( name ) == true )
    {
        Console.WriteLine( $"Слово {name} уже есть в словаре, переводится как {dictionary[ name ]}" );
    }
    else
    {
        dictionary.Add( name, translate );
        Console.WriteLine( $"Слово {name} добавлено в словарь." );
    }      
}

void TranslateWords()
{
    Console.Write( "Введите слово, которое хотите перевести: " );
    string name = Console.ReadLine() ;
    if ( ( dictionary.ContainsKey( name ) == false ) )
    {
        Console.WriteLine( "Такого слова нет в словаре." );
        Console.WriteLine( $"Хотите добавить {name} в словарь?" );
        Console.Write( "Введите 'Да', если хотите добавить: " );
        if ( Console.ReadLine() == "Да" )
            AddWords();       
    }
    else
    {
        Console.WriteLine( $"Перевод слова {name}: {dictionary[name]}" );
    }    
}

void AddDictionaryInFile()
{
    using ( StreamWriter file = new StreamWriter( $"{FilePath}" ) )
    {
        foreach ( KeyValuePair<string, string> word in dictionary )
        {
            file.WriteLine( $"{word.Key}:{word.Value}" );
        }
    }    
}
