using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WJ_SurverBot.VisualEffects
{
    internal class WriteAnimation : IWriteAnimation
    {
        public void Write(string text, TimeSpan delay)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                if (text[i] == ' ')
                    continue;
                Thread.Sleep(delay.Milliseconds);
            }
            Console.WriteLine();
        }
        public void Pause()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey(true);
        }
    }
}
