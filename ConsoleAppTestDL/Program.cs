// See https://aka.ms/new-console-template for more information
using AdresbeheerBL.Interfaces;
using AdresbeheerDL.Repositories;

Console.WriteLine("Hello, World!");
string connString = @"Data Source=NB21-6CDPYD3\SQLEXPRESS;Initial Catalog=AdresbeheerREST_maandag;Integrated Security=True";
IGemeenteRepository repo = new GemeenteRepositoryADO(connString);
var g=repo.GeefGemeente(50000);
Console.WriteLine(g);
