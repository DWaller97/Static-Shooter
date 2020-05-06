﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public List<GameObject> enemies;

    void Awake(){
        instance = this;
        enemies = new List<GameObject>();
    }

    public static PoolManager GetInstance(){
        return instance;
    }
    public void CreateEnemyPool(GameObject obj, int amount){
        Transform enemyTarget = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < amount; i++){
            GameObject clone = Instantiate(obj, Vector3.zero, Quaternion.identity);
            clone.SetActive(false);
            EnemyNavigation nav = clone.AddComponent<EnemyNavigation>();
            nav.playerTransform = enemyTarget;
            clone.name = $"Enemy {i + 1}";
            enemies.Add(clone);
        }
    }

    public GameObject GetEnemyFromPool(){
        foreach(GameObject obj in enemies){
            if(!obj.activeInHierarchy)
                return obj;
        }
        return null;
    }

}
