using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class Globals
{
    public static MusicManager MusicManager;
    public static SoundManager SoundManager;
    
    public static Dictionary<string, ArrayList> LoadTSV(string file) {
        
        Dictionary<string, ArrayList> dictionary = new Dictionary<string, ArrayList>();
        ArrayList list = new ArrayList();

        using (var reader = new StreamReader(Application.dataPath + "/files/" + file + ".tsv")) {
            while (!reader.EndOfStream)
            {
                list = new ArrayList();
                var line = reader.ReadLine();
                if (line == null) continue;
                string[] values = line.Split('	');
                for (int i=1; i < values.Length; i++) {
                    list.Add(values[i]);
                }
                if (values[0] != "") dictionary.Add(values[0], list);
            }
        }

        return dictionary;
    }
    
    public static bool IsAnimationPlaying(Animator anim, string stateName, int animLayer=0)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        
        return false;
    }
    
    public static int Mod(int x, int m) {
        int r = x%m;
        return r<0 ? r+m : r;
    }
    
    public static String NumberToChar(int num, bool capital) {
        Char c = (Char)((capital ? 65 : 97) + (num - 1));

        return c.ToString();
    }
    
    public static int DamageFormula(int atk, int def)
    {
        return Mathf.Max(Mathf.RoundToInt((float) ((atk * 4 - def * 2) * GetRandomNumber(0.7f, 1.2f))), 1);
    }
    
    public static double GetRandomNumber(double minimum, double maximum)
    { 
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}