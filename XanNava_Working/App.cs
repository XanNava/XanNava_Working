using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using PlayGroundLibrary.BusinessLogic;
using PlayGroundLibrary.Models;

namespace PlayGround;

public class App
{
    private Settings _settings;
    
    private readonly IMessages _messages;
    private readonly ILogger<App> _log;
    
    public App(IMessages messages, ILogger<App> log)
    {
        _messages = messages;
        _log = log;
    }
    
    public void Run(
        string[] args) {
        
        _settings = _ExtractSettings(args);
        
        string message = _messages.Greeting(_settings.language);
        
        Console.WriteLine(message);
    }
    
    private Settings _ExtractSettings(
        string[] args) {
        Settings settings = new Settings(Language.English);
        
        for (int i = 0; i < args.Length; i++) {
            string langArg = ((DescriptionAttribute[])argsTypes.Language.GetType().GetField(argsTypes.Language.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
            
            if (args[i].StartsWith(langArg.ToString())) {
                string lang = args[i].Substring(langArg.Length);

                switch (lang)
                {
                    case "en":
                        settings = new Settings(Language.English);
                        break;
                    case "es":
                        settings = new Settings(Language.Spanish);
                        break;
                    case "fr":
                        settings = new Settings(Language.French);
                        break;
                }
                break;
            }
        }

        return settings;
    }
    
    private struct Settings
    {
        public Language language;

        public Settings(Language language)
        {
            this.language = language;
        }
    }

    private enum argsTypes
    {
        [Description("lang=")]
        Language
    }
}