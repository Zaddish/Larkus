using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Commands
{
    public class Beep : Command  {

        public Beep (String name) : base(name) { }

        public override string execute(string[] args)
        {

            if (args.Length==0) { Console.Beep();
                return "Server sent beep";

            }
            else 
            if (args.Length==1) {

                int i = 0;
                
                while (i != Int32.Parse(args.First())) {
                    Console.Beep();
                    ++i;
                }
                return "";
            }
            
            else
                return "Invalid arguments for beep. Requires either 0 or 1 arguments.";


        }
        

    }
}
