using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputReader
{
    public class AirconsoleController : InputReaderKey
    {
        public AirconsoleController(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode roll, KeyCode attack)
        {
            _interactKey = interact;
            _jumpKey = jump;
            _rollKey = roll;
            _attackKey = attack;
            _xAxis = xAxis;
            _yAxis = yAxis;
        }
        protected bool _OnInteract;
        protected bool _Interacting;
        protected bool _OffInteract;
        protected bool _OnJump;
        protected bool _Jumping;
        protected bool _OffJump;
        protected bool _OnRoll;
        protected bool _Rolling;
        protected bool _OffRoll;
        protected bool _OnAttack;
        protected bool _Attacking;
        protected bool _OffAttack;

        public override bool OnInteract
        {
            get
            {
                if(_OnInteract)
                    _Interacting = true;
                bool toret = _OnInteract;
                _OnInteract = false;
                return toret;
            }
        }

        public override bool Interacting => _Interacting;

        public override bool OffInteract
        {
            get
            {
                bool toret = _OffInteract;
                _OffInteract = false;
                return toret;
            }
        }

        public override bool OnJump 
        {
            get
            {
                if (_OnJump)
                    _Jumping = true;
                bool toret = _OnJump;
                _OnJump = false;
                return toret;
            }
        }

        public override bool Jumping => _Jumping;

        public override bool OffJump
        { 
            get
            {
                bool toret = _OffJump;
                _OffJump = false;
                return toret;
            }
        }

        public override bool OnRoll
        {
            get
            {
                if (_OnRoll)
                    _Rolling = true;
                bool toret = _OnRoll;
                _OnRoll = false;
                return toret;
            }
        }

        public override bool Rooling => _Rolling;

        public override bool OffRool
        {
            get
            {
                bool toret = _OffRoll;
                _OffRoll = false;
                return toret;
            }
        }

        public override bool OnAttack
        {
            get
            {
                if (_OnAttack)
                    _Attacking = true;
                bool toret = _OnAttack;
                _OnAttack = false;
                return toret;
            }
        }

        public override bool Attacking => _Attacking;

        public override bool OffAttack
        {
            get
            {
                bool toret = _OffAttack;
                _OffAttack = false;
                return toret;
            }
        }

        public override void ButtonInput()
        {
            {
                if (Input.GetKeyDown(_jumpKey))
                {
                    _OnJump = true;
                    _Jumping = true;
                }
                if (Input.GetKeyUp(_jumpKey))
                {
                    _OffJump = true;
                    _OnJump = false;
                    _Jumping = false;
                }
            }
            
            {
                if (Input.GetKeyDown(_interactKey))
                {
                    _OnInteract = true;
                    _OffInteract = false;
                }
                if (Input.GetKeyUp(_interactKey))
                {
                    _OnInteract = false;
                    _Interacting = false;
                    _OffInteract = true;
                }
            }

            {
                if (Input.GetKeyDown(_rollKey))
                {
                    _OnRoll = true;
                    _OffRoll = false;
                }
                if (Input.GetKeyUp(_rollKey))
                {
                    _OnRoll = false;
                    _OffRoll = true;
                    _Rolling = false;
                }
            }

            {
                if (Input.GetKeyDown(_attackKey))
                {
                    _OnAttack = true;
                    _OffAttack = false;
                }
                if (Input.GetKeyUp(_attackKey))
                {
                    _OnAttack = false;
                    _OffAttack = true;
                    _Attacking = false;
                }
            }

        }
        

    }
}