using System;
using NUnit.Framework;

namespace CustomProgram
{
    [TestFixture]
    public class Testing
    {
        //This test is to verify that the grow method is working when the player has enough points
        [Test]
        public void TestGrow()
        {
            //Setup
            //Creates a new player object
            Player p = new Player();
            //Execute
            //Adds 1000 points to the player to test if the player grows
            p.Points += 1000;
            p.Grow();
            //Check
            //The player should remain in its current size of small
            Assert.AreEqual(Size.Small, p.Size);

            //Execute
            //Adds 6000 points to the player to test if the player grows
            p.Points += 6000;
            p.Grow();
            //Check
            //Since medium requires 1200 points and large requires 6000, the player's size should become large as they possess 7000 points
            Assert.AreEqual(Size.Large, p.Size);
        }

        //This test is used to verify that if the player has 12000 points or more, they will win the game
        [Test]
        public void TestWin()
        {
            //Setup
            //Creates a new player object
            Player p = new Player();
            //Execute
            //Adds 1000 points to the player 
            p.Points += 1000;
            //Check
            //The player is still well below 12000 points and thus should return false
            Assert.AreEqual(false, p.CheckWin());

            //Execute
            //Adds 13000 points to the player
            p.Points += 13000;
            //Check
            //The player is well above the 12000 points required to win and thus should return true
            Assert.AreEqual(true, p.CheckWin());
        }

        //This test is to verify whether the shark is able to eat the player 
        [Test]
        public void TestSharkEatPlayer()
        {
            //Setup
            //Initializes a player and shark object
            Player p = new Player();
            Shark s = new Shark(Size.Shark, 0, p);
            //Execute
            //The position of the shark and players are put far apart
            p.X = 100;
            p.Y = 100;
            s.XPosition = 500;
            s.YPosition = 500;
            //Check
            //As there is no overlap between the two objects, the shark should return an outcome of nothing when executing the eat player method
            Assert.AreEqual(Outcome.Nothing, s.EatPlayer());

            //Execute
            //The position of the player is moved to be where the shark is
            p.X = 500;
            p.Y = 500;
            //Check
            //As the position of the player and shark are overlapping, the shark should return an outcome of eat to signify that the player has been eaten
            Assert.AreEqual(Outcome.Eat, s.EatPlayer());
        }

        //This test is to verify whether the fish can eat eachother
        [Test]
        public void TestFishEatFish()
        {
            //Setup
            //Intializes a player object as well as a medium sized fish and a large sized fish
            Player p = new Player();
            MediumFish m = new MediumFish(Size.Medium, 150, p);
            LargeFish l = new LargeFish(Size.Large, 250, p);

            //Execute
            //Sets the position of the fishes to be far apart
            m.XPosition = 200;
            m.YPosition = 200;
            l.XPosition = 500;
            l.YPosition = 500;
            //Check
            //Since none of the fishes are close to each other, both methods shuld return false
            Assert.AreEqual(false, m.EatFish(l));
            Assert.AreEqual(false, l.EatFish(m));

            //Execute
            //The medium fish is moved to overlap with the large fish
            m.XPosition = 490;
            m.YPosition = 490;
            //Check
            //Since the size of the large fish is not small, the medium fish should not be able to eat the large fish and return false
            Assert.AreEqual(false, m.EatFish(l));
            //Since the large fish has a greater size than the medium fish, the large fish should be able to eat the medium fish and return true
            Assert.AreEqual(true, l.EatFish(m));
        }

        //This test is to see whether the fishes are added correctly to the environment's list of fishes
        [Test]
        public void TestAddFish()
        {
            //Setup
            //Create a player, small fish, large fish and an environment object
            Player p = new Player();
            SmallFish s = new SmallFish(Size.Medium, 150, p);
            LargeFish l = new LargeFish(Size.Large, 450, p);
            Environment e = new Environment(Difficulty.Easy);

            //Execute
            //Add the fishes to the list of fishes in the environment object
            e.AddFish(s);
            e.AddFish(l);

            //Check
            //Check to see if the number of fishes added to the environment's fish list is equal to 2
            Assert.AreEqual(2, e.Fish.Count());
        }

