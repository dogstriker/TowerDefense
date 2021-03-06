﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameMaps;
namespace TowerDefence
{
    public enum UnitTypes
    {
        ground,
        shell,
        flyer
    }
        
    public class GOParams : ICoordinateProvider, IPositionProvider
    {
        public UnitTypes Type { get; set; }
        public int TTL { get; set; }
        public bool IsFriendly { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public  int Range {get;set;}
        public int DamageMin { get; set; }
        public int DamageMax { get; set; }
        public int ChargeRate { get; set; }
        public int ChargeLevel { get; set; }
        public int ChargeReady { get; set; }
        public int Resources { get; set; }
        public int Mass { get; set; }
        private double velocity;
        public Dictionary<string, double> Par=new Dictionary<string,double>();
        public Dictionary<string, string> ParString = new Dictionary<string, string>();
        public double Velocity {
<<<<<<< HEAD
            get {
                if (VelocityModifiers.Count == 0)
                {
                    return velocity;
                }
                else 
                {
                    double v = velocity;
                    for(int i=0;i<VelocityModifiers.Count;i++)
                    {
                        v = v * VelocityModifiers[i].Modifier;
                        if (VelocityModifiers[i].Modifier < 1)
                        {
                            v = v;

                        }
                    }
                    return v;
                }

            }
=======
            get { return velocity; }
>>>>>>> 2002e4df34f85f6d15ee19510f6ca7a02de32d9d
            set { velocity = value; UpdateXYVelocity(); }
        }
        public double AngularVelocity { get; set; }
        public double Vx { get; private set; }
        public double Vy { get; private set; }

        double _x;
        double _y;
        public double X {
            get { return _x; }
            set { _x = value; /*Debug.WriteLine("X changed to " + value.ToString());*/ } }
        public double Y {
            get { return _y; }
            set { _y = value; /*Debug.WriteLine("Y changed to " + value.ToString());*/ } }

        private double angle;
        public double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                UpdateXYVelocity();
            }
        }

        public void UpdateXYVelocity()
        {
            Vx = Velocity * Math.Cos(GameMath.DegreesToRad(angle));
            Vy = Velocity * Math.Sin(GameMath.DegreesToRad(angle));
        }

        public string debug;

        public GOParams()
        {

        }

        public void CopyPar(GOParams p)
        {
            Angle = p.Angle;
            AngularVelocity = p.AngularVelocity;
            Attack = p.Attack;
            Defense = p.Defense;
            DamageMax = p.DamageMax;
            DamageMin = p.DamageMin;
            ChargeRate = p.ChargeRate;
            ChargeLevel = p.ChargeLevel;
            ChargeReady = p.ChargeReady;
            Velocity = p.Velocity;
            Range = p.Range;
            Mass = p.Mass;
            Type = p.Type;
            HP = p.HP;
            X = p.X;

            Y = p.Y;
            //foreach (var k in p.Par.Keys)
            //{
            //    if (Par.ContainsKey(k)) Par[k] = p.Par[k];
            //    else Par.Add(k, p.Par[k]);
            //}
        }

        public void CopyParWithoutPosition(GOParams p)
        {
            AngularVelocity = p.AngularVelocity;
            Attack = p.Attack;
            Defense = p.Defense;
            DamageMax = p.DamageMax;
            DamageMin = p.DamageMin;
            ChargeRate = p.ChargeRate;
            ChargeLevel = p.ChargeLevel;
            ChargeReady = p.ChargeReady;
            Velocity = p.Velocity;
            Type = p.Type;
            Mass = p.Mass;
            HP = p.HP;
            Range = p.Range;

            //foreach (var k in p.Par.Keys)
            //{
            //    if (Par.ContainsKey(k)) Par[k] = p.Par[k];
            //    else Par.Add(k, p.Par[k]);
            //}
        }

    }


    public class GOParamsRelative : GOParams
    {
        public new double X { get; set; }
    }

}
