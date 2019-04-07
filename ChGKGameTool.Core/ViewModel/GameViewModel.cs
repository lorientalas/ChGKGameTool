using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChGKGameTool.Core
{
    public class GameViewModel : BaseViewModel
    {
        private static Random _random = new Random();
        public class GameEntry
        {
            
            private GameViewModel _parent;
            public GameEntry(GameViewModel game, string name)
            {
                _parent = game;
                GameEntryName = name;
                Answers = new SortedList<int,bool>();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Answers.Add(i * 12 + j, _random.Next(0, 100) > 50);
                        Score += Answers.Where(a => a.Key == i * 12 + j).Single().Value ? "+" : "-";
                    }
                    Score += " ";
                }
                RoundScore = Answers.Where(a => a.Key <= _parent.CurrentRound * 12 && a.Key > (_parent.CurrentRound - 1) * 12 && a.Value).Count();
                GameScore = Answers.Where(a => a.Value).Count();
            }

            public string GameEntryName { get; set; }
            public SortedList<int,bool> Answers { get; set; }
            public float RoundScore { get; set; }
            public float GameScore { get; set; }
            public string Score { get; set; } = "";
        }

        public string GameName { get; set; } = "Test game";
        public ObservableCollection<GameEntry> GameEntries { get; set; }
        public int CurrentRound { get; set; } = 1;

        #region Conctructor
        public GameViewModel()
        {
            var entries = new List<GameEntry>();
            for (int i=0; i<20; i++)
            {
                entries.Add(new GameEntry(this, $"Team {i + 1}"));
            }
            GameEntries = new ObservableCollection<GameEntry>(entries);
        }
        #endregion
    }
}
