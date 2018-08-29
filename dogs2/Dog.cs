using System;
using System.Collections.Generic;
using System.Text;

namespace dogs2
{
    class Dog
    {
        public int breed = -1;
        public int age = -1;
        public bool isMale = true;
        public bool havePartner = false;

        public Dog()
        {
            Random rnd = new Random();
            breed = rnd.Next(Breed.allBreeds.Length);
            age = rnd.Next(1, 17);
            if(age%2 == 0)
            {
                isMale = false;
            }
        }

        public Dog(int breed)
        {
            Random rnd = new Random();
            this.breed = breed;
            age = 0;
            if (rnd.Next()%2==0)
            {
                isMale = false;
            }
        }

        public override string ToString()
        {
            return (isMale ? "male " : "female ") + Breed.allBreeds[breed] +" age "+ age;
        }

    }
}
