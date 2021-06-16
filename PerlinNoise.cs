using System;
using System.Collections;
using System.Collections.Generic;

public class PerlinNoise {
    private long seed;
    
    public PerlinNoise(long seed) {
        this.seed = seed;
    }
    
    public double InitPerlinNoise(double x, double p, int n)
    {
        double total = 0;
        double frequency;
        double amplitude;
        
        for(int i = 0; i < n + 1; i++)
        {
            frequency = Math.Pow(2, i);
            amplitude = Math.Pow(p, i);
            total = total + InterpolateNoise(x * frequency) * amplitude;
        }
        
        return total;
    }

    private double InterpolateNoise(double x)
    {
        int ix = (int)x;
        double fx = x - ix;
        double v1 = SmoothNoise(ix);
        double v2 = SmoothNoise(ix + 1);
        return Interpolate(v1, v2, fx);
    }

    private double SmoothNoise(int x)
    {
        return Noise(x) / 2 + Noise(x - 1) / 4 + Noise(x + 1) /4;
    }
    
    private double Noise(int x) 
    {
        x = (int)(seed ^ x);
        return (1.0 - ((x * (x * x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0);
    }
    
    private double Interpolate(double a, double b, double x)
    {
        double ft = x * Math.PI;
        double f = (1 - Math.Cos(ft)) / 2;
        return a * (1 - f) + b * f;
    }
}
