using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestFurigana
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var parser = new Furigana.Parser();
            var result = parser.Parse("�������ӂ肪�Ȃɕϊ�����B");
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }
            Assert.AreEqual(7, result.Count);
            Assert.AreEqual("����", result[0].Kanji);
            Assert.AreEqual("����", result[0].Furi);
            Assert.AreEqual("��", result[1].Kanji);
            Assert.AreEqual("", result[1].Furi);
            Assert.AreEqual("�ӂ肪��", result[2].Kanji);
            Assert.AreEqual("", result[2].Furi);
            Assert.AreEqual("��", result[3].Kanji);
            Assert.AreEqual("", result[3].Furi);
            Assert.AreEqual("�ϊ�", result[4].Kanji);
            Assert.AreEqual("�ւ񂩂�", result[4].Furi);
            Assert.AreEqual("����", result[5].Kanji);
            Assert.AreEqual("", result[5].Furi);
            Assert.AreEqual("�B", result[6].Kanji);
            Assert.AreEqual("", result[6].Furi);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var parser = new Furigana.Parser();
            var result = parser.Parse("�j�̎q����肭�t���K�i�ɂȂ�Ȃ��炵���B");
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }
            Assert.AreEqual(12, result.Count);
            Assert.AreEqual("�j", result[0].Kanji);
            Assert.AreEqual("���Ƃ�", result[0].Furi);
            Assert.AreEqual("��", result[1].Kanji);
            Assert.AreEqual("", result[1].Furi);
            Assert.AreEqual("�q", result[2].Kanji);
            Assert.AreEqual("��", result[2].Furi);
            Assert.AreEqual("��", result[3].Kanji);
            Assert.AreEqual("", result[3].Furi);
            Assert.AreEqual("���", result[4].Kanji);
            Assert.AreEqual("����", result[4].Furi);
            Assert.AreEqual("��", result[5].Kanji);
            Assert.AreEqual("", result[5].Furi);
            Assert.AreEqual("�t���K�i", result[6].Kanji);
            Assert.AreEqual("", result[6].Furi);
            Assert.AreEqual("��", result[7].Kanji);
            Assert.AreEqual("", result[7].Furi);
            Assert.AreEqual("�Ȃ�", result[8].Kanji);
            Assert.AreEqual("", result[8].Furi);
            Assert.AreEqual("�Ȃ�", result[9].Kanji);
            Assert.AreEqual("", result[9].Furi);
            Assert.AreEqual("�炵��", result[10].Kanji);
            Assert.AreEqual("", result[10].Furi);
            Assert.AreEqual("�B", result[11].Kanji);
            Assert.AreEqual("", result[11].Furi);

        }

        [TestMethod]
        public void TestMethod3()
        {
            var parser = new Furigana.Parser();
            var result = parser.Parse("�������Ƃ�Yahoo!Japan�Ƃ��ǂ����낤�H");
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }
            Assert.AreEqual(11, result.Count);
            Assert.AreEqual("��", result[0].Kanji);
            Assert.AreEqual("", result[0].Furi);
            Assert.AreEqual("����", result[1].Kanji);
            Assert.AreEqual("���傤����", result[1].Furi);
            Assert.AreEqual("�Ƃ�", result[2].Kanji);
            Assert.AreEqual("", result[2].Furi);
            Assert.AreEqual("Yahoo", result[3].Kanji);
            Assert.AreEqual("", result[3].Furi);
            Assert.AreEqual("!", result[4].Kanji);
            Assert.AreEqual("", result[4].Furi);
            Assert.AreEqual("Japan", result[5].Kanji);
            Assert.AreEqual("", result[5].Furi);
            Assert.AreEqual("�Ƃ�", result[6].Kanji);
            Assert.AreEqual("", result[6].Furi);
            Assert.AreEqual("�ǂ�", result[7].Kanji);
            Assert.AreEqual("", result[7].Furi);
            Assert.AreEqual("����", result[8].Kanji);
            Assert.AreEqual("", result[8].Furi);
            Assert.AreEqual("��", result[9].Kanji);
            Assert.AreEqual("", result[9].Furi);
            Assert.AreEqual("�H", result[10].Kanji);
            Assert.AreEqual("", result[10].Furi);
        }


        [TestMethod]
        public void TestMethod4()
        {
            var parser = new Furigana.Parser();
            var text = "�t���K�i�̃e�X�g������̂ɂ������͂�����Ă݂܂����B���̕��͂́A���w�Z�ŏK�������Ƒ��肪�Ȃ��g���Ă��܂��B�����̓ǂݕ��⏑�������m�F���邽�߂ɁA�ӂ肪�Ȃ����Ă݂܂��傤�B���͂̓��e�́A**�݂�Ȃ̑����r�e�X�g**�Ƃ������ނɂ��ďЉ�Ă��܂��B���̋��ނ́A����E�Z���E���ȁE�Љ�̂S���ȑS�Ẵ��[�N�e�X�g�ɂӂ肪�Ȃ�t�������̂ŁA�������ǂ߂Ȃ��q�ǂ��ł�����������悤�ɂȂ��Ă��܂��B�ӂ肪�Ȃ̃e�X�g�ɋ���������l�́A���̋��ނ��`�F�b�N���Ă݂Ă��������B";
            var result = parser.Parse(text);
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }

        }


        [TestMethod]
        public void TestMethod5()
        {
            var parser = new Furigana.Parser();
            var text = "���p�X�y�[�X ����s\n�̏����� ��肭�����Ȃ��悤���B���Ǝ��X�́X�Ƃ����������C�ɂȂ�B";
            var result = parser.Parse(text);
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }

        }


    }
}