using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EntityController
{
    public virtual float GetHorizontalAxis() => 0f;
    public virtual float GetVerticalAxis() => 0f;
    public virtual bool IsJump() => false;
    public virtual bool IsStartJump() => false;
}
