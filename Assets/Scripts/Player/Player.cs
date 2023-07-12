using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    ExperienceManager expManager;

    public float maxHealth;

    public float currentHealth;

    public float moveSpeed;

    public float damage;

    public float currentExp;

    public float maxExp;

    public int currentLevel;

    public double energy;
    public double maxenergy;

    public int kills;

    void Start()
    {
        maxHealth=100;
        currentHealth=maxHealth;
        moveSpeed = 5;
        damage = 20;
        currentExp = 0;
        maxExp = 100;
        currentLevel =1;
        energy = 0;
        maxenergy = 1.5;
        kills= 0;
    }

    void Update()
    {
        energy += Time.deltaTime;

        if (ExperienceManager.getEXP()>0)
        {
            ExpChange(ExperienceManager.getEXP());
            ExperienceManager.setExp(0);
        }

        if (ExperienceManager.getKills() > 0)
        {
            kills++;
            ExperienceManager.setKills(0);
        }

        if (kills>=26)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void ExpChange(float NewExp)
    {
        currentExp += NewExp;
        if(currentExp>= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        maxHealth += 30;

        currentHealth = maxHealth;

        moveSpeed += 1;

        damage += 20;

        currentExp = 0;

        maxExp += 25;

        currentLevel++;

        if((maxenergy-0.25)>0)
        {
            maxenergy = maxenergy - 0.25;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();

        }
    }

    public void Die()
    {
        Debug.Log("you're dead!");

        SceneManager.LoadScene(0);
    }

}
