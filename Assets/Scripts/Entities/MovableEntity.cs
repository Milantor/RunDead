using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// Класс для реализации общего ИИ для всех MoovableEntity.
// В будущем мб реализовать больше типов сущностей, и уже на их основе создавать юнитов
// (Например DefaultWeaponEntity, который будет представлять общий класс для всхе энтити с оружием)
namespace Entities
{
    
    public class MovableEntity : PhysicsEntity
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        const float SpeedMultiplierIncrease = 0.2f;
        public int JumpCounter = 0;
        public int MaxJumpCounter = 1;

        [SerializeField]
        ColliderChecker floorCollider;

        [SerializeField]
        public EntityController controller; // Контроллер, который управляет сущностью
        
        override protected void Start()
        {
            base.Start();
        }
        public void SetController(EntityController controller) => this.controller = controller;
        protected override void Update()
        {
            base.Update();
            if (controller is null)
                return;

            var targetMooveDirection = controller.GetHorizontalAxis();
            float currentSpeedSpeedIncrease = floorCollider.IsTouch ? FloorSpeedSpeedIncrease : AirSpeedSpeedIncrease;
            float currentSpeed = rb.velocity.x / MaxSpeed;
            currentSpeed =
                currentSpeed > targetMooveDirection ?
                Math.Max(currentSpeed - currentSpeedSpeedIncrease * Time.deltaTime, targetMooveDirection) :
                Math.Min(currentSpeed + currentSpeedSpeedIncrease * Time.deltaTime, targetMooveDirection);
            rb.velocity = new Vector2(currentSpeed * MaxSpeed, rb.velocity.y);
            if (controller.IsStartJump() && floorCollider.IsTouch)
                isJumping = true;

            if (isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
                lengthOfJump += Time.deltaTime;
            }

            if (isJumping && (lengthOfJump >= MaxLengthOfJump || !controller.IsJump()))
            {
                isJumping = false;
                lengthOfJump = 0;
            }
        }

        [SerializeField]
        public ModificableFloat FloorSpeedSpeedIncrease = new(5f);
        [SerializeField]
        public ModificableFloat AirSpeedSpeedIncrease = new(1.2f);
        [SerializeField]
        public ModificableFloat MaxSpeed = new(40f);

        public ModificableFloat JumpPower = new(5f);
        float lengthOfJump = 0f;
        public float MaxLengthOfJump = 0.4f; // in seconds
        bool isJumping = false;
    }
}