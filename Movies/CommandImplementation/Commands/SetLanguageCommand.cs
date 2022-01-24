using System;
namespace Movies.CommandImplementation.Commands
{
    public class SetLanguageCommand : ICommand
    {
        private ILanguageReceiver _languageReceiver;
        public SetLanguageCommand(ILanguageReceiver languageReceiver)
        {
            _languageReceiver = languageReceiver;
        }

        public void Execute()
        {
            _languageReceiver.SetLanguage();
        }
    }
}