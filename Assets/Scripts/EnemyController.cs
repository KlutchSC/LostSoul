using UnityEngine;
using System.Collections;

public class EnemyController : Unit {

    public bool isStunned;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

    /// <summary>
    /// The enemy will have two stances, one where he notices the
    /// player and begins to attack him, and one where he is not
    /// aware of the player (most likely when the player is in 
    /// spirit form).
    /// </summary>
    public void SwitchStance()
    {
        if (GameController.control.player_isSpirit)
        {

        }
    }

    /// <summary>
    /// will allow the enemy to find the player unit
    /// and attempt to pursue the player if he is in range
    /// </summary>
    public void TrackPlayer()
    {

    }

    /// <summary>
    /// Will stun the enemy in place, allowing free movement
    /// of the player through the unit.
    /// </summary>
    public void StunMe()
    {
        isStunned = true;
    }

    /// <summary>
    /// When the health pool of the enemy falls to 0 or below
    /// the enemy will be considered dead and will disappear
    /// from the game environment.
    /// </summary>
    public void KillMe()
    {

    }
}
