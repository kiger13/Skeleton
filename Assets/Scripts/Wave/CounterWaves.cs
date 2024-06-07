using System.Collections;
using UnityEngine;

public class CounterWaves
{
    public int CountWaves { get; private set; } 
    
    public void AddWaveCount()
    {
        CountWaves++;
    }
}