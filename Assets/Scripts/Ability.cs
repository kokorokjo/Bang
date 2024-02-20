using System;
using System.Collections.Generic;


public struct Ability
{
    public string Name;
    public List<string> Usage;
    public Action UseAbility;

    public Ability(string name, List<string> usage, Action func)
    {
        Name = name;
        Usage = usage;
        UseAbility = func;
    }
    
}