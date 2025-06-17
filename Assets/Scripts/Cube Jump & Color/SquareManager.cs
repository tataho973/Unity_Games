using UnityEngine;

namespace Cube_Jump___Color
{
    public class SquareManager : MonoBehaviour
    {
        [SerializeField] private PlayersNotPlayer[] squares; 
        [SerializeField] private Color colorSquare = Color.aquamarine;

        [SerializeField] private KeyCode keyCodeChangeColor;
        void Update()
        {
            if (Input.GetKeyDown(keyCodeChangeColor))
            {
                for (int i = 0; i < squares.Length; i++)
                {
                    squares [i].ChangeColor(colorSquare); 
                    
                }
            
                // if (sr.color == Color.white)
                // {
                //     sr.color = colorSquare;
                // }
                // else if ( sr.color == colorSquare)
                // {
                //     sr.color = Color.white;
                // }
            }
        }
    }
}