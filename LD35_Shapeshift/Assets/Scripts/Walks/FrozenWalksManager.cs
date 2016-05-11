using UnityEngine;
using System.Collections.Generic;

//Allows walks to be collectivley frozen all at once
public class FrozenWalksManager : MonoBehaviour {
    public static FrozenWalksManager frozenWalksManager;

    private List<Walk> frozenWalks;

    void Awake()
    {
        frozenWalks = new List<Walk>();
        frozenWalksManager = this;
    }

    //Freeze the walk and remember
    public void freezeWalk(Walk walk)
    {
        walk.Freeze();
        frozenWalks.Add(walk);
    }

    //Unfreeze all remembered walks
    public void unfreezeAllWalks()
    {
        foreach(Walk walk in frozenWalks)
        {
            walk.Unfreeze();
        }
        frozenWalks.Clear();
    }
    
}
