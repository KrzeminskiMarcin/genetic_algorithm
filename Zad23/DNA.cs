using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DNA
{
    public List<byte> geny = new List<byte>();
    public List<double> parametry = new List<double>();
    public double przystosowanie = new double();
    public List<List<List<double>>> parametryXOR = new List<List<List<double>>>();
}
