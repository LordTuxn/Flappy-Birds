using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird__OOP_ {

    public abstract class MovableGameElement : Panel {
        protected int _xMovingPixels;

        protected int _yMovingPixels;

        protected MovableGameElement(Size elementSize) {
            Size = elementSize;
        }

        public virtual void MoveElement(Size formSize) {
            Left += _xMovingPixels;
            Top += _yMovingPixels;
        }
    }
}