static void EnterData()
{
    Console.Write( $"Название товара: " );
    string product = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( product ) )
    {
        Console.Write( $"Название товара: " );
        product = Console.ReadLine();
    }
    Console.Write( $"Количество товара: " );
    uint count;
    while ( !uint.TryParse( Console.ReadLine(), out count ) )
    {
        Console.Write( $"Количество товара: " );
    }
    Console.Write( $"Имя пользователя: " );
    string name = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( name ) )
    {
        Console.Write( $"Имя пользователя: " );
        name = Console.ReadLine();
    }
    Console.Write( $"Адрес доставки: " );
    string address = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( address ) )
    {
        Console.Write( $"Адрес доставки: " );
        address = Console.ReadLine();
    }

    Confirm( product, count, name, address );
}

static void Confirm( string product, uint count, string name, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно?" );
    if ( Console.ReadLine() == "Да" )
    {
        Success( product, count, name, address );
    }
    else
    {
        Console.WriteLine( $"Введены некорректные данные" );
    }
}

static void Success( string product, uint count, string name, string address )
{
    DateTime thisDay = DateTime.Today.AddDays( 3 );
    Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {thisDay.ToString( "D" )}" );
}

EnterData();
