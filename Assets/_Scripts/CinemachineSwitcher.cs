using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{

    private static CinemachineSwitcher _instance;
    public static CinemachineSwitcher Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    //[SerializeField] private InputAction action;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //private void OnEnable()
    //{
    //    action.Enable();
    //}

    //private void OnDisable()
    //{
    //    action.Disable();
    //}
}
