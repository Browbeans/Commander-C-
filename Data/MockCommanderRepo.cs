using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> 
            {
                new Command{Id = 0, HowTO="Boil an egg", Line="Boil water", Platform="Kettle and pan"}, 
                new Command{Id = 1, HowTO="Cut Bread", Line="Get a knife", Platform="Choppingboard and knife"}, 
                new Command{Id = 2, HowTO="Make tea", Line="Place teabag", Platform="Kettle and teabag"} 
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTO="Boil an egg", Line="Boil water", Platform="Kettle and pan"};  
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}