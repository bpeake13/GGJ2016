using UnityEngine;
using System.Collections;

public class enums {

    public enum PlayerStates { player1Alive, player2Alive, bothAlive };

    public enum InventorySlot { head, body, leg, arm };
    public enum legType { leg1, leg2, leg3 };
    public enum headType { head1, head2, head3 };
    public enum armType { arm1, arm2, arm3 };
    public enum bodyType { body1, body2, body3 };

    public enum WolfAnimations { Wolf_Idle, Wolf_Munch, Wolf_Run };
    public enum PlayerActionStates { Idle, Run, Walk, StruggleWalk, Cry, Death, DigSearch, Pickup}
    public enum PlayerAnimations { Torso_Rig_Idle, Torso_Rig_Walk };
}
