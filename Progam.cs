using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.controllers;

namespace TaskManagerConsole
{
    public class Progam
    {
        public async static Task  Main(string[] args)
        {
         await ProductController.Init();
        }
        
    }
}
