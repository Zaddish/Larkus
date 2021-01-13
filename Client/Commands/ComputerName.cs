using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using Microsoft.Win32;



namespace Client.Commands
{
    public class ComputerName : Command
    {

        public ComputerName(String name) : base(name) { }


        public override string execute(string[] args)
        {
            if (args.Length != 0) return "Invalid arguments for ComputerName, expected 0"; {
                return Environment.UserName;
            }
            return "";

        }

    }
}