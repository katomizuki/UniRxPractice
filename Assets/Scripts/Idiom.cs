using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq.Expressions;

public class Idiom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
}

class Distance
{
    List<int> nums = new List<int> { 1, 2, 3, };

    private void Start()
    {
        nums.ForEach(n => Console.WriteLine((n)));
    }
    static double FeetToMeter(int feet)
    {
        return feet * 0.3;
    }
}

namespace DistanceConverter
{
    public class FeetConverter
    {
        public double FromMeter(double meter)
        {
            return meter / 0.3;
        }

        public double ToMeter(double feet)
        {
            return feet * 0.3;
        }
    }
}

public class AppVersion
{
    public int Major;
    public int Minor;
    public int Build;
    public int Revision;

    public AppVersion(int major, int minor, int build, int revision)
    {
        this.Major = major;
        this.Minor = minor;
        this.Build = build;
        this.Revision = revision;
    }

    public AppVersion(int major) : this(major, 0, 0, 0)
    { }
    
    
}