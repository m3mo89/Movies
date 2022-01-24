using System;
namespace Movies.CommandImplementation
{
    public class Invoker
    {
        private ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            _command.Execute();
        }
    }
}
