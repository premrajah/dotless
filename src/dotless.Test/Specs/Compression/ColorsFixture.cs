namespace dotless.Test.Specs.Compression
{
    using NUnit.Framework;

    public class ColorsFixture : CompressedSpecFixtureBase
    {
        [Test]
        public void Colors()
        {
            AssertExpressionUnchanged("#ffeeaa"); // colors remain unchanged if not part of an expression
            AssertExpression("#fea", "#ffeeaa + 0");
            AssertExpression("blue", "#0000ff + 0");
        }
        
        [Test]
        public void Overflow()
        {
            AssertExpression("#000", "#111111 - #444444");
            AssertExpression("#fff", "#eee + #fff");
            AssertExpression("#fff", "#aaa * 3");
            AssertExpression("lime", "#00ee00 + #009900");
            AssertExpression("red", "#ee0000 + #990000");
        }

        [Test]
        public void Gray()
        {
            AssertExpression("#888", "rgb(136, 136, 136)");
            AssertExpression("gray", "hsl(50, 0, 50)");
        }
    }
}