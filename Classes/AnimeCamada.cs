using System;


namespace DIO.Series
{
    public class AnimeCamada
    {
        static AnimeRepositorio repositorioAnime = new AnimeRepositorio();

        private static string ObterOpcaoUsuarioAnime()
		{			
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Anime");
			Console.WriteLine("2- Inserir novo Anime");
			Console.WriteLine("3- Atualizar Anime");
			Console.WriteLine("4- Excluir Anime");
			Console.WriteLine("5- Visualizar Anime");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuarioAnime = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuarioAnime;
		}

        public void OpcaoAnime()
        {
            string opcaoUsuarioAnime = ObterOpcaoUsuarioAnime();

			while (opcaoUsuarioAnime.ToUpper() != "X")
			{
				switch (opcaoUsuarioAnime)
				{
					case "1":
						ListarAnimes();
						break;
					case "2":
						InserirAnime();
						break;
					case "3":
						AtualizarAnime();
						break;
					case "4":
						ExcluirAnime();
						break;
					case "5":
						VisualizarAnime();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuarioAnime = ObterOpcaoUsuarioAnime();

			}

        }

         private static void ListarAnimes()
		{
			Console.WriteLine("Listar animes");

			var lista = repositorioAnime.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum anime cadastrado.");
				return;
			}

			foreach (var anime in lista)
			{
                var excluido = anime.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirAnime()
		{
			Console.WriteLine("Inserir nova anime");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Anime: ");
			string entradaDescricao = Console.ReadLine();

			Anime novoAnime = new Anime(id: repositorioAnime.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioAnime.Insere(novoAnime);
		}

        private static void AtualizarAnime()
		{
			Console.Write("Digite o id da anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Anime: ");
			string entradaDescricao = Console.ReadLine();

			Anime atualizaAnime = new Anime(id: indiceAnime,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioAnime.Atualiza(indiceAnime, atualizaAnime);
		}

        private static void ExcluirAnime()
		{
			Console.Write("Digite o id do anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			repositorioAnime.Exclui(indiceAnime);
		}

        private static void VisualizarAnime()
		{
			Console.Write("Digite o id da anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			var anime = repositorioAnime.RetornaPorId(indiceAnime);

			Console.WriteLine(anime);
		}
    }
}