        //This test verifies the method of the player being able to eat a fish if the size is the same or greater
        [Test]
        public void TestPlayerEatFish()
        {
            //Setup
            //Create a player object as well as a medium fish and large fish object
            Player p = new Player();
            MediumFish m = new MediumFish(Size.Medium, 150, p);
            LargeFish l = new LargeFish(Size.Large, 250, p);

            //Execute
            //See the position of the player and medium fish to be the same while keeping the large fish far apart
            p.X = 100;
            p.Y = 100;
            m.XPosition = 100;
            m.YPosition = 100;
            l.XPosition = 500;
            l.YPosition = 500;
            p.Grow();
            //Check
            //Since the player is smaller than the medium fish, it should return an outcome of Eat to signify that it eats the player
            Assert.AreEqual(Outcome.Eat, m.EatPlayer());
            //Since the player and large fish do not intercept, it should return an outcome of nothing
            Assert.AreEqual(Outcome.Nothing, l.EatPlayer());

            //Execute
            //Points are added to the player and calls on the Grow method
            //to increase the size of the player to medium as well as sets the large fish to be the same position as the player
            p.Points += 4000;
            p.Grow();
            m.XPosition = 100;
            m.YPosition = 100;
            l.XPosition = 100;
            l.YPosition = 100;
            //Check
            //Since the size of the player is equal to the medium fish, the player should be able to eat the medium fish. 
            //The EatPlyaer will return an outcome of Eaten
            Assert.AreEqual(Outcome.Eaten, m.EatPlayer());
            //Since the size of the player is smaller than the large fish, the player will get eaten and the EatPlayer method returns false
            Assert.AreEqual(Outcome.Eat, l.EatPlayer());
        }

        //This test verifies that if the player is eaten, it would lose a life and be resetted
        [Test]
        public void TestPlayerLoseLife()
        {
            //Setup
            //Creates an object and a large fish object
            Player p = new Player();
            LargeFish l = new LargeFish(Size.Large, 250, p);

            //Execute
            //The position of the fish are kept far apart and looks at whether the large fish can eat 
            //the player and reset its position and reduce its life if the player is eaten
            p.X = 100;
            p.Y = 100;
            l.XPosition = 500;
            l.YPosition = 500;
            if (l.EatPlayer() == Outcome.Eat)
            {
                p.Reset();
            }
            //Check
            //This test looks at whether the lives of the player is still at 3 
            Assert.AreEqual(3, p.Lives);

            //Execute
            //The large fish is then moved to the location of the player and looks at whether it can eat
            //the player and reset its position as it is able to
            l.XPosition = 100;
            l.YPosition = 100;
            if (l.EatPlayer() == Outcome.Eat)
            {
                p.Reset();
            }
            //Check
            //As the reset method has been called, the player's number of lives should decrease by 1
            Assert.AreEqual(2, p.Lives);
        }

        //This method tests to see if the player get points when eating a fish
        [Test]
        public void TestPlayerEarnPoints()
        {
            //Setup
            //Creates a player object, medium fish object and a large fish object
            Player p = new Player();
            MediumFish m = new MediumFish(Size.Medium, 150, p);
            LargeFish l = new LargeFish(Size.Large, 250, p);

            //Execute
            //The position of the player and medium fish are kept the same while the large fish is kept far apart
            //It calls on the EatPlayer method of both fishes to see if the player can eat it
            p.X = 100;
            p.Y = 100;
            m.XPosition = 100;
            m.YPosition = 100;
            l.XPosition = 500;
            l.YPosition = 500;
            p.Grow();
            m.EatPlayer();
            l.EatPlayer();
            //Check
            //As the medium fish can eat the player and the large fish is too far, the points of the player remains the same
            Assert.AreEqual(0, p.Points);

            //Execute
            //The player is then given 4000 points and calls the Grow method to increase its size to medium and then the position
            //of all 3 fishes are kept the same and calls on the EatPLayer method of both fishes.
            p.Points += 4000;
            p.Grow();
            m.XPosition = 100;
            m.YPosition = 100;
            l.XPosition = 100;
            l.YPosition = 100;
            m.EatPlayer();

            //Check
            //The player should be able to eat the medium fish and gain 150 points
            Assert.AreEqual(4150, p.Points);

            //Execute
            //The large fish then calls on the EatPlayer method and eats the player and resets the player points to 1200 as its size is medium
            if (l.EatPlayer() == Outcome.Eat)
            {
                p.Reset();
            }

            //Check 
            //After the Reset method has been called, the player's points should reduce to 1200
            Assert.AreEqual(1200, p.Points);
        }
    }
}