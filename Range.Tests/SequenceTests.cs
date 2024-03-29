﻿using System;
using Xunit;

namespace Classes.Tests
{
    public class SequenceTests
    {
        [Fact]
        public void ReturnsFalseAndEmptyForAnEmptyString()
        {
            var sequence = new Sequence(
                new Character('a')
                );
            Assert.False(sequence.Match("").Success());
            Assert.Equal("", sequence.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForMatchingChars()
        {
            var ab = new Sequence(
            new Character('a'),
            new Character('b')
            );
            Assert.True(ab.Match("abcd").Success());
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void ReturnsFalseForNotMatchingChars()
        {
            var ab = new Sequence(
            new Character('a'),
            new Character('b')
            );
            Assert.False(ab.Match("ax").Success());
            Assert.Equal("ax", ab.Match("ax").RemainingText());
        }


        [Fact]
        public void ReturnsTrueForThreeMatchingChars()
        {
            var abc = new Sequence(
            new Character('a'),
            new Character('b'),
            new Character('c')
            );

            Assert.True(abc.Match("abcd").Success());
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }


        [Fact]
        public void ReturnsFalseForThreeUnmatchingMatchingChars()
        {
            var ab = new Sequence(
            new Character('a'),
            new Character('b'));

            var abc = new Sequence(
                ab,
            new Character('c')
            );

            Assert.False(abc.Match("def").Success());
            Assert.Equal("def", abc.Match("def").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForCorrectUnicode()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            Assert.True(hexSq.Match("u1234").Success());
            Assert.Equal("", hexSq.Match("u1234").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForCorrectUnicodeInAString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            Assert.True(hexSq.Match("uabcdef").Success());
            Assert.Equal("ef", hexSq.Match("uabcdef").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForCorrectUnicodeInAStringWithSpace()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            Assert.True(hexSq.Match("uB005 ab").Success());
            Assert.Equal(" ab", hexSq.Match("uB005 ab").RemainingText());
        }
    }
}
