using UnityEngine;
using UnityEngine.Assertions;

namespace InputReader
{
    /// <summary>
    /// default = WASD - JKL
    /// </summary>
    public class InputReaderKey : IInputReader
    {

        protected KeyCode _interactKey;
        protected KeyCode _attackKey;
        protected KeyCode _jumpKey;
        protected KeyCode _rollKey;
        protected string _xAxis;
        protected string _yAxis;


        public InputReaderKey()
        {
            _interactKey = KeyCode.Space;
            _jumpKey = KeyCode.K;
            _rollKey = KeyCode.L;
            _attackKey = KeyCode.J;
            _xAxis = "KeyboardHorizontal";
            _yAxis = "KeyboardVertical";
        }
		
        public InputReaderKey(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify)
        {
            Assertions(xAxis, yAxis, interact, jump, tool, notify);
			
            _interactKey = interact;
            _jumpKey = jump;
            _rollKey = tool;
            _attackKey = notify;
            _xAxis = xAxis;
            _yAxis = yAxis;
        }

        private static void Assertions(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify)
        {
            Assert.IsFalse(xAxis.Equals(yAxis));
            Assert.IsFalse(interact==jump);
            Assert.IsFalse(tool==jump);
            Assert.IsFalse(tool==interact);
            Assert.IsFalse(notify==jump);
            Assert.IsFalse(notify==tool);
            Assert.IsFalse(notify==interact);
        }

        public virtual Vector2 Stick => new Vector2(Input.GetAxis(_xAxis),Input.GetAxis(_yAxis));

        public virtual bool OnInteract => Input.GetKeyDown(_interactKey);
        public virtual bool Interacting => Input.GetKey(_interactKey);
        public virtual bool OffInteract => Input.GetKeyUp(_interactKey);

        public virtual bool OnJump => Input.GetKeyDown(_jumpKey);
        public virtual bool Jumping => Input.GetKey(_jumpKey);
        public virtual bool OffJump => Input.GetKeyUp(_jumpKey);

        public virtual bool OnRoll => Input.GetKeyDown(_rollKey);
        public virtual bool Rooling => Input.GetKey(_rollKey);
        public virtual bool OffRool => Input.GetKeyUp(_rollKey);

        public virtual bool OnAttack => Input.GetKeyDown(_attackKey);
        public virtual bool Attacking => Input.GetKey(_attackKey);
        public virtual bool OffAttack => Input.GetKeyUp(_attackKey);

        public virtual void ButtonInput()
        {

        }
    }
}