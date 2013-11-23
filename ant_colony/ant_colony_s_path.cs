/*****************************************************************************
 * Ant Colony Optimization (Ant System)
 * Uses the Ant System algorithm to solve the Traveling Salesman Problem
 * 
 * Edwin Wong, 5/31/11
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ant_colony
{
    public partial class ant_colony_s_path : Form
    {
        public Bitmap myCanvas;
        private List<Ant> ant_list;
        private List<City> city_list;
        private List<int> best_tour_list;
        private List<int> brute_force_list;
        private List<int> brute_forceTmpList;
        private double best_tour_length = -1;
        private double brute_force_length = -1;
        private double[,] distances;
        private double[,] pheromones;
        private int counter = 0;
        private int num_cities = 10;
        private int num_ants = 30;
        private int pherom_const = 100;
        private double ALPHA = 1.0;//weight of pheromone
        private double BETA = 1.0;//weight of distance
        private double RHO = .5;//decay rate
        private int iterations = 100;
        private int click_counter = 0;
        private bool random_cities = false;
        private bool choose_cities = false;
        private Stopwatch bruteWatch = new Stopwatch();
        private Stopwatch acoWatch = new Stopwatch();

        private Random rand_gen = new Random();
        public DoubleBufferPanel DrawingPanel = new DoubleBufferPanel();
        public ant_colony_s_path()
        {
            InitializeComponent();
            DrawingPanel.Size = new System.Drawing.Size(400, 400);
            DrawingPanel.Location = new System.Drawing.Point(12, 12);
            DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            DrawingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseClick);
            DrawingPanel.Parent = this;
            this.Controls.Add(DrawingPanel);
        }

        private void ant_colony_s_path_Load(object sender, EventArgs e)
        {
            myCanvas = new Bitmap(DrawingPanel.Width, DrawingPanel.Height,
               System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.White);
            num_cities = int.Parse(number_Cities_Box.Text);
            num_ants = int.Parse(number_Ants_Box.Text);
            city_list = new List<City>();
            ant_list = new List<Ant>();
            best_tour_list = new List<int>();
        }
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(myCanvas, 0, 0, myCanvas.Width, myCanvas.Height);
        }

        /******************************************************************
         * Draw_button_Click: initiate ant colony method
         ******************************************************************/
        private void Draw_button_Click(object sender, EventArgs e)
        {
            if (click_counter == int.Parse(number_Cities_Box.Text) && !backgroundWorker1.IsBusy)
            {
                acoWatch.Start();
                choose_cities = false;
                random_cities = false;
                Graphics g = Graphics.FromImage(myCanvas);
                initAnts();

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }

        }


        /******************************************************************
         * DrawingPanel_MouseClick: click generates city
         ******************************************************************/
        private void DrawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);
            num_cities = int.Parse(number_Cities_Box.Text);
            if (choose_cities == true && click_counter < num_cities)
            {
                City myCity = new City(e.Location);
                myCity.Draw(g);
                city_list.Add(myCity);
                click_counter++;
            }
            if (choose_cities == true && click_counter == num_cities)
            {
                initialize_AntColony(g);
            }
            DrawingPanel.Invalidate();

        }

        /******************************************************************
         * random_cities_button_Click: user wants to get random cities
         ******************************************************************/
        private void random_cities_button_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.White);
            random_cities = true;
            initialize_AntColony(g);
            DrawingPanel.Invalidate();
        }

        /******************************************************************
         * define_cities_Button_Click: user wants to click/select cities
         ******************************************************************/
        private void define_cities_Button_Click(object sender, EventArgs e)
        {
            num_cities = int.Parse(number_Cities_Box.Text);
            choose_cities = true;
            random_cities = false;
        }


        /********************************************************************
         * initialize_AntColony: intialize values for ant colony
         ********************************************************************/
        private void initialize_AntColony(Graphics g)
        {
            ant_list = new List<Ant>();
            best_tour_list = new List<int>();
            best_tour_length = -1;
            num_cities = int.Parse(number_Cities_Box.Text);
            num_ants = int.Parse(number_Ants_Box.Text);
            distances = new double[num_cities, num_cities];
            pheromones = new double[num_cities, num_cities];
            initCities(g);
            initAnts();
            initPherom();
        }
        /********************************************************************
         * initAnts: add ants to random starting position
         ********************************************************************/
        private void initAnts()
        {
            int rand_city = 0;
            ant_list.Clear();
            num_ants = int.Parse(number_Ants_Box.Text);
            for (int i = 0; i < num_ants; i++)
            {
                rand_city = rand_gen.Next(0, num_cities);
                ant_list.Add(new Ant(rand_city, num_cities));//random start location
                ant_list[i].tourList[0] = ant_list[i].get_current_location();//set tour's first position as current location
                ant_list[i].haveBeenList[ant_list[i].get_current_location()] = 1;//set to 1 to designate that we went to this city
                ant_list[i].tour_number = 1;
            }
        }
        /********************************************************************
         * initCities: add cities with random staring positions
         *             //can be changed to allow user input
         ********************************************************************/
        private void initCities(Graphics g)
        {
            int rand_city_x = 0;
            int rand_city_y = 0;


            distances = new double[num_cities, num_cities];
            //initialize cities to random positions
            if (random_cities == true)
            {
                city_list = new List<City>();
                click_counter = num_cities;
                for (int i = 0; i < num_cities; i++)
                {
                    rand_city_x = rand_gen.Next(30, myCanvas.Width - 30);
                    rand_city_y = rand_gen.Next(30, myCanvas.Height - 30);
                    city_list.Add(new City(new Point(rand_city_x, rand_city_y)));
                    city_list[i].Draw(g);
                }
            }

            //compute city distances
            //(n^2-n)/2 == number of connections btwn cities
            for (int i = 0; i < num_cities; i++)
                for (int k = 0; k < num_cities; k++)
                {
                    double x = Math.Pow((double)city_list[i].getLocation().X -
                        (double)city_list[k].getLocation().X, 2.0);
                    double y = Math.Pow((double)city_list[i].getLocation().Y -
                        (double)city_list[k].getLocation().Y, 2.0);
                    distances[i, k] = Math.Sqrt(x + y);
                }

        }
        /**************************************************************************
         * initPherom: initialize pheromone levels btwn cities to  a small constant
         ***************************************************************************/
        private void initPherom()
        {
            for (int from = 0; from < num_cities; from++)
            {
                for (int to = 0; to < num_cities; to++)
                {//initialize all pheromone btwn cities as a small constant
                    pheromones[from, to] = 1.0 / (double)num_cities;
                    pheromones[to, from] = 1.0 / (double)num_cities;
                }
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Calculate();
        }

        /***********************************************************************
         * backgroundWorker1_RunWorkerCompleted: draw solution based on ACO
         ***********************************************************************/
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.White);
            Best_Tour_Box.Text = Math.Round(best_tour_length, 2).ToString();

            //draw cities
            for (int i = 0; i < num_cities; i++)
            {
                city_list[i].Draw(g);
            }
            //draw solutions
            for (int i = 0; i < best_tour_list.Count; i++)
            {
                g.DrawLine(new Pen(Color.Black, 5), city_list[best_tour_list[i]].getLocation(),
                    city_list[best_tour_list[(i + 1) % num_cities]].getLocation());//loop back to last point

                if (i == best_tour_list.Count - 1)
                {
                    best_tour_length = -1;
                    best_tour_list.Clear();
                }
            }
            DrawingPanel.Invalidate();
            acoWatch.Stop();
            totalTimeACO.Text = acoWatch.Elapsed.TotalSeconds.ToString();
            acoWatch.Reset();
        }


        /***********************************************************************
         * Calculate: main function that calculates ant movement, 
         *          evaporation and increment of pheromones
         ***********************************************************************/
        private void Calculate()
        {
            ALPHA = double.Parse(alpha_Box.Text);
            BETA = double.Parse(beta_Box.Text);
            RHO = double.Parse(rho_Box.Text);
            iterations = int.Parse(iterationBox.Text);
            for (int k = 0; k < iterations; k++)
            {
                for (int i = 0; i < num_cities; i++)//move ants till they reach the end
                    if (ants_stop()) //moves ants 1 step & check if all ants finished moving?
                    {
                        evaporatePheromones();
                        updatePheromones();
                        best_tour();//go through every ant and check if it has optimal solution
                        initAnts(); // reset ant position and tour
                    }
            }
        }


        /********************************************************************************************
         * goToNextCity: picks next city based on the attractiveness of the path(the pheromones)
         *              and its visibility (the distance)
         *********************************************************************************************/
        private void goToNextCity(Ant current_ant)
        {
            double sum_prob = 0;//denominator in probability function
            double move_prob = 0;//numerator in probability function
            int current_city = current_ant.get_current_location();
            for (int i = 0; i < num_cities; i++)//loop through all cities
            {
                if (current_ant.haveBeenList[i] == 0)
                {
                    sum_prob += Math.Pow(pheromones[current_city, i], ALPHA) *
                        Math.Pow(1.0 / distances[current_city, i], BETA);
                }
            }

            int destination_city = 0;
            double rand_move = 0;
            int count = 0;
            //loops until ant chooses a city
            while (count < 400)//400 is the threshold for loops
            {
                if (current_ant.haveBeenList[destination_city] == 0)//ant hasnt been to  this city
                {//calculate probability of movement
                    move_prob = (Math.Pow(pheromones[current_city, destination_city], ALPHA) *
                        Math.Pow(1.0 / distances[current_city, destination_city], BETA)) / sum_prob;
                    rand_move = rand_gen.NextDouble();
                    if (rand_move < move_prob) break;//break loop if ant moves to city
                }
                destination_city++;
                if (destination_city >= num_cities) destination_city = 0;//reset city count
                count++;
            }
            //update next location and tour itinerary
            current_ant.set_next_location(destination_city);//going to that city
            current_ant.haveBeenList[destination_city] = 1;//moved to that city
            current_ant.tourList[current_ant.tour_number] = destination_city;
            current_ant.tour_number++;
            //add to current distance
            current_ant.update_total_distance(distances[current_ant.get_current_location(), destination_city]);

            //if the ant reached the end, add up the distance for return path
            if (current_ant.tour_number == num_cities)
            {
                current_ant.update_total_distance(
                    distances[current_ant.tourList[num_cities - 1], current_ant.tourList[0]]);
            }

            current_ant.set_current_location(destination_city);//update current city to next city
        }


        /************************************************************************************
         * ants_stop: checks if all the ants have finished moving/reached final destination
         ************************************************************************************/
        private bool ants_stop()
        {
            int moved = 0;
            for (int i = 0; i < num_ants; i++)
            {
                if (ant_list[i].tour_number < num_cities)
                {//ants are still in moving
                    goToNextCity(ant_list[i]);
                    moved++;
                }
            }
            if (moved == 0)
            {
                return true;//ants have finished moving
            }
            else return false;
        }

        /************************************************************************************
         * evaporatePheromones: decreases current pheromones by a factor of (1.0-RHO) so
         *                   larger values of pheromones would decrease at a higher rate,
         *                   but this is good, since we want the ants to explore more
         ************************************************************************************/
        public void evaporatePheromones()
        {
            //handles both cases of [i,k] and [k,i] so dont need to code pheromones 2x
            for (int i = 0; i < num_cities; i++)
                for (int k = 0; k < num_cities; k++)
                {
                    pheromones[i, k] *= (1.0 - RHO);
                    //pheromone levels should always be at base levels
                    if (pheromones[i, k] < 1.0 / (double)num_cities)
                    {
                        pheromones[i, k] = 1.0 / (double)num_cities;
                    }
                }
        }



        /************************************************************************************
         * updatePheromones: update pheromones along all edges after each ant has completed
         *                  its tour
         ************************************************************************************/
        private void updatePheromones()
        {
            for (int i = 0; i < num_ants; i++)
            {
                for (int k = 0; k < num_cities; k++)
                {
                    int from = ant_list[i].tourList[k];//starting point of edge
                    //if city+1=num_cities, then city is last city and then destination is the starting city
                    int to = ant_list[i].tourList[((k + 1) % num_cities)];//endpoint of edge
                    pheromones[from, to] += (double)pherom_const / ant_list[i].getDistance();
                    pheromones[to, from] = pheromones[from, to];

                }
            }
        }
        /*****************************************************************************
         * best_tour: updates global tour length with shortest tour length
         *****************************************************************************/
        private void best_tour()
        {
            double best_local_tour = ant_list[0].getDistance();
            int save_index = 0;
            for (int i = 1; i < ant_list.Count; i++)//checks the best tour length among this iteration
            {
                if (ant_list[i].getDistance() < best_local_tour)
                {
                    best_local_tour = ant_list[i].getDistance();
                    save_index = i;
                }
            }
            //compare best local length with global length and update accordingly
            if (best_local_tour < best_tour_length || best_tour_length == -1)
            {
                best_tour_list = ant_list[save_index].tourList;
                best_tour_length = best_local_tour;
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.White);
            Best_Tour_Box.Text = "0";
            totalTimeACO.Text = "0";
            totalTimeBrute.Text = "0";
            brute_length_label.Text = "0";
            ant_list.Clear();
            city_list.Clear();
            click_counter = 0;
            best_tour_length = -1;
            random_cities = false;
            best_tour_list.Clear();
            pheromones = new double[num_cities, num_cities];
            distances = new double[num_cities, num_cities];
            DrawingPanel.Invalidate();
        }

        /**********************************************************************************
         * permute: generate all permutations of List v
         **********************************************************************************/
        private void permute(int total,List<int> v, int start, int n)
        {
            int percentProgress = (int)(100.0 * ((float)(counter+1) / (float)total));
            if( percentProgress %5 ==0)
                backgroundWorker2.ReportProgress(percentProgress);


            if (start == n - 1)
            {
                double local_length = 0;
                counter++;
                for (int i = 0; i < v.Count; i++)
                {
                    local_length += Math.Sqrt(Math.Pow(city_list[v[i]].getLocation().X - city_list[v[(i + 1) % num_cities]].getLocation().X, 2.0) +
                        Math.Pow(city_list[v[i]].getLocation().Y - city_list[v[(i + 1) % num_cities]].getLocation().Y, 2.0));
                }
                if (local_length < brute_force_length || brute_force_length == -1)
                {
                    brute_force_length = local_length;
                    brute_forceTmpList.Clear();
                    for (int i = 0; i < v.Count; i++)
                    {
                        brute_forceTmpList.Add(v[i]);
                    }
                }
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    int tmp = v[i];

                    v[i] = v[start];
                    v[start] = tmp;
                    permute(total,v, start + 1, n);
                    v[start] = v[i];
                    v[i] = tmp;
                }
            }
        }
        //recursion for n!
        public int fact(int n)
        {
            if (n == 0) return 1;
            else return n * fact(n - 1);
        }

        /**********************************************************************************
         * brute_force_button_Click: initiate brute force function
         **********************************************************************************/
        private void brute_force_button_Click(object sender, EventArgs e)
        {
            counter = 0;
            int temp_city;
            string s = number_Cities_Box.Text;
            bool result = int.TryParse(s, out temp_city);
            if (result && city_list.Count != 0 && !backgroundWorker2.IsBusy)
            {
                Graphics g = Graphics.FromImage(myCanvas);
                num_cities = int.Parse(number_Cities_Box.Text);
                brute_force_list = new List<int>();
                brute_forceTmpList = new List<int>();
                for (int i = 0; i < num_cities; i++)
                {
                    brute_force_list.Add(i);
                }
                backgroundWorker2.RunWorkerAsync();
            }
        }

        /**********************************************************************************
         * backgroundWorker2_DoWork: draw brute force solution
         **********************************************************************************/
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            bruteWatch.Start();
            int total = fact(num_cities);
            permute(total,brute_force_list, 0, num_cities);
        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        /**********************************************************************************
         * backgroundWorker2_RunWorkerCompleted: draw brute force solution
         **********************************************************************************/
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);

            for (int i = 0; i < brute_forceTmpList.Count; i++)
            {
                g.DrawLine(new Pen(Color.Red), city_list[brute_forceTmpList[i]].getLocation(),
                    city_list[brute_forceTmpList[(i + 1) % num_cities]].getLocation());
            }
            brute_length_label.Text = Math.Round(brute_force_length, 2).ToString();
            bruteWatch.Stop();
            totalTimeBrute.Text = bruteWatch.Elapsed.TotalSeconds.ToString();
            bruteWatch.Reset();
            brute_force_length = -1;
            brute_forceTmpList.Clear();
            DrawingPanel.Invalidate();
        }



    }


    /**********************************************************************************
    * DoubleBufferPanel: a child class of the Systems.Windows.Forms.Panel
    *                    Allows double buffering
    * ********************************************************************************/
    public class DoubleBufferPanel : Panel
    {

        public DoubleBufferPanel()
        {
            // Set the value of the double-buffering style bits to true.
            // ControlStyles.UserPaint -- allows user to control painting w/o passing off the work to the operating system
            //ControlStyles.AllPaintingInWmPaint--optimize to reduce flicker but only use it if ControlStyles.UserPaint is true
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint, true);// | evaluates all conditions even if condition 1 is true
            this.UpdateStyles();//forces style to be applied
        }

    }
}