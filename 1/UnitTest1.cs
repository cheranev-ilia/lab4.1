using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNum;

namespace lab3Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void RomanNumberTest()
        {
            RomanNumber rNum1 = new RomanNumber(100);
            RomanNumber rNum2;
            bool isExep = true;
            string expected = "C";

            Assert.AreEqual(expected, rNum1.ToString());
            try
            {
                rNum2 = new RomanNumber(0);
                isExep = false;
            }
            catch (RomanNumberException) { }
            finally
            {
                if (!isExep)
                    Assert.Fail();
                isExep = true;
            }

            try
            {
                rNum2 = new RomanNumber(4000);
                isExep = false;
            }
            catch (RomanNumberException) { }
            finally
            {
                if (!isExep)
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void ToStringTest()
        {
            RomanNumber rNum1 = new RomanNumber(594);
            RomanNumber rNum2 = new RomanNumber(813);

            Assert.AreEqual("DXCIV", rNum1.ToString());
            Assert.AreEqual("DCCCXIII", rNum2.ToString());
        }

        [TestMethod]
        public void AddTest()
        {
            RomanNumber rNum1 = new RomanNumber(10);
            RomanNumber rNum2 = new RomanNumber(22);
            RomanNumber rNum3 = new RomanNumber(3990);
            string expected = "XXXII";

            Assert.ThrowsException<RomanNumberException>(() => RomanNumber.Add(rNum1, rNum3));
            Assert.AreEqual(expected, (rNum1 + rNum2).ToString());
        }

        [TestMethod]
        public void SubTest()
        {
            RomanNumber rNum1 = new RomanNumber(10);
            RomanNumber rNum2 = new RomanNumber(22);
            string expected = "XII";
            Assert.ThrowsException<RomanNumberException>(() => RomanNumber.Sub(rNum1, rNum2));
            Assert.AreEqual(expected, (rNum2 - rNum1).ToString());
        }

        [TestMethod]
        public void MulTest()
        {
            RomanNumber rNum1 = new RomanNumber(10);
            RomanNumber rNum2 = new RomanNumber(22);
            RomanNumber rNum3 = new RomanNumber(200);
            string expected = "CCXX";
            Assert.ThrowsException<RomanNumberException>(() => RomanNumber.Mul(rNum2, rNum3));
            Assert.AreEqual(expected, (rNum1 * rNum2).ToString());
        }

        [TestMethod]
        public void DivTest()
        {
            RomanNumber rNum1 = new RomanNumber(320);
            RomanNumber rNum2 = new RomanNumber(10);
            string expected = "XXXII";
            Assert.ThrowsException<RomanNumberException>(() => RomanNumber.Div(rNum2, rNum1));
            Assert.AreEqual(expected, (rNum1 / rNum2).ToString());
        }

        [TestMethod]
        public void CloneTest()
        {
            RomanNumber rNum1 = new RomanNumber(25);
            RomanNumber rNum2 = (RomanNumber)rNum1.Clone();
            rNum1 = rNum1 + rNum1;
            string expected1 = "XXV";
            string expected2 = "L";
            Assert.AreEqual(expected1, (rNum2).ToString());
            Assert.AreEqual(expected2, (rNum1).ToString());
        }

        [TestMethod]
        public void CompareTest()
        {
            int a = 128, b = 421;
            RomanNumber rNum1 = new RomanNumber((ushort)a);
            RomanNumber rNum2 = new RomanNumber((ushort)b);

            Assert.AreEqual(a - b, rNum1.CompareTo(rNum2));
            Assert.AreEqual(b - a, rNum2.CompareTo(rNum1));
            Assert.AreEqual(0, rNum1.CompareTo(rNum1));
        }

        [TestMethod]
        public void RomanNumberExtendTest()
        {
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumberExtend("IIX"));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumberExtend("asd"));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumberExtend("IIII"));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumberExtend("IM"));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumberExtend("VL"));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumberExtend("VIV"));

            Assert.AreEqual("LV", (new RomanNumberExtend("LV").ToString()));
            Assert.AreEqual("IX", (new RomanNumberExtend("IX").ToString()));
            Assert.AreEqual("MMI", (new RomanNumberExtend("MMI").ToString()));
            Assert.AreEqual("IV", (new RomanNumberExtend("IV").ToString()));
        }
    }
}