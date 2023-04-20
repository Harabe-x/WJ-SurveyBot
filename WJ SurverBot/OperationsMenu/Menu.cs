using WJ_SurveyBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.VisualEffects;

namespace WJ_SurveyBot.OperationsMenu
{
    internal class Menu : IMenu
    {
        #region Fields

        /// <summary>
        /// Stores selected index by user
        /// </summary>
        private int _selectedIndex;

        /// <summary>
        /// Stores menu options
        /// </summary>
        private readonly string[] _options;

        /// <summary>
        /// Prompt
        /// </summary>
        private readonly string _prompt;

        /// <summary>
        /// First launch flag
        /// </summary>
        private bool _firstTime = true;

        /// <summary>
        /// Writing Animation
        /// </summary>
        private readonly IWriteAnimation _writeAnimation;

        #endregion

        #region Ctor

        public Menu(string[] options, string prompt, IWriteAnimation? writeAnimation = null)
        {
            _selectedIndex = 0;
            _options = options;
            _prompt = prompt;
            Console.CursorVisible = false;
            _writeAnimation = writeAnimation;
            if (_writeAnimation == null) _firstTime = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Runs the menu and returns the selected index
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
                DisplayOptions();
                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                switch (keyPressed)
                {
                    case ConsoleKey.DownArrow:
                    {
                        _selectedIndex++;
                        if (_selectedIndex == _options.Length)
                            _selectedIndex = 0;
                        break;
                    }
                    case ConsoleKey.UpArrow:
                    {
                        _selectedIndex--;
                        if (_selectedIndex == -1)
                            _selectedIndex = _options.Length - 1;
                        break;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }

        /// <summary>
        /// Writes menu to the screen
        /// </summary>
        private void DisplayOptions()
        {
            if (_firstTime)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                _writeAnimation?.Write(_prompt, TimeSpan.FromMilliseconds(1));
                _firstTime = false;
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(_prompt);
                Console.ResetColor();
            }

            for (var i = 0; i < _options.Length; i++)
            {
                var currentOption = _options[i];
                string prefix = i == _selectedIndex ? "*" : " ";
                Console.ForegroundColor = i == _selectedIndex ? ConsoleColor.Black : ConsoleColor.White;
                Console.BackgroundColor = i == _selectedIndex ? ConsoleColor.White : ConsoleColor.Black;
                Console.WriteLine($"{prefix} << {currentOption} >>");
                Console.ResetColor();
            }
        }

        #endregion
    }
}
