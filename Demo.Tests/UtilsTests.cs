using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moju.WeChatHelper;

namespace Demo.Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void WeChatRequestVerify()
        {
            string signature = "a13c2b9de6e7d5ccc6e365db2e6c7039fb3fa259";
            string timestamp = "1401950061";
            string nonce = "1129024934";
            string token = "Token";

            bool res = Utils.WeChatRequestVerify(token, timestamp, nonce, signature);

            Assert.AreEqual(true, res);
        }
    }
}
