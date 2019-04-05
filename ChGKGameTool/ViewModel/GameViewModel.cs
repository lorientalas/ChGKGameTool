using System;
using System.Collections.Generic;
using System.Linq;

namespace ChGKGameTool.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        public class GameEntry
        {
            private Random _random = new Random();
            private GameViewModel _parent;
            public GameEntry(GameViewModel game, string name)
            {
                _parent = game;
                GameEntryName = name;
                Answers = new SortedList<int,bool>();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 12; j++)
                        Answers.Add(i * 12 + j, _random.Next(0, 100) > 49);
                RoundScore = Answers.Where(a => a.Key == _parent.CurrentRound && a.Value).Count();
                GameScore = Answers.Where(a => a.Value).Count();
            }

            public string GameEntryName { get; set; }
            public SortedList<int,bool> Answers { get; set; }
            public float RoundScore { get; set; }
            public float GameScore { get; set; }
        }

        public string GameName { get; set; } = "Test game";
        public List<GameEntry> GameEntries { get; set; }
        public int CurrentRound { get; set; } = 1;

        #region Conctructor
        public GameViewModel()
        {
            GameEntries = new List<GameEntry>();
            for(int i=0; i<10; i++)
            {
                GameEntries.Add(new GameEntry(this, $"Team {i + 1}"));
            }
        }
        #endregion
    }
}
