using System.Collections.Generic;
using DIO.Series.src.Interfaces;

namespace DIO.Series
{
	public class SeriesRepository : IRepository<Series>
	{
        private List<Series> seriesList = new List<Series>();
		public void Update(int id, Series entity)
		{
			seriesList[id] = entity;
		}

		public void Delete(int id)
		{
			seriesList[id].DeleteTrue();
		}

		public void Insert(Series entity)
		{
			seriesList.Add(entity);
		}

		public List<Series> List()
		{
			return seriesList;
		}

		public int NextId()
		{
			return seriesList.Count;
		}

		public Series ReturnById(int id)
		{
			return seriesList[id];
		}
	}
}