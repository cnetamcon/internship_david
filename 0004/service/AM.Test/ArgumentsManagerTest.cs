using AM.Interfaces;
using AM.Models;
using Core.Test;
using Models;

namespace AM.Test
{
    public class Tests : BaseTest
    {
        private IArgumentsManager _argumentManager;

        [SetUp]
        public void Setup()
        {
            _argumentManager = GetService<IArgumentsManager>();
        }

        [Test]
        public void Test1()
        {
            var args = @"";
            var checkModel = GetModel(
                false,
                24,
                OverwriteStlFileEnum.Overwrite,
                @"bin/test/file.srt",
                @"obj/test/file.stl");

            CheckArguments(checkModel,
                "-fr", "24",
                "-r",
                @"bin/test/file.srt",
                @"obj/test/file.stl"
                );

            Assert.Pass();
        }

        private void CheckArguments(ArgumentsModel checkModel, params string[] args)
        {
            var model = _argumentManager.Parse(args);

            Assert.IsTrue(model.HelpFlag == checkModel.HelpFlag);
            Assert.IsTrue(model.Framerate == checkModel.Framerate);
            Assert.IsTrue(model.OverwriteStl == checkModel.OverwriteStl);
            Assert.IsTrue(model.PathStl == checkModel.PathStl);
            Assert.IsTrue(model.PathSrt == checkModel.PathSrt);
        }

        private ArgumentsModel GetModel(bool help,
            double fr,
            OverwriteStlFileEnum ov,
            string srt, string stl)
        {
            return new ArgumentsModel()
            {
                HelpFlag = help,
                Framerate = fr,
                OverwriteStl = ov,
                PathStl = stl,
                PathSrt = srt
            };
        }
    }
}