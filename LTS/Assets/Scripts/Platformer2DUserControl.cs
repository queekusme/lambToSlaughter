using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        public int ignoreLayerSheep;
        public int ignoreLayerShepherd;
        
        private void Awake() {
            m_Character = GetComponent<PlatformerCharacter2D>();
            Physics2D.IgnoreLayerCollision(ignoreLayerSheep, ignoreLayerShepherd, true);
        }


        private void Update() {
            if (!m_Jump) {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump" + name);
            }
        }


        private void FixedUpdate() {
            // Read the inputs.
            float h = Input.GetAxis("Horizontal" + name);
            if (m_Jump && m_Character.m_Anim.GetBool("Ground")) { AudioManager.instance.PlaySound2D(name + " Jump"); }
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        }
    }
}
