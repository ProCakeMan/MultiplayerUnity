// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""GroundMovement"",
            ""id"": ""b23aacd4-f5af-44f4-bbc5-ed22fae1c3ac"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""fbc42f51-df69-4b8b-b840-6f9a592a52ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""565c4e49-95c3-493f-8056-a40327955d69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""e1cdfbf4-8f77-4fb0-b7a9-2c6032fddd74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""df543c51-050e-4707-9c17-aa1a1fd6f1ed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""bc7ae044-dfc6-4af9-89c7-fd8f25296dea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""9eae61a1-a783-46be-8266-1eb4c1416f0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""8dbf81b6-9177-458c-bb4f-37f851120b3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a933e48c-72ba-4ba1-aa03-3837de124c05"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1e4d6450-2c8a-4174-b884-7003904e53dc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d51b517-c2c6-4ad6-bab4-017aa88684e0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""570d87d5-7eee-4fa5-9c54-b8dca881676f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""feb3365c-3a59-4223-826a-f1f5996897fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dfab06d1-5e9c-4a15-8961-742efc3b89cf"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a8d1df0-18a9-4a87-a433-1e8fc5bc9842"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af5e1981-bb4a-488a-80ad-a8d1b5f28c47"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Tap"",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22b37772-932a-45e9-af42-24f75abf4b8a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Tap"",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d144d098-2ef9-4c42-bd31-9c079a974525"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bb83773-9f90-474f-82ca-3e19656f93dc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e0b202-0e4d-4182-ac9e-2fd828dd0606"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard Mouse"",
            ""bindingGroup"": ""Keyboard Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GroundMovement
        m_GroundMovement = asset.FindActionMap("GroundMovement", throwIfNotFound: true);
        m_GroundMovement_Movement = m_GroundMovement.FindAction("Movement", throwIfNotFound: true);
        m_GroundMovement_Jump = m_GroundMovement.FindAction("Jump", throwIfNotFound: true);
        m_GroundMovement_Crouch = m_GroundMovement.FindAction("Crouch", throwIfNotFound: true);
        m_GroundMovement_Look = m_GroundMovement.FindAction("Look", throwIfNotFound: true);
        m_GroundMovement_Shoot = m_GroundMovement.FindAction("Shoot", throwIfNotFound: true);
        m_GroundMovement_ChangeWeapon = m_GroundMovement.FindAction("ChangeWeapon", throwIfNotFound: true);
        m_GroundMovement_Reload = m_GroundMovement.FindAction("Reload", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GroundMovement
    private readonly InputActionMap m_GroundMovement;
    private IGroundMovementActions m_GroundMovementActionsCallbackInterface;
    private readonly InputAction m_GroundMovement_Movement;
    private readonly InputAction m_GroundMovement_Jump;
    private readonly InputAction m_GroundMovement_Crouch;
    private readonly InputAction m_GroundMovement_Look;
    private readonly InputAction m_GroundMovement_Shoot;
    private readonly InputAction m_GroundMovement_ChangeWeapon;
    private readonly InputAction m_GroundMovement_Reload;
    public struct GroundMovementActions
    {
        private @InputSystem m_Wrapper;
        public GroundMovementActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GroundMovement_Movement;
        public InputAction @Jump => m_Wrapper.m_GroundMovement_Jump;
        public InputAction @Crouch => m_Wrapper.m_GroundMovement_Crouch;
        public InputAction @Look => m_Wrapper.m_GroundMovement_Look;
        public InputAction @Shoot => m_Wrapper.m_GroundMovement_Shoot;
        public InputAction @ChangeWeapon => m_Wrapper.m_GroundMovement_ChangeWeapon;
        public InputAction @Reload => m_Wrapper.m_GroundMovement_Reload;
        public InputActionMap Get() { return m_Wrapper.m_GroundMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundMovementActions set) { return set.Get(); }
        public void SetCallbacks(IGroundMovementActions instance)
        {
            if (m_Wrapper.m_GroundMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnCrouch;
                @Look.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnLook;
                @Shoot.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnShoot;
                @ChangeWeapon.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnChangeWeapon;
                @Reload.started -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_GroundMovementActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_GroundMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ChangeWeapon.started += instance.OnChangeWeapon;
                @ChangeWeapon.performed += instance.OnChangeWeapon;
                @ChangeWeapon.canceled += instance.OnChangeWeapon;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public GroundMovementActions @GroundMovement => new GroundMovementActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IGroundMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnChangeWeapon(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
}
