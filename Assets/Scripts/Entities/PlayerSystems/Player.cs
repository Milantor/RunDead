using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Entities.Player
{
    public class Player : MovableEntity
    {
        protected override void Update()
        {
            base.Update();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 2f * Time.deltaTime);
        }

    }

}