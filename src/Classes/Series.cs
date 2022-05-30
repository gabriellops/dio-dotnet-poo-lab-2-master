using System;

namespace DIO.Series
{
    public class Series : BaseEntity
    {
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}
    
		public Series(int id, Genre genre, string title, string description, int year)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
		{
            string returnString = "";
            returnString += "Genre: " + this.Genre + Environment.NewLine;
            returnString += "Title: " + this.Title + Environment.NewLine;
            returnString += "Description: " + this.Description + Environment.NewLine;
            returnString += "Year: " + this.Year + Environment.NewLine;
            returnString += "Deleted: " + this.Deleted;
			return returnString;
		}

        public string ReturnTitle()
		{
			return this.Title;
		}

		public int ReturnId()
		{
			return this.Id;
		}
        public bool ReturnDeleted()
		{
			return this.Deleted;
		}
        public void DeleteTrue() {
            this.Deleted = true;
        }
    }
}