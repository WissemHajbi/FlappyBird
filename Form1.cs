
namespace FirstGame
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = new Random().Next(700, 1000);
                score++;
            }
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = new Random().Next(700, 1000); ;
                score++;
            }
            if (score % 10 == 0 && score > 10) pipeSpeed++; 
            scoreText.Text = $"SCORE: {score}";
            endgame();
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endgame()
        {
            if(flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                gameTimer.Stop();
                MessageBox.Show($"Game Over \nScore : {score}");
            }
        }

    }
}