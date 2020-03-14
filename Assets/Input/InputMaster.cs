// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d567e582-8787-4062-ae39-6305dce63abf"",
            ""actions"": [
                {
                    ""name"": ""Accelerate Press"",
                    ""type"": ""Button"",
                    ""id"": ""95ee71e1-3707-4ec0-8c41-9d2d4c2f49b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Accelerate Release"",
                    ""type"": ""Button"",
                    ""id"": ""0b8f2a22-f499-47eb-a8fa-c9cd5bae4d6c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Brake Press"",
                    ""type"": ""Button"",
                    ""id"": ""5eae4dcd-7762-4d71-ac83-a381bcf68463"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Brake Release"",
                    ""type"": ""Button"",
                    ""id"": ""1d034e65-ca2b-4043-bf77-55cd3748f649"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Jump Press"",
                    ""type"": ""Button"",
                    ""id"": ""1f0f52fb-16d1-40cf-8365-761c9b09d8a1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump Release"",
                    ""type"": ""Button"",
                    ""id"": ""e753c680-6c1a-49ed-9f3c-91c4159b2e15"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Drift Press"",
                    ""type"": ""Button"",
                    ""id"": ""faf990a4-3800-49eb-896c-54ae14261e88"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Drift Release"",
                    ""type"": ""Button"",
                    ""id"": ""cab18a7e-63c1-4785-9f3b-2d450688d2a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Button"",
                    ""id"": ""96e81ea5-1edc-4636-924a-234c69a2dfdd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f245f4ac-26bc-4bc4-9888-3f18e041c02d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0afa7a72-4c02-49b7-8525-efd7cf538df0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61ad52e3-8770-42fa-8f4f-eba8e37fad31"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f03d996-f439-4a6d-8c30-19117c01f0d0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccc284c4-70dd-41d1-a9f2-260b94d18446"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Brake Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2df3e0a5-033e-4b41-a64d-702f1e7724da"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Brake Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d8d0d9e-22e9-42c7-a57c-d7796fa89c65"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Brake Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c351a37c-5494-48e7-99fd-568a5d3f7d2b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Brake Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb39dd26-1fce-4dd2-a2fa-877e2d176efe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4243f14f-8641-4c8c-80f9-33c4aa337714"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03802516-b6cc-4676-bde0-c90a50f872d1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e371da64-99aa-42e8-b6d6-af28db62dd33"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b7aad68-352a-4240-a76e-491d3a59294c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Drift Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a63c214e-ad84-4e0b-8e96-35b015cbf74f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Drift Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a041019-f95d-4e1f-90e1-8d9dadb27d15"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Drift Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""946167f2-ad99-4383-8f89-e93dfe0958b6"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Drift Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""751ef62b-9a43-4610-be08-bd9779d79efd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""392c7b53-07e2-4997-ae10-9fec71ec73e0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f384d516-f59b-4b5a-8e90-0c7047fd6af0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LAnalogStick"",
                    ""id"": ""7a89f8b5-17d9-48f3-84a0-9b519e789c2b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8f26f378-d6f7-4302-bf20-5b674e7d55a5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""276b2c4c-6950-4f88-b9ff-5eb8db564f31"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_AcceleratePress = m_Player.FindAction("Accelerate Press", throwIfNotFound: true);
        m_Player_AccelerateRelease = m_Player.FindAction("Accelerate Release", throwIfNotFound: true);
        m_Player_BrakePress = m_Player.FindAction("Brake Press", throwIfNotFound: true);
        m_Player_BrakeRelease = m_Player.FindAction("Brake Release", throwIfNotFound: true);
        m_Player_JumpPress = m_Player.FindAction("Jump Press", throwIfNotFound: true);
        m_Player_JumpRelease = m_Player.FindAction("Jump Release", throwIfNotFound: true);
        m_Player_DriftPress = m_Player.FindAction("Drift Press", throwIfNotFound: true);
        m_Player_DriftRelease = m_Player.FindAction("Drift Release", throwIfNotFound: true);
        m_Player_Steering = m_Player.FindAction("Steering", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_AcceleratePress;
    private readonly InputAction m_Player_AccelerateRelease;
    private readonly InputAction m_Player_BrakePress;
    private readonly InputAction m_Player_BrakeRelease;
    private readonly InputAction m_Player_JumpPress;
    private readonly InputAction m_Player_JumpRelease;
    private readonly InputAction m_Player_DriftPress;
    private readonly InputAction m_Player_DriftRelease;
    private readonly InputAction m_Player_Steering;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @AcceleratePress => m_Wrapper.m_Player_AcceleratePress;
        public InputAction @AccelerateRelease => m_Wrapper.m_Player_AccelerateRelease;
        public InputAction @BrakePress => m_Wrapper.m_Player_BrakePress;
        public InputAction @BrakeRelease => m_Wrapper.m_Player_BrakeRelease;
        public InputAction @JumpPress => m_Wrapper.m_Player_JumpPress;
        public InputAction @JumpRelease => m_Wrapper.m_Player_JumpRelease;
        public InputAction @DriftPress => m_Wrapper.m_Player_DriftPress;
        public InputAction @DriftRelease => m_Wrapper.m_Player_DriftRelease;
        public InputAction @Steering => m_Wrapper.m_Player_Steering;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @AcceleratePress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleratePress;
                @AcceleratePress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleratePress;
                @AcceleratePress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleratePress;
                @AccelerateRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerateRelease;
                @AccelerateRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerateRelease;
                @AccelerateRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerateRelease;
                @BrakePress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrakePress;
                @BrakePress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrakePress;
                @BrakePress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrakePress;
                @BrakeRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrakeRelease;
                @BrakeRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrakeRelease;
                @BrakeRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrakeRelease;
                @JumpPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPress;
                @JumpPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPress;
                @JumpPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPress;
                @JumpRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpRelease;
                @DriftPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDriftPress;
                @DriftPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDriftPress;
                @DriftPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDriftPress;
                @DriftRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDriftRelease;
                @DriftRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDriftRelease;
                @DriftRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDriftRelease;
                @Steering.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSteering;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AcceleratePress.started += instance.OnAcceleratePress;
                @AcceleratePress.performed += instance.OnAcceleratePress;
                @AcceleratePress.canceled += instance.OnAcceleratePress;
                @AccelerateRelease.started += instance.OnAccelerateRelease;
                @AccelerateRelease.performed += instance.OnAccelerateRelease;
                @AccelerateRelease.canceled += instance.OnAccelerateRelease;
                @BrakePress.started += instance.OnBrakePress;
                @BrakePress.performed += instance.OnBrakePress;
                @BrakePress.canceled += instance.OnBrakePress;
                @BrakeRelease.started += instance.OnBrakeRelease;
                @BrakeRelease.performed += instance.OnBrakeRelease;
                @BrakeRelease.canceled += instance.OnBrakeRelease;
                @JumpPress.started += instance.OnJumpPress;
                @JumpPress.performed += instance.OnJumpPress;
                @JumpPress.canceled += instance.OnJumpPress;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
                @DriftPress.started += instance.OnDriftPress;
                @DriftPress.performed += instance.OnDriftPress;
                @DriftPress.canceled += instance.OnDriftPress;
                @DriftRelease.started += instance.OnDriftRelease;
                @DriftRelease.performed += instance.OnDriftRelease;
                @DriftRelease.canceled += instance.OnDriftRelease;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnAcceleratePress(InputAction.CallbackContext context);
        void OnAccelerateRelease(InputAction.CallbackContext context);
        void OnBrakePress(InputAction.CallbackContext context);
        void OnBrakeRelease(InputAction.CallbackContext context);
        void OnJumpPress(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnDriftPress(InputAction.CallbackContext context);
        void OnDriftRelease(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
    }
}
