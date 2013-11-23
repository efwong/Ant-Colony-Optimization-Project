Ant-Colony-Optimization-Project
===============================
Built using C#

Follows ant colony optimization's basic principles as shown in:
  http://en.wikipedia.org/wiki/Ant_colony_optimization_algorithms
  
Independent agents called 'ants' iterate through the placed cities.
Cities are nodes connected by edges.
For good cities, ants place pheromones on that edge to make
it more favorable as a positive control.  Likewise, longer edges are
less favorable.  The least travelled path would have the least
quantity of pheromones; thus ants would gradually avoid that edge.



KEY
------------------------------------------------------------------
Alpha: the weight of the pheremone, should be left at 1

Beta: the weight of the distance, should be left at 1

Rho: pheromone decay rate:  0<ρ<1

Number of Cities: to be placed on the grid

Number of Ants: to be utilized by algorithm

Number of Iterations: with more iterations, the algorithm will be more accurate

ACO = ant colony optimization

Brute Force = permutations to solve TSP

The Bar on the bottom right corner is the progress bar.


Buttons (note always specify properties before clicking any buttons):
-------------------------------------
Auto-Random Cities: Will randomly populate cities based on above properties
Place Cities: Will allow you to click to place up to the # of cities specified
              in the above properties
Clear: clear the screen and resets the property

Ant Colony Optimization: runs the ACO algorithm (must only be clicked after the 
            random or place city button)

Brute Force: runs permutations (must only be clicked after placing cities)


