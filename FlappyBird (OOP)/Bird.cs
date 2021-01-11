using System.Drawing;

namespace FlappyBird__OOP_ {

    public delegate void GameOverEventType();

    public class Bird : MovableGameElement {
        private readonly Color _originalColor;

        private readonly int _originalTop;

        private int _gravity;

        public Bird(Size formSize, Color color, int numberOfBirds, int birdnumber) : base(new Size(45, 30)) {
            _originalColor = color;

            // Position the bird depanding on the number of players
            switch (numberOfBirds) {
                case 1:
                    _originalTop = ((formSize.Height - Height) / 2) * birdnumber;
                    break;

                case 2:
                    _originalTop = ((formSize.Height - Height) / 3) * birdnumber;
                    break;

                case 3:
                    _originalTop = ((formSize.Height - Height) / 4) * birdnumber;
                    break;
            }
        }

        public void Initialize(Size formSize) {
            BackColor = _originalColor;
            Location = new Point(formSize.Width / 4, _originalTop);
            _gravity = 0;
        }

        public override void MoveElement(Size formSize) {
            // Change gravity
            _yMovingPixels = _gravity;
            _gravity += 1;

            // Move bird
            base.MoveElement(formSize);

            // Check if bird is outside of the field
            if (IsLeaving(formSize)) {
                Die();
                GameOver?.Invoke();
            }
        }

        public void Die() {
            BackColor = Color.Red;
        }

        public void Flap() {
            _gravity = -15;
        }

        private bool IsLeaving(Size formSize) {
            if (Top < 0 || Top > formSize.Height) {
                return true;
            }
            return false;
        }

        public event GameOverEventType GameOver;
    }
}