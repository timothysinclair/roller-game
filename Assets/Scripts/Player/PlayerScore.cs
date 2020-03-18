using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerScore : MonoBehaviour
{
    // Public
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] Animator playerAnimator;

    // Private
    int score = 0;
    private int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (scoreTxt) scoreTxt.text = "Score: " + score;
        }
    }
    int buildingScore = 0;
    int kickScore = 0;
    bool enemyHit = false;
    NewSkatingController movementController;
    PlayerCombatController combatController;
    PlayerSettings pSettings;

    private void Awake()
    {
        movementController = GetComponent<NewSkatingController>();
        combatController = GetComponent<PlayerCombatController>();
        pSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
    }

    public void CheckBuildingScore()
    {
        // Add the built up scores to total
        if (buildingScore > 0 || kickScore > 0)
        {
            // Check that animation is not being done
            if (!combatController.DoingKickAnimation())
            {
                if (enemyHit) { kickScore += (kickScore / pSettings.trickValues[Trick.EnemyHit]); }
                Score += buildingScore + kickScore;
                Debug.Log("Score added: " + (buildingScore + kickScore));
            }
            else
            {
                Debug.Log("Lost score: " + (buildingScore + kickScore));
            }

            buildingScore = 0;
            kickScore = 0;
            enemyHit = false;
        }
    }

    public void AddTrick(Trick _trick)
    {
        if (_trick == Trick.EnemyHit) { enemyHit = true; }
        // If score is a kick, add to kick score. Otherwise add to building score
        else if (_trick >= Trick.Kick1 && _trick <= Trick.Kick3) { kickScore += pSettings.trickValues[_trick]; }
        else { buildingScore += pSettings.trickValues[_trick]; }

        Debug.Log("Added trick: " + _trick);
    }
}
