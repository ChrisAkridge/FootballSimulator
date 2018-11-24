using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FootballSimulatorLight
{
	public class Team
	{
		public string Name { get; private set; }
		public Conference Conference { get; private set; }
		public Division Division { get; private set; }

		public string HomeStadiumName { get; private set; }
		public string HomeStadiumLocation { get; private set; }

		public double Strength { get; private set; }

		public Team()
		{

		}

		public Team(string name, Conference conference, Division division, string homeStadiumName, string homeStadiumLocation, double strength)
		{
			this.Name = name;
			this.Conference = conference;
			this.Division = division;
			this.HomeStadiumName = homeStadiumName;
			this.HomeStadiumLocation = homeStadiumLocation;
			this.Strength = strength;
		}

		private object GetSerializableObjects()
		{
			return new
			{
				name = this.Name,
				conference = (int)this.Conference,
				division = (int)this.Division,
				homeStadiumName = this.HomeStadiumName,
				HomeStadiumLocation = this.HomeStadiumLocation,
				strength = this.Strength
			};
		}

		public string Serialize()
		{
			return JObject.FromObject(this.GetSerializableObjects()).ToString();
		}

		public void Deserialize(JArray obj)
		{
			this.Name = (string)obj["name"];
			this.Conference = (Conference)(int)obj["conference"];
			this.Division = (Division)(int)obj["division"];
			this.HomeStadiumName = (string)obj["homeStadiumName"];
			this.HomeStadiumLocation = (string)obj["homeStadiumLocation"];
			this.Strength = (double)obj["strength"];
		}
	}
}
