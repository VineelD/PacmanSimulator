using Pacman_Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman_Simulator_Test
{
    [TestClass]
    public class Simulator_Test
    {
        
        [TestMethod]
        [DataRow(@"Pacman_Input1.txt", "0,1,NORTH")]
        [DataRow(@"Pacman_Input2.txt", "0,0,WEST")]
        [DataRow(@"Pacman_Input3.txt", "3,3,NORTH")]
        public void Execute_PacmanSimulator(string filename,string result)
        {
            Program p = new Program();
            Assert.AreEqual(result, p.Execute(filename));
        }
    }
}
