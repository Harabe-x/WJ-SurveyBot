using Figgle;
using WJ_SurverBot.Json;
using WJ_SurverBot.Menu;
using WJ_SurverBot.Survey;
using WJ_SurverBot.Survey.ScenarioStrategy;
using WJ_SurverBot.VisualEffects;

namespace WJ_SurverBot
{
    internal class Application : IApplication
    {
       
      
        private readonly IWriteAnimation _writeAnimation;
    
        private readonly ISurveySender _surveySender;


        private readonly IJsonWriter _jsonWriter;

        public Application(ISurveySender surveySender, IWriteAnimation writeAnimation,IJsonWriter jsonWriter)
        {
            _jsonWriter = jsonWriter;
            _writeAnimation = writeAnimation; 
            _surveySender = surveySender;
    
        }
        public void Run()
        {
            var actionMenu = new ActionMenu();
            SurveyPattern pattern = new();
            var menu = new Menu.Menu(new string[] { "Send Surveys", "Add Survey Pattern", "Edit Survey Pattern", "Exit" }, @"
                                
                            █     █░▄▄▄██▀▀▀        ██████  █    ██  ██▀███   ██▒   █▓▓█████▓██   ██▓
                           ▓█░ █ ░█░  ▒██         ▒██    ▒  ██  ▓██▒▓██ ▒ ██▒▓██░   █▒▓█   ▀ ▒██  ██▒
                           ▒█░ █ ░█   ░██         ░ ▓██▄   ▓██  ▒██░▓██ ░▄█ ▒ ▓██  █▒░▒███    ▒██ ██░
                           ░█░ █ ░█▓██▄██▓          ▒   ██▒▓▓█  ░██░▒██▀▀█▄    ▒██ █░░▒▓█  ▄  ░ ▐██▓░ 
                           ░░██▒██▓ ▓███▒         ▒██████▒▒▒▒█████▓ ░██▓ ▒██▒   ▒▀█░  ░▒████▒ ░ ██▒▓░
                           ░ ▓░▒ ▒  ▒▓▒▒░         ▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░   ░ ▐░  ░░ ▒░ ░  ██▒▒▒ 
                           ▒ ░ ░  ▒ ░▒░         ░ ░▒  ░ ░░░▒░ ░ ░   ░▒ ░ ▒░   ░ ░░   ░ ░  ░▓██ ░▒░ 
                           ░   ░  ░ ░ ░         ░  ░  ░   ░░░ ░ ░   ░░   ░      ░░     ░   ▒ ▒ ░░  
                           ░    ░   ░               ░     ░        ░           ░     ░  ░░ ░     
                                                       ░          ░ ░                                                                                                                                                                                                  
             Select Options using Arrows", _writeAnimation) ;
            switch (menu.Run())
            {

                case 0:
                    actionMenu.SendSurveys(_surveySender);
                    Console.Clear();
                    break;
                    case 1:
                    pattern.AddPattern(_jsonWriter);
                    Console.Clear();
                    break;


                default:
                    break;
            }



        }



        
      
    }
}
