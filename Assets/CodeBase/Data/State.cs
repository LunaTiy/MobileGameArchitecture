﻿using System;

namespace CodeBase.Data
{
    [Serializable]
    public class State
    {
        public float currentHp;
        public float maxHp;

        public void ResetHp() => currentHp = maxHp;
    }
}