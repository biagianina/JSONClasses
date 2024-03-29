﻿using System;
using Xunit;

namespace Classes.Tests
{
    public class AnyTests
    {
        [Fact]
        public void ReturnsFalseAndEmptyForEmptyString()
        {
            var e = new Any("eE");
            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueAndRemainingForShortString()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void ReturnsFalseAndTextForShortString()
        {
            var e = new Any("eE");
            Assert.False(e.Match("a").Success());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void ReturnsCorrectStringForSignString()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match("+3").Success());
            Assert.Equal("3", sign.Match("+3").RemainingText());
        }

        [Fact]
        public void ReturnsCorrectForIncorrectSignString()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match("2").Success());
            Assert.Equal("2", sign.Match("2").RemainingText());
        }
    }
}
