using System;

namespace OOP004Exceptions
{
    class Gearbox
    {
        public Gearbox()
        {

        }
        private int _Gear = 1;
        public int Gear
        {
            get => _Gear;
            private set
            {
                switch (value)
                {
                    case -1:
                        if (_Gear == 1)
                        {
                            _Gear = value;
                            return;
                        }
                        else break;
                    case 1:
                        if (_Gear == -1 || _Gear == 2)
                        {
                            _Gear = value;
                            return;
                        }
                        else break;
                    case 2:
                        if (_Gear == 1 || _Gear == 3)
                        {
                            _Gear = value;
                            return;
                        }
                        else break;
                    case 3:
                        if (_Gear == 2 || _Gear == 4)
                        {
                            _Gear = value;
                            return;
                        }
                        else break;
                    case 4:
                        if (_Gear == 3 || _Gear == 5)
                        {
                            _Gear = value;
                            return;
                        }
                        else break;
                    case 5:
                        if (_Gear == 4)
                        {
                            _Gear = value;
                            return;
                        }
                        else break;
                    default:
                        break;

                }
                throw new IllegalGearChangeException();
            }
        }
        public void ChangeGear(int gear)
        {
            switch (gear)
            {
                case -1:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Gear = gear;
                    break;
                default:
                    throw new ArgumentException("Gear has to be -1,1,2,3,4 or 5");
            }
        }
    }
}

