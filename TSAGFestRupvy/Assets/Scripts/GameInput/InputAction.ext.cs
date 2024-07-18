namespace GameInput
{
    public partial class InputAction
    {
        private static InputAction _instance;

        public static InputAction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputAction();
                    _instance.Enable();
                }

                return _instance;
            }
            private set => _instance = value;
        }

        public object Game { get; internal set; }

        internal class CallbackContext
        {
        }
    }

}
