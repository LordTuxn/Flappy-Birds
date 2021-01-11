using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird__OOP_ {

    public delegate void LeavingEventType(Pipe leavingPipe);

    public class Pipe : MovableGameElement {
        private const int _WIDTH = 90;

        private static readonly Random _rndGen = new Random();

        private readonly Panel _upperPart, _lowerPart;

        public Pipe(Size formSize) : base(new Size(_WIDTH, formSize.Height)) {
            // Create a rectangle as a placeholder between the upper and lower part of the pipe
            Rectangle emptySpace = new Rectangle {
                Size = new Size(_WIDTH, formSize.Height / 3),
                Location = new Point(0, _rndGen.Next(10, formSize.Height - (formSize.Height / 3) - 11))
            };

            // Create and position the upper part with the remaining size of the placeholder
            _upperPart = new Panel {
                BackColor = Color.DarkOliveGreen,
                Size = new Size(_WIDTH, formSize.Height - emptySpace.Height - (formSize.Height - emptySpace.Bottom))
            };

            // Create and position the lower part with the remaining size of the placeholder
            _lowerPart = new Panel {
                BackColor = Color.DarkOliveGreen,
                Size = new Size(90, formSize.Height - emptySpace.Height - _upperPart.Height),
                Location = new Point(0, emptySpace.Bottom)
            };

            // Position the pipe and set the speed
            Location = new Point(formSize.Width, 0);
            _xMovingPixels = -9;

            // Add the two parts to the controls of the pipe
            Controls.Add(_upperPart);
            Controls.Add(_lowerPart);
        }

        public override void MoveElement(Size formSize) {
            // Query whether the pipe is outside the playing field
            if (Right < 0) {
                Leaving?.Invoke(this);
            }

            // Move Pipe
            base.MoveElement(formSize);
        }

        public bool CollidesWith(MovableGameElement element) {
            // Query whether a Bird collides with the Pipe
            if (element.Right >= Left && element.Left <= Right) {
                if (element.Top <= _upperPart.Bottom || element.Bottom >= _lowerPart.Top) {
                    return true;
                }
            }
            return false;
        }

        public event LeavingEventType Leaving;
    }
}