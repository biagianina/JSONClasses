﻿using System;
using Xunit;

namespace Classes.Tests
{
    public class ListTests
    {
        [Fact]
        public void ReturnsTrueAndEmptyForEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }
       
        [Fact]
        public void ReturnsTrueAndEmptyForCorrectString()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("1,2,3").Success());
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForCorrectString()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("1,2,3,").Success());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForStringWithoutSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndEmptyForStringWithAll()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForStringWithAll()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1 \n;").Success());
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());
        }
    }
}
