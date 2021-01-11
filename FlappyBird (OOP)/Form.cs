using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlappyBird__OOP_ {

    public partial class Form : System.Windows.Forms.Form {
        //---------------------
        // Variables
        //---------------------

        #region
        private readonly List<Bird> _birds;

        private static readonly Random _rndRandom = new Random();

        private bool _gameIsRunning;

        public bool GameIsRunning {
            get { return _gameIsRunning; }
            set {
                _gameIsRunning = value;

                if (value) {
                    tmr_generatePipe.Start();
                    tmr_moveGameElements.Start();
                    tmr_switchMode.Start();
                } else {
                    tmr_generatePipe.Stop();
                    tmr_moveGameElements.Stop();
                    tmr_switchMode.Stop();
                }
            }
        }

        private int _score;

        public int Score {
            get { return _score; }
            set {
                _score = value;

                Text = $"Flappy Birds | Score: {value}";
            }
        }

        private bool _isAlternateMode;

        public bool IsAlternateMode {
            get { return _isAlternateMode; }
            set {
                _isAlternateMode = value;

                if (value) {
                    BackColor = Color.Black;
                } else {
                    BackColor = Color.White;
                }
            }
        }

        #endregion

        //---------------------
        // Initialize Game
        //---------------------

        #region

        public Form() {
            InitializeComponent();

            _birds = new List<Bird>() {
                new Bird(ClientSize, Color.Blue, 1, 1),
                //new Bird(ClientSize, Color.DarkViolet, 2, 2)
            };

            CenterToScreen();

            InitializeGame();
        }

        private void InitializeGame() {
            // Add all birds to the field
            foreach (Bird bird in _birds) {
                bird.Initialize(ClientSize);
                bird.GameOver += GameOver;
                Controls.Add(bird);
            }

            Score = 0;
            IsAlternateMode = false;
        }

        #endregion

        //---------------------
        // Timers
        //---------------------

        #region

        private void Tmr_moveGameElements_Tick(object sender, EventArgs e) {
            foreach (MovableGameElement element in Controls) {
                // Move all game elements
                element.MoveElement(ClientSize);

                // Check if a bird is colliding with a pipe
                if (element is Bird) {
                    foreach (Pipe pipe in Controls.OfType<Pipe>()) {
                        if (pipe.CollidesWith(element)) {
                            GameOver();
                        }
                    }
                }
            }
        }

        // Create a new pipe
        private void Tmr_generatePipe_Tick(object sender, EventArgs e) {
            Pipe pipe = new Pipe(ClientSize);
            pipe.Leaving += Pipe_Leaving;
            Controls.Add(pipe);
        }

        private void Tmr_switchMode_Tick(object sender, EventArgs e) {
            // Set a random interval between 2,5 and 5 seconds
            tmr_switchMode.Interval = _rndRandom.Next(2500, 5000 + 1);

            IsAlternateMode = !_isAlternateMode;
        }

        #endregion

        //---------------------
        // Events
        //---------------------

        #region

        private void GameOver() {
            GameIsRunning = false;

            // Remove all game elements from the field (only removing the pipes doesn't work for some reason...)
            Controls.Clear();
            
            //foreach (Bird bird in Controls.OfType<Bird>()) {
            //   bird.Initialize(ClientSize);
            //}

            //foreach (Pipe pipe in Controls.OfType<Pipe>()) {
            //    pipe.Leaving -= Pipe_Leaving;
            //    Controls.Remove(pipe);
            //}
             
            // Output message
            DialogResult result = MessageBox.Show($"Your Score: {Score}\n\nDo you want to play again?", "Game Over", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                InitializeGame();
            } else {
                Application.Exit();
            }
        }

        private void Pipe_Leaving(Pipe leavingPipe) {
            leavingPipe.Leaving -= Pipe_Leaving;
            Controls.Remove(leavingPipe);

            Score += 1;
        }

        private void FlapBird(int birdnumber) {
            for (int i = 1; i <= _birds.Count; i++) {
                if (i == birdnumber) {
                    _birds[i - 1].Flap();
                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e) {
            // Start the game if it isn't already running
            if (!_gameIsRunning) {
                GameIsRunning = true;
            }

            switch (e.KeyCode) {
                case Keys.Space:
                    // Switch the birds depanding on the game mode
                    FlapBird(_isAlternateMode ? 2 : 1);
                    break;

                case Keys.Up:
                    FlapBird(_isAlternateMode ? 1 : 2);
                    break;
            }
        }

        #endregion
    }
}