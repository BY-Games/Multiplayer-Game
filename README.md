# Multiplayer-Game


# Play The Game
You can play the game online [here](
https://by-games.itch.io/multiplayer-game).


# About 
This game is an improvement upon the game [Multiplayer games using Photon Fusion
](https://github.com/gamedev-at-ariel/multiplayer-fusion.git) using Photon Fusion and incorporates some of the concepts of a multiplayer game using Photon Fusion.



# Instructions:

* Use the arrow buttons to move the player.
* Change the player's color by pressing the C button.
* Shoot using the left mouse button.

## Player Stats:

* Purple: Represents the number of times a player has successfully struck another player.
* Green: Indicates the player's current health level.
* Shield: The player can pick up a blue cube to activate a shield that lasts for 5 seconds.

# Our Improvements
1. Now, when a player shoots another player, they receive points. This change was implemented in [Strike.cs](Assets\Scripts\Strike.cs).

2. The player can acquire a shield, but only if they are the first to reach it. The shield lasts for 5 seconds. This change can be found in [Shield.cs](Assets\Scripts\Shield.cs).


In [RaycastAttack.cs](Assets\Scripts\RaycastAttack.cs), we have made the following modifications:



<div dir='ltr'>

                if (Runner.GetPhysicsScene().Raycast(ray.origin, ray.direction * shootDistance, out var hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Debug.Log("Raycast hit: name=" + hitObject.name + " tag=" + hitObject.tag + " collider=" + hit.collider);
                if (hitObject.TryGetComponent<Health>(out var health))
                {
                    Debug.Log("Dealing damage");


                    if (hitObject.TryGetComponent<Shield>(out var shield))
                    {

                        //The shield is active
                        if (!shield.ShieldActive())
                        {
                            var strike = this.GetComponent<Strike>();

                            //Check that the player does not shoot himself
                            if (hitObject != this.gameObject)
                            {
                                health.DealDamageRpc(Damage);



                                //Add a player a point for hitting another player
                                strike.strikeRpc();
                                Debug.Log(this.name + ": strike " + hitObject.name);
                            }


                        }
                        else
                        {
                            Debug.Log("The player has a shield you can't shoot him!");

                        }

                    }
                }

            }

</div>


