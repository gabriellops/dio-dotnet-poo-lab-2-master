using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string UserOption = GetUserOption();

			while (UserOption.ToUpper() != "X")
			{
				switch (UserOption)
				{
					case "1": ListSeries(); break;
					case "2": InsertSeries(); break;
					case "3": UpdateSeries(); break;
					case "4": DeleteSeries(); break;	
					case "5": ViewSeries(); break; 
					case "C": Console.Clear(); break;
					default: throw new ArgumentOutOfRangeException();			
				}

				UserOption = GetUserOption();
			}

			Console.WriteLine("Thank you for using our services!");
			Console.ReadLine();
        }

		private static void ListSeries()
		{
			Console.WriteLine("Series list");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("No series registered.");
				return;
			}

			foreach (var series in list)
			{
                var deleted = series.ReturnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", series.ReturnId(), series.ReturnTitle(), (deleted ? "*Deleted*" : ""));
			}
		}

		private static void InsertSeries()
		{
			Console.WriteLine("Insert new series");


			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Enter the genre from the options above: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter the series title: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the start year of the series: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter the series description: ");
			string descriptionInput = Console.ReadLine();

			Series newSeries = new Series(id: repository.NextId(),
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Insert(newSeries);
		}
		private static void UpdateSeries()
		{
			Console.Write("Enter the series ID: ");
			int seriesIndex = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Enter the genre from the options above: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter the series title: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the start year of the series: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter the series description: ");
			string descriptionInput = Console.ReadLine();

			Series updateSeries = new Series(id: seriesIndex,
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Update(seriesIndex, updateSeries);
		}

		private static void DeleteSeries()
		{
			Console.Write("Enter the series ID: ");
			int seriesIndex = int.Parse(Console.ReadLine());

			repository.Delete(seriesIndex);
		}

        private static void ViewSeries()
		{
			Console.Write("Enter the series ID: ");
			int seriesIndex = int.Parse(Console.ReadLine());

			var series = repository.ReturnById(seriesIndex);

			Console.WriteLine(series);
		}

        
        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Choose an option:");

			Console.WriteLine("1- List series");
			Console.WriteLine("2- Insert new series");
			Console.WriteLine("3- Update series");
			Console.WriteLine("4- Delete series");
			Console.WriteLine("5- View series");
			Console.WriteLine("C- Clear console");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string UserOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return UserOption;
		}
    }
}
