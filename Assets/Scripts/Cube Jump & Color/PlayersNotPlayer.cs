using UnityEngine;

namespace Cube_Jump___Color
{
    public class PlayersNotPlayer : MonoBehaviour
    { 
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private Rigidbody2D rb;
        public void ChangeColor(Color colorSquare)
        {
            sr.color = sr.color == Color.white ? colorSquare : Color.white;
            rb.AddForceY(45, ForceMode2D.Impulse);
        }
   
    
    }
}
