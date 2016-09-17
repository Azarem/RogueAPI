using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    public static class InputManager
    {
        //private static uint _lastInputFlags;
        private static InputFlags _currentInputFlags;
        private static InputFlags _newInputFlags;

        private static InputKeys?[] _buttonMap = new InputKeys?[31];
        private static Dictionary<Keys, InputKeys> _keyMap = new Dictionary<Keys, InputKeys>();
        private static List<ThumbStickMap> _stickMap = new List<ThumbStickMap>();

        public static InputFlags PressedFlags { get { return _currentInputFlags; } }
        public static InputFlags NewlyPressedFlags { get { return _newInputFlags; } }

        public static float ThumbstickDeadzone;

        public static bool IsGamepadConnected()
        {
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return true;

            //Need to add support for DirectInput?
            return false;
        }

        public static void MapButton(Buttons button, InputKeys? input)
        {
            int bitRail = (int)button;
            int index = -1;

            while (bitRail > 0 && (bitRail & 1) == 0)
            {
                bitRail >>= 1;
                index++;
            }

            if (index >= 0)
                _buttonMap[index] = input;
        }

        public static void MapKey(Keys key, InputKeys? input)
        {
            if (input == null)
            {
                if (_keyMap.ContainsKey(key))
                    _keyMap.Remove(key);
            }
            else
                _keyMap[key] = input.Value;
        }

        public static void MapStick(InputKeys key, ThumbStick stick, float direction, float hysteresis)
        {
            _stickMap.Add(new ThumbStickMap() { Key = key, ThumbStick = stick, Hysteresis = hysteresis, Direction = direction });
        }

        public static Buttons GetMappedButton(InputKeys key)
        {
            int index = -1;
            int length = _buttonMap.Length;
            while (++index < length)
            {
                if (key == _buttonMap[index])
                    return (Buttons)(1 << index);
            }

            return 0;
        }

        public static Keys GetMappedKey(InputKeys key)
        {
            foreach (var k in _keyMap)
                if (k.Value == key)
                    return k.Key;
            return 0;
        }

        public static void Update()
        {
            var last = _currentInputFlags;
            _currentInputFlags = GetKeyFlags();

            var state = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            if (state != null && state.IsConnected)
            {
                _currentInputFlags |= GetButtonFlags(state);
                _currentInputFlags |= GetStickFlags(state);
            }

            _newInputFlags = ~last & _currentInputFlags;
        }

        public static void ClearAll()
        {
            int i = 0, length = _buttonMap.Length;
            while (i < length)
                _buttonMap[i++] = null;

            _keyMap.Clear();
            _stickMap.Clear();
        }

        private static InputFlags GetKeyFlags()
        {
            int keyFlags = 0;

            var state = Keyboard.GetState(PlayerIndex.One);
            foreach (var k in state.GetPressedKeys())
            {
                InputKeys inputKey;
                if (_keyMap.TryGetValue(k, out inputKey))
                    keyFlags |= 1 << (int)inputKey;
            }

            return (InputFlags)keyFlags;
        }

        private static InputFlags GetStickFlags(GamePadState state)
        {
            int keyFlags = 0;

            foreach (var m in _stickMap)
            {
                var pos = m.ThumbStick == ThumbStick.Left
                    ? state.ThumbSticks.Left
                    : state.ThumbSticks.Right;

                if (!ShouldIgnoreThumbstick(pos))
                {
                    float degrees = -MathHelper.ToDegrees((float)Math.Atan2(pos.Y, pos.X));
                    if (degrees > m.Direction - m.Hysteresis && degrees < m.Direction + m.Hysteresis)
                        keyFlags |= 1 << (int)m.Key;
                }
            }

            return (InputFlags)keyFlags;
        }

        private static InputFlags GetButtonFlags(GamePadState state)
        {
            int keyFlags = 0;

            Buttons buttonFlags = 0;

            var buttons = state.Buttons;
            if (buttons.A == ButtonState.Pressed)
                buttonFlags |= Buttons.A;
            if (buttons.B == ButtonState.Pressed)
                buttonFlags |= Buttons.B;
            if (buttons.Back == ButtonState.Pressed)
                buttonFlags |= Buttons.Back;
            if (buttons.BigButton == ButtonState.Pressed)
                buttonFlags |= Buttons.BigButton;
            if (buttons.LeftShoulder == ButtonState.Pressed)
                buttonFlags |= Buttons.LeftShoulder;
            if (buttons.LeftStick == ButtonState.Pressed)
                buttonFlags |= Buttons.LeftStick;
            if (buttons.RightShoulder == ButtonState.Pressed)
                buttonFlags |= Buttons.RightShoulder;
            if (buttons.RightStick == ButtonState.Pressed)
                buttonFlags |= Buttons.RightStick;
            if (buttons.Start == ButtonState.Pressed)
                buttonFlags |= Buttons.Start;
            if (buttons.X == ButtonState.Pressed)
                buttonFlags |= Buttons.X;
            if (buttons.Y == ButtonState.Pressed)
                buttonFlags |= Buttons.Y;

            var dpad = state.DPad;
            if (dpad.Up == ButtonState.Pressed)
                buttonFlags |= Buttons.DPadUp;
            if (dpad.Down == ButtonState.Pressed)
                buttonFlags |= Buttons.DPadDown;
            if (dpad.Left == ButtonState.Pressed)
                buttonFlags |= Buttons.DPadLeft;
            if (dpad.Right == ButtonState.Pressed)
                buttonFlags |= Buttons.DPadRight;

            var thumb = state.ThumbSticks;

            if (!ShouldIgnoreThumbstick(thumb.Left))
            {
                var leftStick = ApplyStickDeadZone(thumb.Left, 0.24f);

                if (leftStick.X < 0f)
                    buttonFlags |= Buttons.LeftThumbstickLeft;
                else if (leftStick.X > 0f)
                    buttonFlags |= Buttons.LeftThumbstickRight;
                if (leftStick.Y < 0f)
                    buttonFlags |= Buttons.LeftThumbstickDown;
                else if (leftStick.Y > 0f)
                    buttonFlags |= Buttons.LeftThumbstickUp;
            }

            if (!ShouldIgnoreThumbstick(thumb.Right))
            {
                var rightStick = ApplyStickDeadZone(thumb.Right, 0.265f);

                if (rightStick.X < 0f)
                    buttonFlags |= Buttons.RightThumbstickLeft;
                else if (rightStick.X > 0f)
                    buttonFlags |= Buttons.RightThumbstickRight;
                if (rightStick.Y < 0f)
                    buttonFlags |= Buttons.RightThumbstickDown;
                else if (rightStick.Y > 0f)
                    buttonFlags |= Buttons.RightThumbstickUp;
            }

            int bitRail = (int)buttonFlags;
            int index = 0;
            while (bitRail > 0)
            {
                if ((bitRail & 1) != 0)
                {
                    var key = _buttonMap[index];
                    if (key != null)
                        keyFlags |= 1 << (int)key.Value;
                }
                bitRail >>= 1;
                index++;
            }

            return (InputFlags)keyFlags;
        }

        private static Vector2 ApplyStickDeadZone(Vector2 pos, float deadZoneSize)
        {
            return new Vector2(ApplyLinearDeadZone(pos.X, 1f, deadZoneSize), ApplyLinearDeadZone(pos.Y, 1f, deadZoneSize));
        }

        private static float ApplyLinearDeadZone(float value, float maxValue, float deadZoneSize)
        {
            if (value >= -deadZoneSize)
            {
                if (value <= deadZoneSize)
                    return 0f;

                value = value - deadZoneSize;
            }
            else
                value = value + deadZoneSize;

            return MathHelper.Clamp(value / (maxValue - deadZoneSize), -1f, 1f);
        }

        public static bool ShouldIgnoreThumbstick(Vector2 pos)
        {
            float percent = ThumbstickDeadzone / 100f;
            return percent > 0f && ((pos.X * pos.X) + (pos.Y * pos.Y) < (percent * percent));
        }

        public static bool IsPressed(InputKeys key)
        {
            return ((1 << (int)key) & (int)_currentInputFlags) != 0;
        }

        public static bool IsPressed(InputFlags flags)
        {
            return (_currentInputFlags & flags) != InputFlags.None;
        }
        public static bool IsPressedAll(InputFlags flags)
        {
            return (_currentInputFlags & flags) == flags;
        }

        public static bool IsPressedOr(params InputKeys[] keys)
        {
            foreach (var k in keys)
                if (((1 << (int)k) & (int)_currentInputFlags) != 0)
                    return true;
            return false;
        }

        public static bool IsNewlyPressed(InputKeys key)
        {
            return ((1 << (int)key) & (int)_newInputFlags) != 0;
        }

        public static bool IsNewlyPressedOr(params InputKeys[] keys)
        {
            foreach (var k in keys)
                if (((1 << (int)k) & (int)_newInputFlags) != 0)
                    return true;
            return false;
        }

        public static bool IsNewlyPressed(InputFlags flags)
        {
            return (_newInputFlags & flags) != InputFlags.None;
        }
        public static bool IsNewlyPressedAll(InputFlags flags)
        {
            return (_newInputFlags & flags) == flags;
        }

    }

    public enum ThumbStick
    {
        Left,
        Right
    }

    public class ThumbStickMap
    {
        public ThumbStick ThumbStick;
        public float Direction;
        public float Hysteresis;
        public InputKeys Key;
    }
}
