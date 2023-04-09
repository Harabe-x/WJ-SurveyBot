using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WJ_SurverBot.VisualEffects
{
    internal interface IWriteAnimation
    {

        void Write(string text, TimeSpan delay);

       void Pause();
    }
}
