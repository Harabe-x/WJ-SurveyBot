using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.VisualEffects;

namespace WJ_SurverBot.OperationsMenu
{
    internal class Menu
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
        private bool _firstTime = false;


        IWriteAnimation _writeAnimation;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="prompt"></param>
        #endregion
        #region Ctor
        public Menu(string[] options, string prompt, IWriteAnimation writeAnimation = null)
        {
            _selectedIndex = 0;
            _options = options;
            _prompt = prompt;
            Console.CursorVisible = false;
            _writeAnimation = writeAnimation;
            if (_writeAnimation == null)
            {
                _firstTime = false;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        ///Runs the menu and returns the selected index
        /// </summary>
        /// <returns></returns>
        internal int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
                DisplayOptions();
                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                        _selectedIndex = 0;


                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                        _selectedIndex = _options.Length - 1;

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

                _writeAnimation.Write(_prompt, TimeSpan.FromMilliseconds(1));
                _firstTime = !_firstTime;
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(_prompt);
                Console.ResetColor();
            }
            for (int i = 0; i < _options.Length; i++)
            {

                var currentOption = _options[i];
                string prefix;
                if (i == _selectedIndex)
                {

                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }

                Console.WriteLine($"{prefix} << {currentOption} >>");
            }
        }
        #endregion
    }
}

