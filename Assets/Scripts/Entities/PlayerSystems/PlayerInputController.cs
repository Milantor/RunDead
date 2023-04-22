using Entities.Player;
using UnityEngine;

public class PlayerInputController : EntityController
{
    bool holded = false;
    

    public override float GetHorizontalAxis() => Input.GetAxisRaw("Horizontal");
    public override bool IsJump() => Input.GetKey(KeyCode.W);
    public override bool IsStartJump() => Input.GetKeyDown(KeyCode.W);

}