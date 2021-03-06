﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Commands
{
    
    public class CommandHandler
    {

        List<Command> commands;
        public CommandHandler () {
            this.commands = new List<Command>();
            this.commands.Add(new Beep("beep"));
            this.commands.Add(new ComputerName("name"));

        }

        public string RunCommand(string cmd)
        {

            string[] sp = cmd.Split(' ');
            string name = sp.First();
            string[] args = sp.Skip(1).ToArray();

            foreach (Command c in this.commands)
                if (c.name.ToLower() == name) 
                    return c.execute(args);

            return "Command " + cmd + " does not exist";

        }



    }
}
