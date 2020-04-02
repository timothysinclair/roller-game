using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class PlayerScore : MonoBehaviour
{
    // Public
    public TextMeshProUGUI scoreText;
    public Image rankEmpty;
    public Image rankFull;
    public TextMeshProUGUI currentCollectibles;
    public TextMeshProUGUI maxCollectibles;

    public GameObject[] rankUpParticles;
    public GameObject addScorePrefab;
    public GameObject loseScorePrefab;
    public GameObject scoreParentObj;

    [SerializeField] TextMeshProUGUI buildingScoreTxt;
    [SerializeField] Animator textAnimator;

    // Private
    int buildingScore = 0;
    int kickScore = 0;
    int grindingScore = 0;
    int scoreToAdd = 0;
    bool enemyHit = false;
    PlayerMovementController movementController;
    PlayerCombatController combatController;
    PlayerSettings playerSettings;
    int maxScore;
    private RankDefinition currentRank;
    private int collectiblesCollected = 0;
    private int totalCollectibles;
    bool scoreAnimating = false;
    private Rigidbody rigidBody;

    int score = 0;
    private int Score
    {
        get { return score; }
        set
        {
            int oldScore = score;
            int newScore = Mathf.Clamp(value, 0, maxScore);

            int deltaUnclamped = value - oldScore;
            int delta = newScore - oldScore;
            score = newScore;

            if (delta != 0 || deltaUnclamped != 0) { OnScoreChanged(delta, deltaUnclamped); }
        }
    }

    private void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
        combatController = GetComponent<PlayerCombatController>();
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        maxScore = playerSettings.playerRanks[playerSettings.playerRanks.Length - 1].exitScore;
        rigidBody = GetComponent<Rigidbody>();

        totalCollectibles = FindObjectsOfType<Collectible>().Length;
        maxCollectibles.text = totalCollectibles.ToString();
    }

    public void CheckBuildingScore()
    {
        // Add the built up scores to total
        if (buildingScore > 0 || kickScore > 0 || grindingScore > 0)
        {
            if (scoreAnimating) { return; }
            scoreAnimating = true;
            scoreToAdd = GetScoreToAdd();

            // Check that animation is not being done
            if (!combatController.DoingKickAnimation())
            {
                textAnimator.SetTrigger("ScoreAdded");
                AudioManager.Instance.PlaySoundVaried("Score Increase");
                rigidBody.AddForce(transform.forward * scoreToAdd * 120.0f);
            }
            else
            {
                textAnimator.SetTrigger("ScoreLost");
                AudioManager.Instance.PlaySoundVaried("Score Lost");
                GameObject particles = Instantiate(loseScorePrefab, scoreParentObj.transform);
                GameObject.Destroy(particles, 5.0f);
            }
        }
    }

    public void AddBuildingScore()
    {
        Score += scoreToAdd;

        LoseBuildingScore();
        Debug.Log("Score added");

        GameObject particles = Instantiate(addScorePrefab, scoreParentObj.transform);
        GameObject.Destroy(particles, 5.0f);
    }

    public void LoseBuildingScore()
    {
        buildingScoreTxt.text = "";

        buildingScore = 0;
        kickScore = 0;
        grindingScore = 0;
        enemyHit = false;
        scoreToAdd = 0;
        scoreAnimating = false;
        Debug.Log("Score reset");

        if (buildingScore > 0 || grindingScore > 0 || kickScore > 0)
        {
            SetBuildingScoreText();
        }

        
    }

    int GetScoreToAdd()
    {
        if (enemyHit) { kickScore += (kickScore / playerSettings.trickValues[Trick.EnemyHit]); }

        int num = buildingScore + kickScore + grindingScore;

        buildingScore = 0;
        kickScore = 0;
        grindingScore = 0;
        enemyHit = false;

        return num;
    }

    public void AddTrick(Trick _trick, float _grindTime = 0.0f)
    {
        if (_trick == Trick.EnemyHit) { enemyHit = true; }
        // If score is a kick, add to kick score. Otherwise add to building score
        else if (_trick >= Trick.Kick1 && _trick <= Trick.Kick3) { kickScore += playerSettings.trickValues[_trick]; }
        else if (_trick == Trick.Grind) { grindingScore += Mathf.FloorToInt((float)playerSettings.trickValues[Trick.Grind] * _grindTime); }
        else { buildingScore += playerSettings.trickValues[_trick]; }

        if (!scoreAnimating)
        {
            SetBuildingScoreText();
        }
            
    }

    void SetBuildingScoreText()
    {
        if (enemyHit)
        {
            buildingScoreTxt.text = "+" + (buildingScore + grindingScore + (kickScore + kickScore / playerSettings.trickValues[Trick.EnemyHit]));
        }
        else
        {
            buildingScoreTxt.text = "+" + (buildingScore + grindingScore + kickScore);
        }
    }

    private void OnScoreChanged(int delta, int deltaUnclamped)
    {
        if (scoreText) scoreText.text = "Score: " + score;

        if (delta != 0) { UpdateRankSprite(); }
        movementController.boostingState.Boost += deltaUnclamped * playerSettings.scoreToBoostRatio;
    }

    private void UpdateRankSprite()
    {
        RankDefinition[] ranks = playerSettings.playerRanks;
        for (int i = 0; i < ranks.Length; i++)
        {
            RankDefinition thisRank = ranks[i];
            if (score > thisRank.enterScore && score <= thisRank.exitScore)
            {
                if (thisRank != currentRank)
                {
                    currentRank = thisRank;
                    OnRankChanged();
                }

                int scoreRange = thisRank.exitScore - thisRank.enterScore;
                float fill = (score - thisRank.enterScore) / (float)scoreRange;

                rankFull.fillAmount = fill;
            }
        }
    }

    private void OnRankChanged()
    {
        rankEmpty.sprite = currentRank.emptySprite;
        rankFull.sprite = currentRank.fullSprite;

        movementController.maxSpeed = currentRank.maxSpeed;
        movementController.boostingMaxSpeed = currentRank.boostingMaxSpeed;
        movementController.boostJumpMultiplier = currentRank.boostJumpMultiplier;

        if (currentRank.name != "D") { PlayRankChangedParticle(currentRank.name); }

        AudioManager.Instance.PlaySoundVaried("Rank Up");
    }

    private void PlayRankChangedParticle(string newRank)
    {
        Dictionary<string, int> rankNums = new Dictionary<string, int>()
        {
            { "C", 0 },
            { "B", 1 },
            { "A", 2 },
            { "S", 3 },
        };

        int newRankNum = rankNums[newRank];
        rankUpParticles[newRankNum].SetActive(true);
        StartCoroutine(DeactivateObjectAfter(rankUpParticles[newRankNum], 1.0f));
    }

    private IEnumerator DeactivateObjectAfter(GameObject obj, float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);

        obj.SetActive(false);
    }

    public void CollectCollectible()
    {
        collectiblesCollected += 1;
        currentCollectibles.text = collectiblesCollected.ToString();
    }

    public void CollectibleReset()
    {
        collectiblesCollected -= 1;
        currentCollectibles.text = collectiblesCollected.ToString();
    }
}