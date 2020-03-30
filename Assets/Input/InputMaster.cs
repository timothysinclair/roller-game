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
                    ""name"": ""Boost Press"",
                    ""type"": ""Button"",
                    ""id"": ""95ee71e1-3707-4ec0-8c41-9d2d4c2f49b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Boost Release"",
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
                    ""name"": ""Accelerate Press"",
                    ""type"": ""Button"",
                    ""id"": ""62bb67e8-70bb-4dae-b180-88266afb372f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Accelerate Release"",
                    ""type"": ""Button"",
                    ""id"": ""10b9b3d9-c9e6-41fc-9f61-6a98baf41194"",
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
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bbbb003e-da35-4d79-8a4a-dfe54f121f0a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Grind"",
                    ""type"": ""Button"",
                    ""id"": ""abbe21cd-5352-456f-9c08-ec8372199ac9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a9ad3b64-0be1-4e48-a226-d16949e69f79"",
                    ""expectedControlType"": ""Vector2"",
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
                    ""action"": ""Boost Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0afa7a72-4c02-49b7-8525-efd7cf538df0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Boost Press"",
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
                    ""action"": ""Boost Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f03d996-f439-4a6d-8c30-19117c01f0d0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Boost Release"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""10f7b585-48a7-4211-9fc2-2b086ff415c3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03a76162-581e-492c-a9d6-51176ed9f83b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6371aa61-bd9b-414b-a79b-706b7d4bb0ef"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Grind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28a79317-c560-4fff-97b7-c2258dc7196b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Grind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2976514b-bdb8-4f1c-a5cc-dc086074be1e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ced0d8a5-f4fc-4f3f-85f7-8afabc9ae7d3"",
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
                    ""id"": ""70ca53fd-ed08-4202-b9ef-609c8c03a65f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30695460-bbe3-45d7-b514-26d33a2c3ca5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a279c409-6d4f-4b68-bb62-fbd90ffbe925"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.4,max=1)"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ecdc65fd-9196-4435-8522-0904e0b81bcd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""44249549-3d69-46d1-ad82-16fe18980d07"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f4a14fc-076e-4095-9042-d9917f5da66e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""031f3fd8-db5d-4ce2-9fef-da4694255173"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c9ba5aec-5491-46ac-aa60-361b237c0c5e"",
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
                    ""id"": ""195a9762-d358-456d-8869-66225d543c90"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ef5cb4b5-4483-4ce2-ac91-050b49157129"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""45341b50-0500-4275-af81-8211b46c7f00"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""46be18dd-04a3-4d8e-9819-432922ff56e5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
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
                },
                {
                    ""devicePath"": ""<Mouse>"",
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
        m_Player_BoostPress = m_Player.FindAction("Boost Press", throwIfNotFound: true);
        m_Player_BoostRelease = m_Player.FindAction("Boost Release", throwIfNotFound: true);
        m_Player_BrakePress = m_Player.FindAction("Brake Press", throwIfNotFound: true);
        m_Player_BrakeRelease = m_Player.FindAction("Brake Release", throwIfNotFound: true);
        m_Player_JumpPress = m_Player.FindAction("Jump Press", throwIfNotFound: true);
        m_Player_JumpRelease = m_Player.FindAction("Jump Release", throwIfNotFound: true);
        m_Player_DriftPress = m_Player.FindAction("Drift Press", throwIfNotFound: true);
        m_Player_DriftRelease = m_Player.FindAction("Drift Release", throwIfNotFound: true);
        m_Player_AcceleratePress = m_Player.FindAction("Accelerate Press", throwIfNotFound: true);
        m_Player_AccelerateRelease = m_Player.FindAction("Accelerate Release", throwIfNotFound: true);
        m_Player_Steering = m_Player.FindAction("Steering", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Grind = m_Player.FindAction("Grind", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
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
    private readonly InputAction m_Player_BoostPress;
    private readonly InputAction m_Player_BoostRelease;
    private readonly InputAction m_Player_BrakePress;
    private readonly InputAction m_Player_BrakeRelease;
    private readonly InputAction m_Player_JumpPress;
    private readonly InputAction m_Player_JumpRelease;
    private readonly InputAction m_Player_DriftPress;
    private readonly InputAction m_Player_DriftRelease;
    private readonly InputAction m_Player_AcceleratePress;
    private readonly InputAction m_Player_AccelerateRelease;
    private readonly InputAction m_Player_Steering;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Grind;
    private readonly InputAction m_Player_Movement;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @BoostPress => m_Wrapper.m_Player_BoostPress;
        public InputAction @BoostRelease => m_Wrapper.m_Player_BoostRelease;
        public InputAction @BrakePress => m_Wrapper.m_Player_BrakePress;
        public InputAction @BrakeRelease => m_Wrapper.m_Player_BrakeRelease;
        public InputAction @JumpPress => m_Wrapper.m_Player_JumpPress;
        public InputAction @JumpRelease => m_Wrapper.m_Player_JumpRelease;
        public InputAction @DriftPress => m_Wrapper.m_Player_DriftPress;
        public InputAction @DriftRelease => m_Wrapper.m_Player_DriftRelease;
        public InputAction @AcceleratePress => m_Wrapper.m_Player_AcceleratePress;
        public InputAction @AccelerateRelease => m_Wrapper.m_Player_AccelerateRelease;
        public InputAction @Steering => m_Wrapper.m_Player_Steering;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Grind => m_Wrapper.m_Player_Grind;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @BoostPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostPress;
                @BoostPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostPress;
                @BoostPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostPress;
                @BoostRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostRelease;
                @BoostRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostRelease;
                @BoostRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostRelease;
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
                @AcceleratePress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleratePress;
                @AcceleratePress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleratePress;
                @AcceleratePress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleratePress;
                @AccelerateRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerateRelease;
                @AccelerateRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerateRelease;
                @AccelerateRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerateRelease;
                @Steering.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSteering;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Grind.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrind;
                @Grind.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrind;
                @Grind.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrind;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BoostPress.started += instance.OnBoostPress;
                @BoostPress.performed += instance.OnBoostPress;
                @BoostPress.canceled += instance.OnBoostPress;
                @BoostRelease.started += instance.OnBoostRelease;
                @BoostRelease.performed += instance.OnBoostRelease;
                @BoostRelease.canceled += instance.OnBoostRelease;
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
                @AcceleratePress.started += instance.OnAcceleratePress;
                @AcceleratePress.performed += instance.OnAcceleratePress;
                @AcceleratePress.canceled += instance.OnAcceleratePress;
                @AccelerateRelease.started += instance.OnAccelerateRelease;
                @AccelerateRelease.performed += instance.OnAccelerateRelease;
                @AccelerateRelease.canceled += instance.OnAccelerateRelease;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Grind.started += instance.OnGrind;
                @Grind.performed += instance.OnGrind;
                @Grind.canceled += instance.OnGrind;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
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
        void OnBoostPress(InputAction.CallbackContext context);
        void OnBoostRelease(InputAction.CallbackContext context);
        void OnBrakePress(InputAction.CallbackContext context);
        void OnBrakeRelease(InputAction.CallbackContext context);
        void OnJumpPress(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnDriftPress(InputAction.CallbackContext context);
        void OnDriftRelease(InputAction.CallbackContext context);
        void OnAcceleratePress(InputAction.CallbackContext context);
        void OnAccelerateRelease(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnGrind(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
