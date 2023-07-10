using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MyVector3
{
    public double x, y, z;
    public MyVector3()
    {
    }
    public MyVector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static MyVector3 operator +(MyVector3 A, MyVector3 B)
    {
        return new MyVector3(A.x + B.x, A.y + B.y, A.z + B.z);
    }
    public static MyVector3 operator -(MyVector3 A, MyVector3 B)
    {
        return new MyVector3(A.x - B.x, A.y - B.y, A.z - B.z);
    }
    public static MyVector3 operator *(MyVector3 A, double B)
    {
        return new MyVector3(A.x * B, A.y * B, A.z * B);
    }
    public static double operator *(MyVector3 A, MyVector3 B)
    {
        double result = (A.x * B.x + A.y * B.y + A.z * B.z);
        return result;
    }
    public double Magnitud()
    {
        double result = Math.Sqrt(x * x + y * y + z * z);
        return result;
    }
    public static MyVector3 operator /(MyVector3 A, double B)
    {
        return new MyVector3(A.x / B, A.y / B, A.z / B);
    }
    public double Angulo(MyVector3 A, MyVector3 B)
    {
        double result = Math.Acos((A * B) / (A.Magnitud() * B.Magnitud()));
        result = result * (180 / Math.PI);
        result = Math.Round(result, 2);
        return result;
    }
}
