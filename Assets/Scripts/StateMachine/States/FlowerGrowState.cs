using System;
using UnityEngine;


namespace Flowers.State
{
    public class FlowerGrowState : IState
    {

        /// <summary>
        /// This State disables the dug out hole and enables the flower again.
        /// The flower simulates growth with a simple lerp.
        /// This is the final stage of flower progression.
        /// </summary>

        #region Delegates

        public static event Action<string> flowerHasGrownSound;

        #endregion

        #region Variables

        FlowerStateMachine _flowerSM;
        SimulateFlowerGrowth _scale;
        Renderer _renderer;
        Material _flowerMaterial;

        #endregion


        #region Functions

        // Specific components can be sent down from the State Machine Controller to the States.
        public FlowerGrowState(FlowerStateMachine flowerSM, Renderer renderer, Material flowerMaterial)
        {
            _flowerSM = flowerSM;
            _renderer = renderer;
            _flowerMaterial = flowerMaterial;
        }

        // This functions marks the start of a new State and is automatically called by the State Machine.
        public void Enter()
        {
            // Switches out materials on State Change.
            Renderer copyOfRenderer = _renderer;
            Material[] copiedMaterials = copyOfRenderer.materials;
            copiedMaterials[0] = _flowerMaterial;
            copyOfRenderer.materials = copiedMaterials;

            // Disables dirt pile / dug out hole and enables flower object again.
            _flowerSM.ToggleGameObjects("DugOutHole", false);
            _flowerSM.ToggleGameObjects("FlowerBody", true);

            // Gets Growth Simulation Script attached to Flower.
            _scale = _flowerSM.GetComponent<SimulateFlowerGrowth>();
            
            // Enables Script and scales and transforms the flower back up to its original size.
            _scale.enabled = true;
            // broadcast the message that progress has been made.
            flowerHasGrownSound?.Invoke("Progress");
        }

        // This functions marks the end of the current State and is automatically called by the State Machine.
        public void Exit()
        {

        }

        // Allows simulation of FixedUpdate() method without a MonoBehaviour attached.
        public void FixedTick()
        {

        }

        // Allows simulation of Update() method without a MonoBehaviour attached.
        public void Tick()
        {

        }

        #endregion
    }

}

