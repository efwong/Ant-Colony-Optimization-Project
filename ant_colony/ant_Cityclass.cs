/*****************************************************************************
 * Ant Colony Optimization Class Definitions
 *
 * Edwin Wong, 5/31/11
 * 
 * 
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ant_colony
{
    public class Ant
    {//ant class only contains the index to the city--use city class to get the 2D location
        private int currentLocation;
        private int nextLocation;
        public int tour_number;
        public List<int> haveBeenList;//where ant has been (Tabu)
        public List<int> tourList;//total itinerary
        public double distanceTraveled;
        

        public Ant()
        {
            currentLocation = 0;
            nextLocation = 0;
            tour_number = 0;
            haveBeenList = new List<int>();
            tourList = new List<int>();
            distanceTraveled = 0;
        }
        //construct ants with starting position and number of cities for tabu & tour list
        public Ant(int startPos, int num_cities)
        {
            currentLocation = startPos;
            nextLocation = 0;
            tour_number = 0;
            haveBeenList = new List<int>();
            tourList = new List<int>();
            distanceTraveled = 0;
            for (int k = 0; k < num_cities; k++)
            {
                haveBeenList.Add(0);//0 if ant hasnt been to city, 1 if it has
                tourList.Add(0);
            }
        }
        //update total distance traveled
        public void update_total_distance(double distance)
        {
            distanceTraveled += distance;
        }
        
        public float distanceFrom(PointF a, PointF b)
        {
            return (float)Math.Pow((Math.Pow(a.X - b.X, 2F) + Math.Pow(a.Y - b.Y, 2F)), .5F);
        }
        //set ants current location
        public void set_current_location(int location)
        {
            currentLocation = location;
        }
        //set ants next location
        public void set_next_location(int next)
        {
            nextLocation = next;
        }
        //get ants current location
        public int get_current_location()
        {
            return currentLocation;
        }
        public double getDistance()
        {
            return distanceTraveled;
        }

        public void resetDistance()
        {
            distanceTraveled = 0;
        }

    }
    //city class
    public class City
    {
        Point location; //the city's location in x,y coordinate

        public City()
        {
            location = new Point(0, 0);
        }

        public City(Point p)
        {
            location = p;
        }
        public void set_location(int x, int y)
        {
            location.X = x;
            location.Y = y;
        }

        public void Draw(Graphics g) //draw circle representing city location
        {
            g.FillEllipse(new SolidBrush(Color.Blue), location.X - 20 / 2, location.Y - 20 / 2, 20, 20);
        }

        public Point getLocation()
        {
            return location;
        }
    }

}