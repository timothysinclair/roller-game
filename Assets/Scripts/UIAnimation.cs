using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] PlayerScore playerScore;

    public void AEAddScore()
    {
        playerScore.AddBuildingScore();
    }

    public void AELoseScore()
    {
        playerScore.LoseBuildingScore();
    }
}
