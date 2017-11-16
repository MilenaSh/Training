using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        var slowDownDistance = 1200;
        var stopDistance = 0;
        var readyToBoost = false;
        var count = 0;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
            int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
            int nextCheckpointDist = int.Parse(inputs[4]); // distance to the next checkpoint
            int nextCheckpointAngle = int.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
            inputs = Console.ReadLine().Split(' ');
            int opponentX = int.Parse(inputs[6]);
            int opponentY = int.Parse(inputs[7]);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            string thrust = "100";

            var ratio = (nextCheckpointDist - slowDownDistance + stopDistance) / slowDownDistance;


            if ((nextCheckpointAngle > 90 || nextCheckpointAngle < -90) || nextCheckpointDist < 200)
            {
                thrust = "0";
            }

            var dist = ((x - opponentX) ^ 2 + (y - opponentY) ^ 2) ^ (1 / 2);
            if (dist <= 400)
            {
                thrust = "SHIELD";
                readyToBoost = true;
            }

            if (readyToBoost)
            {
                thrust = "BOOST";
                readyToBoost = false;
            }

            //   if (ratio <= 1 && stopDistance >= nextCheckpointDist)
            //   {
            //       thrust = ((int)(100.00 * ratio) + 40).ToString();
            //   }       


            // You have to output the target position
            // followed by the power (0 <= thrust <= 100)
            // i.e.: "x y thrust"
            Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + thrust);
        }
    }
}