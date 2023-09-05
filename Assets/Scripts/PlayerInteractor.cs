using UnityEngine;

/// <summary>
/// Manages the triggering of any object set as Interactable on the Collision Matrix.
/// 
/// For OnTrigger to work, the Interactor needs a Rigidbody
/// and the Interactable needs a Collider with IsTrigger set to true.
/// 
/// Add a Rigidbody to the Interactor, otherwise the trigger won't fire.
/// The Rigidbody does not necessarily have to be on this object, it could be on one of its parents.
/// Do not add a Rigibody to the Interactable, otherwise OnTrigger will not work
/// and the Interactable will become a physics object that pushes the Interactor away.
///
/// Remember to check the Collision Matrix to avoid having this Interactor unexpectedly push other objects
/// that feature a Rigidbody.
/// </summary>
public class PlayerInteractor : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform _rotatingRoot;
    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private CharacterMovement _playerMovement;

    [Header("Config")]
    [SerializeField] private Color _noTriggerColor;
    [SerializeField] private Color _triggeredColor;
    
    // Start is called before the first frame update
    void Start()
    {
        SetIcon(false);
        _playerMovement.OnDirectionChanged = 
            (CharacterMovement.Direction dir) =>
            {
                Quaternion rotation;
                switch (dir)
                {
                    case CharacterMovement.Direction.Down :
                        rotation = Quaternion.Euler(0,0,0);
                        break;
                    case CharacterMovement.Direction.Right:
                        rotation = Quaternion.Euler(0,0,90);
                        break;
                    case CharacterMovement.Direction.Up:
                        rotation = Quaternion.Euler(0,0,180);
                        break;
                    case CharacterMovement.Direction.Left:
                        rotation = Quaternion.Euler(0,0,270);
                        break;
                    default:
                        rotation = Quaternion.Euler(0,0,0);
                        break;
                }
                _rotatingRoot.rotation = rotation;
            };
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SetIcon(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SetIcon(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (GameControls.IsInteractPressed())
            Debug.Log("Interaction fired...");
    }

    private void SetIcon(bool triggered)
    {
        _icon.color = triggered ? _triggeredColor : _noTriggerColor;
    }
}
