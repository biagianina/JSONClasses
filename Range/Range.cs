﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return start <= text[0] && text[0] <= end 
                ? new Match(true, text.Substring(1)) 
                : new Match(false, text);
        }
    }
}
