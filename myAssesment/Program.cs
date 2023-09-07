using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAssesment
{
    class Program
    {
        public static List<Rover> rovers;
        public static char[] directions = new char[] { 'N', 'W', 'E', 'S' };
        static void Main(string[] args)
        {

            try
            {
                rovers = new List<Rover>();

                // take plateau values
                Console.WriteLine("enter plateau width and height separated with space,ex(3 3) :");
                string[] plateauValues = Console.ReadLine().Split(' ');
                Plateau plateau = new Plateau(int.Parse(plateauValues[0]), int.Parse(plateauValues[1]));
                // take plateau values

                // number of rovers
                Console.WriteLine("how many rovers you would like to test");
                int n = int.Parse(Console.ReadLine());
                // number of rovers

                for (int i = 1; i <= n; i++)
                {
                    // take initial position and direction for rover
                    Console.WriteLine($"enter rover{i} landing value separated with space(position should be in range of plateau( (0,0) to ({plateau.width},{plateau.height}))): x,y,direction(First Letter(N|S|W|E)),ex(4 4 N or 4 5 W ):");
                    string[] landingValues = Console.ReadLine().Split(' ');
                   
                    // some validation for the inputs 
                    if (landingValues.Length==3)
                    {
                        // check value of directions
                        if (!directions.Contains(char.Parse(landingValues[2])))
                        {
                            Console.WriteLine("enter direction correctly");
                            break;
                        }
                        if (int.Parse(landingValues[0]) > plateau.width || int.Parse(landingValues[1]) > plateau.height)
                        {
                            Console.WriteLine("enter values in range of plateau");
                            break;
                        }
                    }else
                    {
                            Console.WriteLine("enter values correctly");
                            break;
                    }
                    // some validation for the inputs 

                    Rover rover = new Rover(int.Parse(landingValues[0]), int.Parse(landingValues[1]), char.Parse(landingValues[2]), plateau);
                    // take initial position and direction for rover


                    // take instructions and split to chars
                    Console.WriteLine($"write instruction for rover{i} to move or change directions(M for move,R,L to change direction),ex(MMRRLLEM):");
                    char[] instructionsArray = Console.ReadLine().ToCharArray();

                    // execute rover
                    ExecuteInstructions(rover, instructionsArray);
                }

                // print rover position after movement
                foreach (Rover rover in rovers)
                {
                    Console.WriteLine(rover.RoverInfo());
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("enter the informations like the examples!!!!!!!! ");
                Console.WriteLine("message"+ex.Message);
                Console.ReadLine();
            }



        }
        // method to execute the instructions
        public static void ExecuteInstructions(Rover rover, Array instructions)
        {
            Rover newRover = rover;

            foreach (char instruction in instructions)
            {
                if (instruction == 'M')
                {
                    newRover.MoveRoverTo();
                }
                else if (instruction == 'L')
                {
                    newRover.GoToLeft();
                }
                else if(instruction =='R')
                {
                    newRover.GoToRight();
                }
            }
            rovers.Add(newRover);
        }
    }
}
