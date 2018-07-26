using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Simulator
{
    public class Program
    {
        enum FacingDirection
        {
            NORTH,
            SOUTH,
            EAST,
            WEST,
            UNKNOWN
        }
        class Position
        {
            int x;
            int y;
            FacingDirection F;
            public void SetPosition(int x1,int y1,string f1)
            {
                if (x1 >= 0 && x1 < 5 && y1 >= 0 && y1 < 5 && MapDirection(f1) != FacingDirection.UNKNOWN)
                {
                    x = x1;
                    y = y1;
                    F = MapDirection(f1);
                }
            }
            public void TurnLeft()
            {
                switch (F)
                {
                    case FacingDirection.NORTH: F = FacingDirection.WEST;break;
                    case FacingDirection.SOUTH: F = FacingDirection.EAST; break;
                    case FacingDirection.EAST: F = FacingDirection.NORTH; break;
                    case FacingDirection.WEST: F = FacingDirection.SOUTH; break;
                }
            }
            public void TurnRight()
            {
                switch (F)
                {
                    case FacingDirection.WEST: F = FacingDirection.NORTH; break;
                    case FacingDirection.EAST: F = FacingDirection.SOUTH; break;
                    case FacingDirection.NORTH: F = FacingDirection.EAST; break;
                    case FacingDirection.SOUTH: F = FacingDirection.WEST; break;
                }
            }
            public void Move()
            {
                switch (F)
                {
                    case FacingDirection.NORTH: if(y + 1 < 5) y += 1; break;
                    case FacingDirection.SOUTH: if(y - 1 >= 0) y -= 1; break;
                    case FacingDirection.EAST: if (x + 1 < 5) x += 1; break;
                    case FacingDirection.WEST: if (x - 1 >= 0) x -= 1; break;
                }
            }
            public string Report()
            {
                return string.Format("{0},{1}," + DisplayDirection(F),x,y);
            }

            private string DisplayDirection(FacingDirection f)
            {
                switch (f)
                {
                    case FacingDirection.NORTH: return "NORTH";
                    case FacingDirection.SOUTH: return "SOUTH";
                    case FacingDirection.EAST: return "EAST";
                    case FacingDirection.WEST: return "WEST";

                }
                return "UNKNOWN";
            }

            private FacingDirection MapDirection(string f1)
            {
                switch (f1)
                {
                    case "NORTH": return FacingDirection.NORTH;
                    case "SOUTH": return FacingDirection.SOUTH;
                    case "EAST": return FacingDirection.EAST;
                    case "WEST": return FacingDirection.WEST;
                }
                return FacingDirection.UNKNOWN;
            }
        }
        public string Execute(string filename)
        {

            string[] lines = System.IO.File.ReadAllLines(filename);
            Position p = new Position();
          
            foreach (string line in lines)
            {
                string[] tokens = line.Split(new char[] { ',', ' ' });
                   switch(tokens[0])
                {
                    case "PLACE":
                        p.SetPosition(Int32.Parse(tokens[1]), Int32.Parse(tokens[2]), tokens[3]);
                        break;
                    case "LEFT":
                        p.TurnLeft();
                        break;
                    case "RIGHT":
                        p.TurnRight();
                        break;
                    case "MOVE":
                        p.Move();
                        break;
                    case "REPORT":
                        p.Report();
                        break;
                }
               
            }

            
           return p.Report();


        }
    }
}
