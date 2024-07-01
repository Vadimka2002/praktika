static void EnterData()
{
    Console.Write( $"Название товара: " );
    string product = Console.ReadLine();
    Console.Write( $"Количество товара: " );
    string count = Console.ReadLine();
    Console.Write( $"Имя пользователя: " );
    string name = Console.ReadLine();
    Console.Write( $"Адрес доставки: " );
    string address = Console.ReadLine();

    Confirm( product, count, name, address );
}

static void Confirm( string product, string count, string name, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно?" );
    if ( Console.ReadLine() == "Да" )
    {
        Success( product, count, name, address );
    }
    else
    {
        Console.WriteLine( $"Введены некорректные данные" );
        Console.WriteLine( $"Введены некорректные данные" );
    }
}

static void Success( string product, string count, string name, string address )
{
    DateTime thisDay = DateTime.Today.AddDays( 3 );
    Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {thisDay.ToString( "D" )}" );
}

EnterData();
