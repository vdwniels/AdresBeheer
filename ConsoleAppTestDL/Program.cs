// See https://aka.ms/new-console-template for more information
using AdresbeheerBL.Interfaces;
using AdresbeheerDL.Repositories;

Console.WriteLine("Hello, World!");
string connString = @"Data Source=FRENK\SQLEXPRESS;Initial Catalog=AdresBeheerREST;Integrated Security=True";
//IGemeenteRepository repo = new GemeenteRepositoryADO(connString);
//var g=repo.GeefGemeente(50000);
IStraatRepository srepo =new StraatRepositoryADO(connString);

var straten = srepo.GeefStratenGemeente(50000);
//Console.WriteLine(g);
Console.WriteLine(straten);
