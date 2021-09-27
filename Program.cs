using System;
using DIO.Series;

namespace DIO.Series
{
    class Program
    {
        static SerieCamada serieCamada = new SerieCamada();
		static FilmeCamada filmeCamada = new FilmeCamada();
		static AnimeCamada animeCamada = new AnimeCamada();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						filmeCamada.OpcaoFilme();
						break;
					case "2":
						serieCamada.OpcaoSerie();
						break;
					case "3":
						animeCamada.OpcaoAnime();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();

			}
	
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO entreterimento a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Filmes");
			Console.WriteLine("2- Séries");
			Console.WriteLine("3- Animes");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
