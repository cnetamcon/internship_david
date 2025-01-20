using Core.Extensions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Core.Test.Extensions
{
    public class ByteExtensionsTest : BaseTest
    {
        [Test]
        public void ReplacePairs_1()
        {
            // Example for bytes.ReplaceParirs method
            
            var bytes = "04 30 40 30 22 78 18 19 20".ToByteArray();

            var dic = new Dictionary<byte[], byte[]>()
            {
                {"30 22".ToByteArray(), "11 11 11".ToByteArray() },
                {"30".ToByteArray(), "22 22 22".ToByteArray() },
            };

            var replaced = bytes.ReplacePairs(dic);
            var controlStr = "04 22 22 22 40 11 11 11 78 18 19 20".Replace(' ', '-');
            var str = replaced.Print();

            Assert.IsTrue(str == controlStr);
        }

        [Test]
        public void ReplacePairs_2()
        {
            // Example for bytes.ReplaceParirs method

            var bytes = "04 30 40 30 22 78 18 19 20 76 77 78 79 AF 30 22 30".ToByteArray();

            var dic = new Dictionary<byte[], byte[]>()
            {
                {"30 22".ToByteArray(), "11 11 11".ToByteArray() },
                {"30".ToByteArray(), "22 22 22".ToByteArray() },
                {"18".ToByteArray(), new byte[0] },
                {"76 77 78 79".ToByteArray(), "BB".ToByteArray() },
            };

            var replaced = bytes.ReplacePairs(dic);
            var controlStr = "04 22 22 22 40 11 11 11 78 19 20 BB AF 11 11 11 22 22 22".Replace(' ', '-');
            var str = replaced.Print();

            Assert.IsTrue(str == controlStr);
        }
    }
}
