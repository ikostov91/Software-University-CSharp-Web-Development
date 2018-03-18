﻿using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get
        {
            return base.Degradation;
        }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
            }
            base.Degradation = value;
        }
    }

    public override void CompleteLap()
    {
        base.CompleteLap();

        this.Degradation -= this.Grip;
    }
}

