using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class References
{
    public static GameObject thePlayer;
    public static GameObject theCanvas;
    public static EnemySpawner spawner;

    public static ScreenShake screenShake;

    public static float maxDistanceInALevel = 1000f;

    public static LayerMask wallsLayer = LayerMask.GetMask("Walls");
    public static LayerMask enemiesLayer = LayerMask.GetMask("Enemies");

}
