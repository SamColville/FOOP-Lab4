﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public delegate void CarEngineHandler(object sender, CarEventArgs e);

    class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        private bool carIsDead;
        public CarEngineHandler listOfHandlers { get; set; }

        public Car() { MaxSpeed = 100; }
        public Car(string petName, int maxSpeed, int currentSpeed)
        {
            PetName = petName;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public void Accelerate(int change)
        {
            if (carIsDead)
            {
                if (listOfHandlers != null)
                {
                    Exploded(this, new CarEventArgs("Sorry this car is dead"));
                }
            }
            else
            {
                CurrentSpeed += change;
            }

            if ((MaxSpeed - CurrentSpeed) == 10 && listOfHandlers != null)
            {
                AboutToBlow(this, new CarEventArgs("Careful, nearly maxed out"));
            }

            if (CurrentSpeed >= MaxSpeed)
                carIsDead = true;
            else
                Console.WriteLine("Current Speed: {0}", CurrentSpeed);

            
        }
    }

    public class CarEventArgs:EventArgs
    {
        public readonly string message;

        public CarEventArgs(string msg)
        {
            message = msg;
        }
    }
}
