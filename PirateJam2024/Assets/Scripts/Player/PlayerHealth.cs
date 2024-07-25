using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP { get; private set;}

    [SerializeField]
    private SpawnPointManager spawnPointManager;

    private void Awake() {
        CurrentHP = MaxHP;
    }

    public void TakeDamage(float damage){
        CurrentHP -= damage;
        if (CurrentHP <= 0) {
            ProcessDeath();
        }
    }

    public void Heal(float hpRegained){
        if (CurrentHP > 0) {
            CurrentHP += hpRegained;
            Mathf.Clamp(CurrentHP, 0, MaxHP);
        }
    }

    public void UpgradeMaxHP(float hpGained) {
        MaxHP += hpGained;
        CurrentHP = MaxHP;
    }

    private void ProcessDeath() {
        Debug.Log("Player died!");
        Respawn();
    }

    public void Respawn() {
        GetComponent<CharacterController>().enabled = false;
        transform.position = spawnPointManager.GetLatestSpawnPoint();
        GetComponent<CharacterController>().enabled = true;
        Debug.Log(gameObject + " has respawned at: " + spawnPointManager.GetLatestSpawnPoint());
    }
}
