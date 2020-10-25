using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;
    public int Requirement;
    public int currentEarn;

    public bool IsReached()
    {
        return (currentEarn >= Requirement);
    }

    public void EnemyDestroy()
    {
        if (goalType == GoalType.Kill)
        currentEarn++;
    }

    public void Gathering()
    {
        if (goalType == GoalType.Gathering)
            currentEarn++;
    }
}

public enum GoalType
{
    Gathering,
    Kill
}