using System;
using System.Net;
using System.Collections;

namespace dogs2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Program start");

            ArrayList pool = new ArrayList();

            for(int i = 0; i < 500; i++)
            {
                Dog d = new Dog();
                pool.Add(d);
                Console.WriteLine("New dog on the pool: " +d.ToString());
            }

            for (int year = 1; year < 6; year++)
            {
                Console.WriteLine("Press any key to simulate year "+year);
                Console.ReadKey();

                ArrayList puppies = new ArrayList();
                ArrayList deadDogs = new ArrayList();

                foreach (Dog male in pool)
                {
                    if (!male.isMale) continue;
                    if (male.age < 2 || male.age > 15) continue;
                    foreach (Dog female in pool)
                    {
                        if (female.isMale) continue;
                        if (female.age < 2 || female.age > 15) continue;
                        if (!male.havePartner && !female.havePartner && male.breed == female.breed)
                        {
                            male.havePartner = female.havePartner = true;
                            Console.WriteLine("Two " + Breed.allBreeds[male.breed] + " mated!");
                            puppies.Add(new Dog(male.breed));
                        }
                        else continue;
                    }
                }

                foreach (Dog d in pool)
                {
                    d.age++;
                    if (d.age >= 18)
                    {
                        deadDogs.Add(d);
                    }
                }
                foreach (Dog d in deadDogs)
                {
                    Console.WriteLine(d.ToString() + " died of old age and was removed from the pool");
                    pool.Remove(d);
                }
                foreach (Dog p in puppies)
                {
                    Console.WriteLine("New puppie add to the pool: " + p.ToString());
                    pool.Add(p);
                }
                

                Console.WriteLine("The pool is like this now: ");
                foreach (Dog d in pool)
                {
                    Console.WriteLine(d.ToString());
                    d.havePartner = false;
                }
                Console.WriteLine("Pool size is " + pool.Count);

            }
            Console.WriteLine("Program finished.");
            Console.ReadKey();
        }
    }
}
