using Xunit;

namespace PersianTools.Test
{
    public class EnToFaDigitTest
    {
        public EnToFaDigitTest()
        {

        }
        [Fact]
        public void Test1()
        {
            int price = 11200000;
            string faPrice = "یازده میلیون و دویست هزار".Replace(" ", "");
            string faPrice1 = PersianTools.Core.CharacterUtil.Convert(price).Replace(" ", "");
            Assert.Equal(faPrice, faPrice1);
        }
    }
}
