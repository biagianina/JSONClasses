﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Optional : IPattern
    {
        IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            return new Match(true, match.RemainingText());
        }
    }
}
