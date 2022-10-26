using Mandatory_assignment_1;

namespace Assignment_1._4_REST
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;

       public static readonly List<FootballPlayer> footballPlayers = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name = "Bo", Age = 30, ShirtNumber = 42},
            new FootballPlayer {Id = _nextId++, Name = "Karl", Age = 27, ShirtNumber = 63},
            new FootballPlayer {Id = _nextId++, Name = "Erik", Age = 19, ShirtNumber = 21},
            new FootballPlayer {Id = _nextId++, Name = "Lars", Age = 23, ShirtNumber = 5},
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(footballPlayers);
        }

        public FootballPlayer GetById(int id)
        {
            return footballPlayers.Find(footballPlayer => footballPlayer.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            footballPlayers.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer footballPlayer = footballPlayers.Find(footballPlayer1 => footballPlayer1.Id == id);
            if (footballPlayer == null) return null;
            footballPlayers.Remove(footballPlayer);
            return footballPlayer;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer footballPlayer = footballPlayers.Find(footballPlayer1 => footballPlayer1.Id == id);
            if (footballPlayer == null) return null;
            footballPlayer.Name = updates.Name;
            footballPlayer.Age = updates.Age;
            footballPlayer.ShirtNumber = updates.ShirtNumber;
            return footballPlayer;
        }


    }
}
