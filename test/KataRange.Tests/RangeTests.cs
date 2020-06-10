using NUnit.Framework;

namespace KataRange.Tests
{
    //TDD: Test Driven Development
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void Constructor_With_Valid_Range_Pass()
        {
            Assert.That(() => new Range("[2,4]"), Throws.Nothing);
        }

        [Test]
        public void Constructor_With_Inverted_Range_Throws_ArgumentException()
        {
            Assert.That(() => new Range("[4,2]"), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_With_Negative_Values_Pass()
        {
            Assert.That(() => new Range("[-4,2]"), Throws.Nothing);
        }

        [Test]
        public void Constructor_With_Empty_Range_Throw_ArgumentException()
        {
            Assert.That(() => new Range(""), Throws.ArgumentException);
        }

        [Test]

        public void Zero_To_Four_Contains_One()
        {
            Assert.That(() => new Range("[0,4]").Contains(1), Is.True);
        }

        [Test]

        public void Zero_To_Four_DoesNotContains_Five()
        {
            Assert.That(() => new Range("[0,4]").Contains(5), Is.False);
        }

        [Test]

        public void Zero_To_Four_Contains_One_Two_And_Four()
        {
            Assert.That(() => new Range("[0,4]").Contains(1, 2, 4), Is.True);
        }

        [Test]

        public void Zero_To_Four_DoesNotContains_Zero_Five()
        {
            Assert.That(() => new Range("[0,4]").Contains(0, 5), Is.False);
        }

        [Test]
        public void Zero_To_Four_EndPoints_Are_Zero_And_Four()
        {
            Assert.That(() => new Range("[0,4]").EndPoints(), Is.EqualTo(new int[] { 0, 4 }));
        }

        [Test]
        public void Empty_Range_EndPoints_Throws_ArgumentException()
        {
            Assert.That(() => new Range("").EndPoints(), Throws.ArgumentException);
        }

        [Test]
        public void Two_To_Four_EnPoints_Are_Two_And_Four()
        {
            Assert.That(() => new Range("(1,4]").EndPoints(), Is.EqualTo(new int[] { 2, 4 }));
        }

        [Test]
        public void Inverted_Range_EndPoints_Throws_ArgumentException()
        {
            Assert.That(() => new Range("[8,2]").EndPoints(), Throws.ArgumentException);
        }

        [Test]
        public void Zero_To_Four_ContainsRange_One_To_Three()
        {
            Assert.That(() => new Range("[0,4]").ContainsRange(new Range("[1,3]")), Is.True);
        }

        [Test]
        public void Zero_To_Four_DoesNotContainsRange_One_To_Five()
        {
            Assert.That(() => new Range("[0,4]").ContainsRange(new Range("[1,5]")), Is.False);
        }

        [Test]
        public void Eight_To_Twenty_ContainsRange_Eight_To_Fifteen()
        {
            Assert.That(() => new Range("(7,20]").ContainsRange(new Range("[8, 15]")), Is.True);
        }

        [Test]
        public void Eight_To_Twenty_DoesNotContainsRange_Seven_To_Fifteen()
        {
            Assert.That(() => new Range("(7,20]").ContainsRange(new Range("[7, 15]")), Is.False);
        }

        [Test]
        public void One_To_Three_AllPoints_Are_One_Two_And_Three()
        {
            Assert.That(() => new Range("(0,4)").GetAllPoints(), Is.EqualTo(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void Inverted_Range_AllPoints_Throw_ArgumentException()
        {
            Assert.That(() => new Range("(4,0)").GetAllPoints(), Throws.ArgumentException);
        }

        [Test]
        public void MinusOne_To_Five_AllPoints_Are_MinusOne_Zero_One_Two_Three_Four_And_Five()
        {
            Assert.That(() => new Range("[-1,5]").GetAllPoints(), Is.EqualTo(new int[] { -1, 0, 1, 2, 3, 4, 5 }));
        }

        [Test]
        public void Empty_Range_AllPoints_Throw_ArgumentException()
        {
            Assert.That(() => new Range("").GetAllPoints(), Throws.ArgumentException);
        }

        [Test]
        public void Open_Zero_To_Closed_Two_Equals_Closed_One_To_Closed_Two()
        {
            Assert.That(() => new Range("(0,2]").Equals(new Range("[1,2]")), Is.True);
        }

        [Test]
        public void Open_Zero_To_Closed_Two_DoesNotEquals_Open_One_To_Open_Three()
        {
            Assert.That(() => new Range("(0,2]").Equals(new Range("(1,3)")), Is.False);
        }

        [Test]
        public void Open_Zero_To_Closed_Two_Equals_Closed_One_To_Open_Three()
        {
            Assert.That(() => new Range("(0,2]").Equals(new Range("[1,3)")), Is.True);
        }

        [Test]
        public void Closed_Hundred_To_Closed_Two_Hundred_DoesNotEquals_Closed_Zero_To_Closed_Hundred()
        {
            Assert.That(() => new Range("[100,200]").Equals(new Range("[0,100]")), Is.False);
        }

        [Test]
        public void Zero_To_Four_Overlaps_Three_To_Five()
        {
            Assert.That(() => new Range("[0,4]").OverlapsRange(new Range("[3,5]")), Is.True);
        }

        [Test]
        public void Zero_To_Four_DoesNotOverlaps_Five_To_Ten()
        {
            Assert.That(() => new Range("[0,4]").OverlapsRange(new Range("[5,10]")), Is.False);
        }

        [Test]
        public void MinusTen_To_Four_Overlaps_MinusTwo_To_Five()
        {
            Assert.That(() => new Range("[-10,4]").OverlapsRange(new Range("[-2,5]")), Is.True);
        }

        [Test]
        public void One_To_Three_DoesNotOverlaps_Four_To_Nine()
        {
            Assert.That(() => new Range("(0,4)").OverlapsRange(new Range("[4,10)")), Is.False);
        }



    }
}