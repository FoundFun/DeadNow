//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/CodeBase/Hero/HeroInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @HeroInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @HeroInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""HeroInput"",
    ""maps"": [
        {
            ""name"": ""Hero"",
            ""id"": ""8c0c2034-4413-4591-b9fb-b6adf96a085b"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""45e8dfea-7418-48e0-b2b4-8374abe18aa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""45e8dfea-7418-48e0-b2b4-8374abe18aa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Squat"",
                    ""type"": ""Button"",
                    ""id"": ""45e8dfea-7418-48e0-b2b4-8374abe18aa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1f5074ed-5921-4e21-80c0-11a1083ac66b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""96a179d4-a914-4e9e-ac6f-57c8d27fc59b"",
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
                    ""id"": ""96a179d4-a914-4e9e-ac6f-57c8d27fc59b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96a179d4-a914-4e9e-ac6f-57c8d27fc59b"",
                    ""path"": ""<Keyboard>/leftctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Squat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8b5d1de2-fefe-4fa1-b7df-daabf10784bf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ad35096-e5f8-4356-ab6b-7fb51c51adc5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aecaaf14-828e-4d44-9b96-b7ea57a8c19f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_Jump = m_Hero.FindAction("Jump", throwIfNotFound: true);
        m_Hero_Move = m_Hero.FindAction("Move", throwIfNotFound: true);
        m_Hero_Squat = m_Hero.FindAction("Squat", true);
        m_Hero_Attack = m_Hero.FindAction("Attack", true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Hero
    private readonly InputActionMap m_Hero;
    private List<IHeroActions> m_HeroActionsCallbackInterfaces = new List<IHeroActions>();
    private readonly InputAction m_Hero_Jump;
    private readonly InputAction m_Hero_Move;
    private readonly InputAction m_Hero_Squat;
    private readonly InputAction m_Hero_Attack;

    public struct HeroActions
    {
        private @HeroInput m_Wrapper;

        public HeroActions(@HeroInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Hero_Jump;
        public InputAction @Move => m_Wrapper.m_Hero_Move;
        public InputAction @Squat => m_Wrapper.m_Hero_Squat;
        public InputAction @Attack => m_Wrapper.m_Hero_Attack;

        public InputActionMap Get() 
        { 
            return m_Wrapper.m_Hero;
        }

        public void Enable() 
        { 
            Get().Enable(); 
        }

        public void Disable() 
        { 
            Get().Disable(); 
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(HeroActions set) 
        { 
            return set.Get(); 
        }

        public void AddCallbacks(IHeroActions instance)
        {
            if (instance == null || m_Wrapper.m_HeroActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HeroActionsCallbackInterfaces.Add(instance);

            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;

            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;

            @Squat.started += instance.OnSquat;
            @Squat.performed += instance.OnSquat;
            @Squat.canceled += instance.OnSquat;

            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
        }

        private void UnregisterCallbacks(IHeroActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;

            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;

            @Squat.started -= instance.OnSquat;
            @Squat.performed -= instance.OnSquat;
            @Squat.canceled -= instance.OnSquat;

            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
        }

        public void RemoveCallbacks(IHeroActions instance)
        {
            if (m_Wrapper.m_HeroActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHeroActions instance)
        {
            foreach (var item in m_Wrapper.m_HeroActionsCallbackInterfaces)
                UnregisterCallbacks(item);

            m_Wrapper.m_HeroActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HeroActions @Hero => new HeroActions(this);

    public interface IHeroActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSquat(InputAction.CallbackContext context);
    }
}
