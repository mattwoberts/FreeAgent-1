using FreeAgent.Helpers;
using NUnit.Framework;
using System.Runtime.Serialization;

namespace FreeAgent.Tests
{

    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void Enum_Helper_Returns_EnumMember_Value()
        {
            var input = TestEnum.Test1;

            var result = input.GetMemberValue();

            Assert.AreEqual("test_value", result);
        }

        [Test]
        public void Enum_Helper_Returns_DefaultEnum_Value()
        {
            var input = TestEnum.Test2;

            var result = input.GetMemberValue();

            Assert.AreEqual("Test2", result);
        }

        [Test]
        public void Enum_Helper_Returns_Null_EnumMember_Value()
        {
            var input = TestEnum.Test3;

            var result = input.GetMemberValue();

            Assert.IsNull(result);
        }

        public enum TestEnum
        {
            [EnumMember(Value = "test_value")] Test1,
            Test2,
            [EnumMember(Value = null)] Test3
        }
    }
}
