namespace InputSystem
{
    public class ButtonsInputSystem : IInputSystem
    {
        private readonly MoveButton _leftButton;
        private readonly MoveButton _rightButton;

        public ButtonsInputSystem(MoveButton leftButton, MoveButton rightButton)
        {
            _leftButton = leftButton;
            _rightButton = rightButton;
        }

        public int GetMoveDirection()
        {
            return _rightButton.Pressed ? _rightButton.Direction : _leftButton.Pressed ? _leftButton.Direction : 0;
        }
    }
}