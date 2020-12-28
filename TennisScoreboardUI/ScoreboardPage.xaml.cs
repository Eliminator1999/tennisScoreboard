using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisScoreboardBackend;

namespace TennisScoreboardUI
{
    /// <summary>
    /// Interaction logic for ScoreboardPage.xaml
    /// </summary>
    public partial class ScoreboardPage : Page
    {
        private readonly Match match;
        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public ScoreboardPage(List<string> playerNames)
        {
            InitializeComponent();

            this.firstPlayer = new Player(playerNames[0]);
            this.secondPlayer = new Player(playerNames[1]);
            this.match = new Match(firstPlayer, secondPlayer);

            this.FirstPlayerName.Text = playerNames[0];
            this.SecondPlayerName.Text = playerNames[1];
        }

        private void AddScore(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag;

            if (tag.ToString() == "firstPlayer")
            {
                this.match.AddScore(this.firstPlayer);
            }
            else
            {
                this.match.AddScore(this.secondPlayer);
            }
            GetScore();
            if (match.GetState() == Match.State.finished)
            {
                MessageBox.Show(match.GetWinner().name + "has won");
            }

        }
        private void GetScore()
        {
            Dictionary<uint, List<string>> totalScore = this.match.getScore();
            this.FirstPlayerPointScore.Text = totalScore[this.firstPlayer.id][0];
            this.SecondPlayerPointScore.Text = totalScore[this.secondPlayer.id][0];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var foundTextBlock = ScoreGrid.Children.OfType<TextBlock>().Where(x => x.Tag.ToString() == (i.ToString()+j.ToString())).FirstOrDefault();
                    if (i == 0)
                    {
                        foundTextBlock.Text = totalScore[this.firstPlayer.id][j+1];
                    }
                    else
                    {
                        foundTextBlock.Text = totalScore[this.secondPlayer.id][j+1];
                    }
                }

            }
            


        }
    }
}
