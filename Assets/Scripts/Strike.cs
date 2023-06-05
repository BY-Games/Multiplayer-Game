using Fusion;
using UnityEngine;

public class Strike : NetworkBehaviour
{

    [SerializeField] NumberField strikeDisplay;

    [Networked(OnChanged = nameof(NetworkedStrikeChanged))]
    public int NetworkedStrike { get; set; } = 0;
    private static void NetworkedStrikeChanged(Changed<Strike> changed)
    {
        
        Debug.Log($"Strike point changed to: {changed.Behaviour.NetworkedStrike}");

        changed.Behaviour.strikeDisplay.SetNumber(changed.Behaviour.NetworkedStrike);
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    // All players can call this function; only the StateAuthority receives the call.

    // Add a player a point for hitting another player
    public void strikeRpc()
    {
        NetworkedStrike += 1;
    }

}
